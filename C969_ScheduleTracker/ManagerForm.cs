﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.IO;

namespace C969_ScheduleTracker
{
    public partial class ManagerForm : Form
    {
        private readonly int _userId;
        private readonly string _userName;

        public ManagerForm(int userId, string userName)
        {
            _userId = userId;
            _userName = userName;

            var appointmentQuery = new MySqlCommand();
            var customerQuery = new MySqlCommand();
            var addressQuery = new MySqlCommand();

            InitializeComponent();

            // Initialize combo boxes, datetime pickers, and DGV's
            dateRangeBox.SelectedIndex = 0;
            typeComboBox.DataSource = Enum.GetValues(typeof(AppointmentType));
            endTimePicker.CustomFormat = "hh:mm tt";
            endTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.CustomFormat = "hh:mm tt";
            startTimePicker.Format = DateTimePickerFormat.Custom;

            appointmentQuery = DbManager.GetAppointmentAll();
            customerQuery = DbManager.GetCustomerAll();
            addressQuery = DbManager.GetAddressAll();

            var customerList = DbManager.ExecuteQueryToBindingList<Customer>(customerQuery);
            var appointmentList = DbManager.ExecuteQueryToBindingList<Appointment>(appointmentQuery);
            var addressList = DbManager.ExecuteQueryToBindingList<FullAddress>(addressQuery);


            // Debug print out to reflect current rows and date
            //MessageBox.Show("Appointment List Count: " + appointmentList.Count().ToString() + "\n" + "Customer List Count: " + customerList.Count().ToString());

            // Populate DataGridViews
            AppointmentManager.LoadAppointmentsFromDb(appointmentList);
            CustomerManager.LoadCustomersFromDb(customerList);
            CustomerManager.LoadAddressesFromDb(addressList);

            appointmentGridView.DataSource = AppointmentManager.GetAppointmentByUserId(_userId);
            customerGridView.DataSource = CustomerManager.AllCustomers;

            // Appointment GridView Appearance and Behavior
            appointmentGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            appointmentGridView.Columns["UserId"].Visible = false;
            appointmentGridView.Columns["CustomerId"].Visible = false;
            appointmentGridView.Columns["AppointmentId"].Visible = false;
            appointmentGridView.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            appointmentGridView.Columns["Start"].DefaultCellStyle.Format = "hh:mm tt";
            appointmentGridView.Columns["End"].DefaultCellStyle.Format = "hh:mm tt";
            appointmentGridView.RowHeadersVisible = false;
            appointmentGridView.AllowUserToAddRows = false;
            appointmentGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentGridView.CellFormatting += appointmentGridView_CellFormatting;
            ;

            // Customer GridView Appearance and Behavior
            customerGridView.Columns["CustomerId"].Visible = false;
            customerGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            customerGridView.RowHeadersVisible = false;
            customerGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customerGridView.AllowUserToAddRows = false;
            customerGridView.SelectionChanged += customerGridView_SelectionChanged;


            appointmentGridView.ClearSelection();
            customerGridView.ClearSelection();
        }

        // Logic for DateRange ComboBox
        private void dateRangeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6);
            DateTime startOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            DateTime startofYear = new DateTime(currentDate.Year, 1, 1);
            DateTime endofYear = new DateTime(currentDate.Year, 12, 31);

            if (dateRangeBox.SelectedItem != null)
            {
                switch (dateRangeBox.SelectedItem.ToString())
                {
                    case "All":
                        appointmentGridView.DataSource = AppointmentManager.GetAppointmentByUserId(_userId);
                        break;
                    case "Today":
                        appointmentGridView.DataSource =
                            AppointmentManager.GetAppointmentByUserIdAndDate(_userId, currentDate,
                                currentDate.AddDays(1));
                        break;
                    case "Week":
                        appointmentGridView.DataSource =
                            AppointmentManager.GetAppointmentByUserIdAndDate(_userId, startOfWeek, endOfWeek);
                        break;
                    case "Month":
                        appointmentGridView.DataSource =
                            AppointmentManager.GetAppointmentByUserIdAndDate(_userId, startOfMonth, endOfMonth);
                        break;
                    case "Year":
                        appointmentGridView.DataSource =
                            AppointmentManager.GetAppointmentByUserIdAndDate(_userId, startofYear, endofYear);
                        break;
                }
            }
        }

        // Logic for selected appointment
        private void appointmentGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (appointmentGridView.SelectedRows.Count > 0)
            {
                var selectedRow = appointmentGridView.SelectedRows[0];
                if (selectedRow != null)
                {
                    Validation.ValidateInteger(selectedRow.Cells["customerId"].Value.ToString(), out int _customerId,
                        out var message);
                    dateTimePicker.Value = Convert.ToDateTime(selectedRow.Cells["Date"].Value).ToLocalTime();
                    startTimePicker.Value = Convert.ToDateTime(selectedRow.Cells["Start"].Value).ToLocalTime();
                    endTimePicker.Value = Convert.ToDateTime(selectedRow.Cells["End"].Value).ToLocalTime();
                    customerIdBox.Text = selectedRow.Cells["CustomerId"].Value?.ToString() ?? "";
                    customerIdBox.Enabled = false;
                    customerTextBox.Text = selectedRow.Cells["Customer"].Value?.ToString() ?? "";
                    addAppointmentButton.Enabled = false;
                    customerTextBox.Enabled = false;
                    removeAppointmentButton.Enabled = true;
                    updateAppointmentButton.Enabled = true;
                    if (Enum.TryParse(typeof(AppointmentType), selectedRow.Cells["Type"].Value?.ToString(),
                            out var appointmentType))
                    {
                        // Set the Type to the corresponding index of the enum value
                        typeComboBox.SelectedIndex = (int)appointmentType;
                    }

                    // Grab the customer corresponding to that appointment
                    foreach (DataGridViewRow row in customerGridView.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["CustomerId"].Value) == _customerId)
                        {
                            row.Selected = true;
                            customerGridView.CurrentCell = row.Cells[1];
                            break;
                        }
                    }

                    //Call the customerGridView event listener to update the next tab
                    customerGridView_SelectionChanged(customerGridView, EventArgs.Empty);
                }
            }
        }

        // Clear boxes and selection
        private void clearButton_Click(object sender, EventArgs e)
        {
            appointmentGridView.ClearSelection();
            dateTimePicker.Value = DateTime.Now.ToLocalTime();
            startTimePicker.Value = DateTime.Now.ToLocalTime();
            endTimePicker.Value = DateTime.Now.AddHours(1).ToLocalTime();
            customerTextBox.Clear();
            customerTextBox.Enabled = false;
            customerIdBox.Clear();
            customerIdBox.Enabled = true;
            typeComboBox.SelectedIndex = 5;
            addAppointmentButton.Enabled = true;
            updateAppointmentButton.Enabled = false;
            removeAppointmentButton.Enabled = false;
        }

        // Logic for selected customer
        private void customerGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (customerGridView.SelectedRows.Count > 0)
            {
                var selectedRow = customerGridView.SelectedRows[0];
                if (selectedRow != null)
                {
                    Validation.ValidateInteger(selectedRow.Cells["customerId"].Value.ToString(), out int _customerId,
                        out var message);
                    nameTextBox.Text = selectedRow.Cells["Name"].Value?.ToString() ?? "";
                    addressTextBox.Text = selectedRow.Cells["Address"].Value?.ToString() ?? "";
                    phoneTextBox.Text = selectedRow.Cells["Phone"].Value?.ToString() ?? "";
                    cityTextBox.Text = selectedRow.Cells["City"].Value?.ToString() ?? "";
                    countryTextBox.Text = selectedRow.Cells["Country"].Value?.ToString() ?? "";
                    idBox.Text = selectedRow.Cells["CustomerId"].Value?.ToString() ?? "";
                    idBox.Enabled = false;
                    addCustomerButton.Enabled = false;
                    updateCustomerButton.Enabled = true;
                    removeCustomerButton.Enabled = true;
                }
            }
        }

        private void custClearButton_Click(object sender, EventArgs e)
        {
            customerGridView.ClearSelection();
            nameTextBox.Clear();
            idBox.Clear();
            idBox.Enabled = false;
            addressTextBox.Clear();
            phoneTextBox.Clear();
            cityTextBox.Clear();
            countryTextBox.Clear();
            addCustomerButton.Enabled = true;
            updateCustomerButton.Enabled = false;
            removeCustomerButton.Enabled = false;
        }

        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            string errorMessage;
            string errorMessages = "";
            DateTime startDateTime;
            DateTime endDateTime;
            string selectedType = "";
            int customerId;
            bool validForm = true;

            // Creating a new appointment object
            Appointment newAppointment = new Appointment();

            // Pulling out the parts we want from the DateTimePickers
            DateTime selectedDate = dateTimePicker.Value.Date;
            TimeSpan selectedStartTime = new TimeSpan(startTimePicker.Value.Hour, startTimePicker.Value.Minute, 0);
            TimeSpan selectedEndTime = new TimeSpan(endTimePicker.Value.Hour, endTimePicker.Value.Minute, 0);

            //Combining into legible DateTimes
            startDateTime = selectedDate.Add(selectedStartTime).ToUniversalTime();
            endDateTime = selectedDate.Add(selectedEndTime).ToUniversalTime();

            // Validate Appointment Date
            if (!Validation.ValidateDateTime(startDateTime, out errorMessage))
            {
                errorMessages += errorMessage + "\n";
                validForm = false;
            }
            else
            {
                if (Validation.ValidateAppointmentTime(startDateTime, endDateTime, AppointmentManager.AllAppointments,
                        out errorMessage, "-1"))
                {
                    errorMessages += errorMessage + "\n";
                    validForm = false;
                }
                else
                {
                    newAppointment.Start = startDateTime;
                    newAppointment.End = endDateTime;
                }
            }

            //Validate customer ID exists and is good
            if (!Validation.ValidateInteger(customerIdBox.Text, out customerId, out errorMessage))
            {
                errorMessages += "Customer ID: " + errorMessage;
                validForm = false;
            }
            else
            {
                string customerName;
                if (!Validation.ValidateCustomerId(customerId, CustomerManager.AllCustomers, out customerName,
                        out errorMessage))
                {
                    errorMessages += errorMessage + "\n";
                    validForm = false;
                }
                else
                {
                    newAppointment.Customer = customerName;
                    newAppointment.CustomerId = customerId;
                }
            }

            // Grab type enum from combo box
            selectedType = Enum.GetName(typeof(AppointmentType), typeComboBox.SelectedIndex);
            newAppointment.Type = selectedType;
            newAppointment.UserId = _userId;

            if (validForm)
            {
                MySqlCommand insertStatement = DbManager.InsertNewAppointmentCommand(newAppointment.CustomerId,
                    newAppointment.UserId, newAppointment.Type, newAppointment.Start, newAppointment.End, _userName);

                try
                {
                    int code = DbManager.ExecuteModification(insertStatement);
                    var appointmentQuery = DbManager.GetAppointmentAll();
                    var appointmentList = DbManager.ExecuteQueryToBindingList<Appointment>(appointmentQuery);
                    AppointmentManager.LoadAppointmentsFromDb(appointmentList);
                    appointmentGridView.DataSource = AppointmentManager.GetAppointmentByUserId(_userId);
                    appointmentGridView.ClearSelection();
                    customerGridView.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex);
                }
            }
            else
            {
                MessageBox.Show(errorMessages, "Invalid Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customerIdBox_TextChanged(object sender, EventArgs e)
        {
            string errorMessage;
            string errorMessages = "";
            bool isAppointmentSelected = appointmentGridView.SelectedRows.Count > 0;
            bool isCustomerIdEntered = !string.IsNullOrWhiteSpace(customerIdBox.Text);

            if (!isAppointmentSelected && isCustomerIdEntered)
            {
                if (!Validation.ValidateInteger(customerIdBox.Text, out int value, out errorMessage))
                {
                    errorMessages += "Customer ID: " + errorMessage + "\n";
                    MessageBox.Show(errorMessages, "Not An ID Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerIdBox.Clear();
                }
                else
                {
                    if (!Validation.ValidateCustomerId(value, CustomerManager.AllCustomers, out string customerName,
                            out errorMessage))
                    {
                        customerTextBox.Clear();
                        MessageBox.Show("Customer ID: " + errorMessage, "Invalid Customer ID", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        customerTextBox.Text = customerName;
                    }
                }
            }
        }

        private void removeAppointmentButton_Click(object sender, EventArgs e)
        {
            if (appointmentGridView.SelectedRows.Count > 0)
            {
                var selectedRow = appointmentGridView.SelectedRows[0];
                if (selectedRow != null)
                {
                    string appointmentId = selectedRow.Cells["AppointmentId"].Value.ToString();
                    MySqlCommand removeStatement = DbManager.RemoveExistingAppointment(appointmentId);

                    DialogResult result =
                        MessageBox.Show($"Are you sure you want to delete this appointment?",
                            "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            int code = DbManager.ExecuteModification(removeStatement);
                            var appointmentQuery = DbManager.GetAppointmentAll();
                            var appointmentList = DbManager.ExecuteQueryToBindingList<Appointment>(appointmentQuery);
                            AppointmentManager.LoadAppointmentsFromDb(appointmentList);
                            appointmentGridView.DataSource = AppointmentManager.GetAppointmentByUserId(_userId);
                            appointmentGridView.ClearSelection();
                            customerGridView.ClearSelection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR:" + ex);
                        }
                    }

                }
            }
        }

        // Lets convert from UTC to Local
        private void appointmentGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check current column
            if (appointmentGridView.Columns[e.ColumnIndex].Name == "Start" ||
                appointmentGridView.Columns[e.ColumnIndex].Name == "End")
            {
                if (e.Value != null && e.Value is DateTime utcDateTime)
                {
                    DateTime localDateTime = utcDateTime.ToLocalTime();

                    e.Value = localDateTime.ToString("hh:mm tt");
                    e.FormattingApplied = true;
                }
            }

        }

        private void updateAppointmentButton_Click(object sender, EventArgs e)
        {
            if (appointmentGridView.SelectedRows.Count > 0)
            {
                var selectedRow = appointmentGridView.SelectedRows[0];
                if (selectedRow != null)
                {
                    string appointmentId = selectedRow.Cells["AppointmentId"].Value.ToString();
                    string errorMessage;
                    string errorMessages = "";
                    DateTime startDateTime;
                    DateTime endDateTime;
                    string selectedType = "";
                    int customerId;
                    bool validForm = true;

                    // Creating a new appointment object
                    Appointment newAppointment = new Appointment();

                    // Pulling out the parts we want from the DateTimePickers
                    DateTime selectedDate = dateTimePicker.Value.Date;
                    TimeSpan selectedStartTime =
                        new TimeSpan(startTimePicker.Value.Hour, startTimePicker.Value.Minute, 0);
                    TimeSpan selectedEndTime = new TimeSpan(endTimePicker.Value.Hour, endTimePicker.Value.Minute, 0);

                    //Combining into legible DateTimes
                    startDateTime = selectedDate.Add(selectedStartTime).ToUniversalTime();
                    endDateTime = selectedDate.Add(selectedEndTime).ToUniversalTime();

                    // Validate Appointment Date
                    if (!Validation.ValidateDateTime(startDateTime, out errorMessage))
                    {
                        errorMessages += errorMessage + "\n";
                        validForm = false;
                    }
                    else
                    {
                        if (Validation.ValidateAppointmentTime(startDateTime, endDateTime,
                                AppointmentManager.AllAppointments,
                                out errorMessage, appointmentId))
                        {
                            errorMessages += errorMessage + "\n";
                            validForm = false;
                        }
                        else
                        {
                            newAppointment.Start = startDateTime;
                            newAppointment.End = endDateTime;
                        }
                    }

                    //Validate customer ID exists and is good
                    if (!Validation.ValidateInteger(customerIdBox.Text, out customerId, out errorMessage))
                    {
                        errorMessages += errorMessage;
                        validForm = false;
                    }
                    else
                    {
                        string customerName;
                        if (!Validation.ValidateCustomerId(customerId, CustomerManager.AllCustomers, out customerName,
                                out errorMessage))
                        {
                            errorMessages += errorMessage + "\n";
                            validForm = false;
                        }
                        else
                        {
                            newAppointment.Customer = customerName;
                            newAppointment.CustomerId = customerId;
                        }
                    }

                    // Grab type enum from combo box
                    selectedType = Enum.GetName(typeof(AppointmentType), typeComboBox.SelectedIndex);
                    newAppointment.Type = selectedType;
                    newAppointment.UserId = _userId;

                    if (validForm)
                    {
                        MySqlCommand updateStatement = DbManager.ModifyExistingAppointment(newAppointment.CustomerId,
                            newAppointment.Type, newAppointment.Start, newAppointment.End, _userName, appointmentId);

                        DialogResult result =
                            MessageBox.Show($"Are you sure you want to modify this appointment?",
                                "Confirm Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                int code = DbManager.ExecuteModification(updateStatement);
                                var appointmentQuery = DbManager.GetAppointmentAll();
                                var appointmentList =
                                    DbManager.ExecuteQueryToBindingList<Appointment>(appointmentQuery);
                                AppointmentManager.LoadAppointmentsFromDb(appointmentList);
                                appointmentGridView.DataSource = AppointmentManager.GetAppointmentByUserId(_userId);
                                appointmentGridView.ClearSelection();
                                customerGridView.ClearSelection();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("ERROR:" + ex);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(errorMessages, "Invalid Appointment", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            bool validForm = true;
            string errorMessage;
            string errorMessages = "";

            // Blank Slate
            Customer newCustomer = new Customer();

            //Validate Customer Name
            foreach (var control in customersTab.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (textBox.Name == "idBox" || textBox.Name == "searchTextBox")
                    {
                        continue;
                    }
                    else
                    {
                        string value = textBox.Text;
                        if (!Validation.ValidateString(value, out errorMessage))
                        {
                            errorMessages += textBox.Name + ": " + errorMessage + "\n";
                            validForm = false;
                        }
                    }
                }
            }

            if (validForm)
            {
                newCustomer.Name = nameTextBox.Text;
                newCustomer.Address = addressTextBox.Text;
                newCustomer.City = cityTextBox.Text;
                newCustomer.Country = countryTextBox.Text;
                newCustomer.Phone = phoneTextBox.Text;

                // Grabs addressId, cityId, countryId
                int addressId = 0;
                int cityId = 0;
                int countryId = 0;
                bool isFound = false;

                foreach (var address in CustomerManager.AllAddresses)
                {
                    if (address.Country == newCustomer.Country.Trim())
                    {
                        countryId = address.CountryId;
                        if (address.City == newCustomer.City.Trim())
                        {
                            cityId = address.CityId;
                            if (address.AddressName == newCustomer.Address.Trim())
                            {
                                MessageBox.Show(address.AddressId.ToString());
                                addressId = address.AddressId;
                                isFound = true;
                                break;

                            }
                            else
                            {
                                // create new addressId using found city and country combination
                                var mod = DbManager.AddNewAddress(newCustomer.Address, cityId, newCustomer.Phone,
                                    _userName);
                                addressId = DbManager.ExecuteModificationReturnId(mod);
                                MessageBox.Show("New Address ID: " + addressId.ToString());
                                isFound = true;
                                break;
                            }
                        }
                        else
                        {
                            // create new city Id within the existing country
                            var mod = DbManager.AddNewCity(newCustomer.City, countryId, _userName);
                            cityId = DbManager.ExecuteModificationReturnId(mod);


                            // create new Address using the created city
                            mod = DbManager.AddNewAddress(newCustomer.Address, cityId, newCustomer.Phone, _userName);
                            addressId = DbManager.ExecuteModificationReturnId(mod);
                            MessageBox.Show("New City ID: " + cityId.ToString() + "\n" + "New Address ID: " +
                                            addressId.ToString());
                            isFound = true;
                            break;
                        }
                    }
                }

                if (!isFound)
                {
                    // Create new country ID
                    var mod = DbManager.AddNewCountry(newCustomer.Country, _userName);
                    countryId = DbManager.ExecuteModificationReturnId(mod);

                    // ...new cityId
                    mod = DbManager.AddNewCity(newCustomer.City, countryId, _userName);
                    cityId = DbManager.ExecuteModificationReturnId(mod);

                    // ...and new address Id.
                    mod = DbManager.AddNewAddress(newCustomer.Address, cityId, newCustomer.Phone, _userName);
                    addressId = DbManager.ExecuteModificationReturnId(mod);
                    MessageBox.Show("New Country ID: " + countryId.ToString() + "\n" + "New City ID: " +
                                    cityId.ToString() + "\n" + "New Address ID: " + addressId.ToString());

                }
                var customerInsert = DbManager.AddNewCustomer(newCustomer.Name, addressId, _userName);
                var newCustomerId = DbManager.ExecuteModificationReturnId(customerInsert);
                MessageBox.Show($"New customer created with ID: {newCustomerId}");
                var customerQuery = DbManager.GetCustomerAll();
                var customerList = DbManager.ExecuteQueryToBindingList<Customer>(customerQuery);
                CustomerManager.LoadCustomersFromDb(customerList);
                customerGridView.DataSource = customerList;

            }
            else
            {
                MessageBox.Show(errorMessages, "Invalid Form", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void removeCustomerButton_Click(object sender, EventArgs e)
        {
            if (customerGridView.SelectedRows.Count > 0)
            {
                var selectedRow = customerGridView.SelectedRows[0];
                if (selectedRow != null)
                {
                    string customerId = selectedRow.Cells["CustomerId"].Value.ToString();
                    MySqlCommand removeStatement = DbManager.RemoveExistingCustomer(customerId);

                    DialogResult result =
                        MessageBox.Show(
                            $"Are you sure you want to delete this customer? It will also delete related appointments.",
                            "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            int code = DbManager.ExecuteModification(removeStatement);

                            var appointmentQuery = DbManager.GetAppointmentAll();
                            var appointmentList = DbManager.ExecuteQueryToBindingList<Appointment>(appointmentQuery);
                            AppointmentManager.LoadAppointmentsFromDb(appointmentList);
                            appointmentGridView.DataSource = AppointmentManager.GetAppointmentByUserId(_userId);

                            var customerQuery = DbManager.GetCustomerAll();
                            var customerList = DbManager.ExecuteQueryToBindingList<Customer>(customerQuery);
                            CustomerManager.LoadCustomersFromDb(customerList);
                            customerGridView.DataSource = CustomerManager.AllCustomers;

                            appointmentGridView.ClearSelection();
                            customerGridView.ClearSelection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR:" + ex);
                        }
                    }

                }
            }
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            bool validForm = true;
            string errorMessage;
            string errorMessages = "";
            string customerName;
            string customerId;
            string addressName;
            string phone;;

            if (customerGridView.SelectedRows.Count > 0)
            {
                var selectedRow = customerGridView.SelectedRows[0];
                if (selectedRow != null)
                {
                    foreach (var control in customersTab.Controls)
                    {
                        if (control is TextBox textBox)
                        {
                            if (textBox.Name == "idBox" || textBox.Name == "searchTextBox")
                            {
                                continue;
                            }
                            else
                            {
                                string value = textBox.Text;
                                if (!Validation.ValidateString(value, out errorMessage))
                                {
                                    errorMessages += textBox.Name + ": " + errorMessage + "\n";
                                    validForm = false;
                                }
                            }
                        }
                    }

                }

                if (validForm)
                {
                    Customer newCustomer = new Customer();
                    newCustomer.Name = nameTextBox.Text;
                    newCustomer.Address = addressTextBox.Text;
                    newCustomer.City = cityTextBox.Text;
                    newCustomer.Country = countryTextBox.Text;
                    newCustomer.Phone = phoneTextBox.Text;

                    // Grabs addressId, cityId, countryId
                    int addressId = 0;
                    int cityId = 0;
                    int countryId = 0;
                    bool isFound = false;

                    foreach (var address in CustomerManager.AllAddresses)
                    {
                        MessageBox.Show(address.Phone);
                        if (address.Country == newCustomer.Country.Trim())
                        {
                            // If the country exists in our DB, we just select the ID.
                            countryId = address.CountryId;
                            if (address.City == newCustomer.City.Trim())
                            {
                                // If the city exists in our DB, we just select the ID.
                                cityId = address.CityId;
                                if (address.AddressName == newCustomer.Address.Trim())
                                {
                                    // If the address exists in our DB, we just select the ID.
                                    addressId = address.AddressId;
                                    if (address.Phone == newCustomer.Phone)
                                    {
                                        isFound = true;
                                        break;
                                    }
                                    else
                                    {
                                        // Update the existing address with the phone number
                                        // Not a perfect solution, but the DB provided doesn't allow for a lot of flexibility.
                                        var mod = DbManager.UpdateExistingAddress(addressId, newCustomer.Address,
                                            cityId, newCustomer.Phone, _userName);
                                        var effected = DbManager.ExecuteModification(mod);
                                        MessageBox.Show("EFFECTED: " + effected.ToString());
                                        isFound = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                // create new city Id within the existing country
                                var mod = DbManager.AddNewCity(newCustomer.City, countryId, _userName);
                                cityId = DbManager.ExecuteModificationReturnId(mod);


                                // create new Address using the created city
                                mod = DbManager.AddNewAddress(newCustomer.Address, cityId, newCustomer.Phone,
                                    _userName);
                                addressId = DbManager.ExecuteModificationReturnId(mod);
                                isFound = true;
                                break;
                            }
                        }
                    }

                    if (!isFound)
                    {
                        // Create new country ID
                        var mod = DbManager.AddNewCountry(newCustomer.Country, _userName);
                        countryId = DbManager.ExecuteModificationReturnId(mod);

                        // ...new cityId
                        mod = DbManager.AddNewCity(newCustomer.City, countryId, _userName);
                        cityId = DbManager.ExecuteModificationReturnId(mod);

                        // ...and new address Id.
                        mod = DbManager.AddNewAddress(newCustomer.Address, cityId, newCustomer.Phone, _userName);
                        addressId = DbManager.ExecuteModificationReturnId(mod);
                        MessageBox.Show("New Country ID: " + countryId.ToString() + "\n" + "New City ID: " +
                                        cityId.ToString() + "\n" + "New Address ID: " + addressId.ToString());
                    }

                    // Need a modify customer query that will update the database, everything else should follow??
                    // Need to verify that appointment customer names will change
                    customerId = selectedRow.Cells["CustomerId"].Value.ToString();
                    var customerUpdate = DbManager.UpdateExistingCustomer(customerId, newCustomer.Name, addressId, _userName);
                    var rows = DbManager.ExecuteModification(customerUpdate);
                    MessageBox.Show("EFFECTED: " + rows.ToString());
                    
                    var customerQuery = DbManager.GetCustomerAll();
                    var customerList = DbManager.ExecuteQueryToBindingList<Customer>(customerQuery);
                    
                    
                    var addressQuery = DbManager.GetAddressAll();
                    var addressList = DbManager.ExecuteQueryToBindingList<FullAddress>(addressQuery);
                    CustomerManager.LoadAddressesFromDb(addressList);
                    
                    CustomerManager.LoadCustomersFromDb(customerList);
                    customerGridView.DataSource = customerList;

                    
                    // Refresh appointment list
                    var appointmentQuery = DbManager.GetAppointmentAll();
                    var appointmentList = DbManager.ExecuteQueryToBindingList<Appointment>(appointmentQuery);
                    AppointmentManager.LoadAppointmentsFromDb(appointmentList);
                    appointmentGridView.DataSource = AppointmentManager.GetAppointmentByUserId(_userId);

                }
                else
                {
                    MessageBox.Show(errorMessages, "Invalid Form", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
