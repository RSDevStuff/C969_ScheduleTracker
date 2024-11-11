using System;
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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

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

            // Initialize combo boxes, datetime pickers, and DGVs
            dateRangeBox.SelectedIndex = 0;
            typeComboBox.DataSource = Enum.GetValues(typeof(AppointmentType));
            endTimePicker.CustomFormat = "hh:mm tt";
            endTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.CustomFormat = "hh:mm tt";
            startTimePicker.Format = DateTimePickerFormat.Custom;

            // This inserts an appointment into the appointment table, 15 minutes from the moment the form is initialized to demo the capability exists
            var addUpcomingAppointment = DbManager.InsertNewAppointmentCommand(1, _userId, "Other",
                DateTime.Now.ToUniversalTime().AddMinutes(10), DateTime.Now.ToUniversalTime().AddMinutes(70), _userName);
            DbManager.ExecuteModification(addUpcomingAppointment);

            appointmentQuery = DbManager.GetAppointmentAll();
            customerQuery = DbManager.GetCustomerAll();
            addressQuery = DbManager.GetAddressAll();

            var customerList = (BindingList<Customer>)DbManager.ExecuteQuery(customerQuery, typeof(Customer));
            var appointmentList = (BindingList<Appointment>)DbManager.ExecuteQuery(appointmentQuery, typeof(Appointment));
            var addressList = (BindingList<FullAddress>)DbManager.ExecuteQuery(addressQuery, typeof(FullAddress));


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
            appointmentGridView.Columns["Start"].DefaultCellStyle.Format = "hh:mm tt x";
            appointmentGridView.Columns["End"].DefaultCellStyle.Format = "hh:mm tt x";
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
            AppointmentManager.CheckForUpcomingAppointments(_userId);
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
                    case "Specific Date":
                        using (var datePickerDialog = new DatePickerDialog())
                        {
                            var result = datePickerDialog.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                DateTime selectedDate = datePickerDialog.SelectedDate;
                                appointmentGridView.DataSource = AppointmentManager.GetAppointmentByUserIdAndDate(_userId, selectedDate, selectedDate.AddDays(1));
                            }
                        }
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
                    var appointmentList = (BindingList<Appointment>)DbManager.ExecuteQuery(appointmentQuery, typeof(Appointment));
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

                            var appointmentList = (BindingList<Appointment>)DbManager.ExecuteQuery(appointmentQuery, typeof(Appointment));
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

        // Let's convert from UTC to Local
        private void appointmentGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check current column
            if (appointmentGridView.Columns[e.ColumnIndex].Name == "Start" ||
                appointmentGridView.Columns[e.ColumnIndex].Name == "End")
            {
                // Convert it to local time
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

                    // Pulling out the sections we want from the DateTimePickers
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
                                var appointmentList = (BindingList<Appointment>)
                                    DbManager.ExecuteQuery(appointmentQuery, typeof(Appointment));
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
        //TODO Need to fix this method, use the update customer method as the template
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
                    if (textBox.Name == "phoneTextBox")
                    {
                        if (!Validation.ValidatePhoneNumber(textBox.Text, out errorMessage))
                        {
                            errorMessages += errorMessage + "\n";
                            validForm = false;
                        }
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

                }
                var customerInsert = DbManager.AddNewCustomer(newCustomer.Name, addressId, _userName);
                var newCustomerId = DbManager.ExecuteModificationReturnId(customerInsert);
                MessageBox.Show($"New customer created with ID: {newCustomerId}");
                var customerQuery = DbManager.GetCustomerAll();
                var customerList = (BindingList<Customer>)DbManager.ExecuteQuery(customerQuery, typeof(Customer));
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
                            var appointmentList = (BindingList<Appointment>)DbManager.ExecuteQuery(appointmentQuery, typeof(Appointment));
                            AppointmentManager.LoadAppointmentsFromDb(appointmentList);
                            appointmentGridView.DataSource = AppointmentManager.GetAppointmentByUserId(_userId);

                            var customerQuery = DbManager.GetCustomerAll();
                            var customerList = (BindingList<Customer>)DbManager.ExecuteQuery(customerQuery, typeof(Customer));
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

        // Update customer now fixed, properly updates records. 
        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            bool validForm = true;
            string errorMessage;
            string errorMessages = "";

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

                            if (textBox.Name == "phoneTextBox")
                            {
                                if (!Validation.ValidatePhoneNumber(textBox.Text, out errorMessage))
                                {
                                    errorMessages += errorMessage + "\n";
                                    validForm = false;
                                }
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
                    newCustomer.CustomerId = Convert.ToInt32(selectedRow.Cells["CustomerId"].Value);

                    // Grabs addressId, cityId, countryId
                    int addressId = 0;
                    int cityId = 0;
                    int countryId = 0;


                    // Check if country exists, grab the ID if it does
                    var countryQuery = DbManager.GetCountryIdByName(newCustomer.Country.Trim());
                    var countryList = (DataTable) DbManager.ExecuteQuery(countryQuery);
                    if (countryList.Rows.Count > 0)
                    {
                        countryId = Convert.ToInt32(countryList.Rows[0]["countryId"]);
                    }
                    else
                    {
                        // Create new country ID
                        var mod = DbManager.AddNewCountry(newCustomer.Country, _userName);
                        countryId = DbManager.ExecuteModificationReturnId(mod);

                        // Create new city ID using Country ID
                        mod = DbManager.AddNewCity(newCustomer.City, countryId, _userName);
                        cityId = DbManager.ExecuteModificationReturnId(mod);

                        // Create new address ID using city ID 
                        mod = DbManager.AddNewAddress(newCustomer.Address, cityId, newCustomer.Phone, _userName);
                        addressId = DbManager.ExecuteModificationReturnId(mod);
                    }

                    // Check if city exists, grab the ID if it does
                    var cityQuery = DbManager.GetCityByCityNameAndCountryId(newCustomer.City, countryId);
                    var cityList = (DataTable) DbManager.ExecuteQuery(cityQuery);
                    if (cityList.Rows.Count > 0)
                    {
                        cityId = Convert.ToInt32(cityList.Rows[0]["cityId"]);
                    }
                    else
                    {
                        // Create new City ID using Country ID
                        var mod = DbManager.AddNewCity(newCustomer.City, countryId, _userName);
                        cityId = DbManager.ExecuteModificationReturnId(mod);

                        // Create new address ID using City ID
                        mod = DbManager.AddNewAddress(newCustomer.Address, cityId, newCustomer.Phone, _userName);
                        addressId = DbManager.ExecuteModificationReturnId(mod);
                    }

                    // Check if the address exists, including phone, grab the ID if it does
                    var addressQuery =
                        DbManager.GetAddressIdByAddressNamePhoneAndCityId(newCustomer.Address, newCustomer.Phone,
                            cityId);
                    var addressList = (DataTable) DbManager.ExecuteQuery(addressQuery);
                    if (addressList.Rows.Count > 0)
                    {
                        addressId = Convert.ToInt32(addressList.Rows[0]["addressId"]);
                    }
                    else
                    {
                        // Create new address ID
                        var mod = DbManager.AddNewAddress(newCustomer.Address, cityId, newCustomer.Phone, _userName);
                        addressId = DbManager.ExecuteModificationReturnId(mod);
                    }

                    // Finally, modify the customer
                    var customerUpdate = DbManager.UpdateExistingCustomer(newCustomer.CustomerId, newCustomer.Name, addressId, _userName);
                    var rows = DbManager.ExecuteModification(customerUpdate);
                    if (rows > 0)
                    {
                        MessageBox.Show("Customer record " + newCustomer.CustomerId + "updated.");
                    }

                    // Refresh customer table
                    var customerQuery = DbManager.GetCustomerAll();
                    var customerList = (BindingList<Customer>)DbManager.ExecuteQuery(customerQuery, typeof(Customer));
                    CustomerManager.LoadCustomersFromDb(customerList);
                    customerGridView.DataSource = customerList;
                    
                    // Refresh address table, though we should figure out if we need it
                    var allAddressQuery = DbManager.GetAddressAll();
                    var allAddressList = (BindingList<FullAddress>)DbManager.ExecuteQuery(allAddressQuery, typeof(FullAddress));
                    CustomerManager.LoadAddressesFromDb(allAddressList);

                    // Refresh appointment table
                    var appointmentQuery = DbManager.GetAppointmentAll();
                    var appointmentList = (BindingList<Appointment>)DbManager.ExecuteQuery(appointmentQuery, typeof(Appointment));
                    AppointmentManager.LoadAppointmentsFromDb(appointmentList);
                    appointmentGridView.DataSource = AppointmentManager.GetAppointmentByUserId(_userId);

                }
                else
                {
                    MessageBox.Show(errorMessages, "Invalid Form", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void signoutButton_Click(object sender, EventArgs e)
        {
            Hide();

            LogIn loginForm = new LogIn();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                int userId = loginForm.UserID;
                string userName = loginForm.UserName;

                ManagerForm newManagerForm = new ManagerForm(userId, userName);
                newManagerForm.ShowDialog();
            }
        }

        private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Make sure the application closes, and prevents the hidden forms from holding the program hostage
            Application.Exit();
        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchValue = searchTextBox.Text.Trim();
            var filteredCustomerList = new BindingList<Customer>();

            // Clear the filtered list
            if (String.IsNullOrEmpty(searchValue))
            {
               customerGridView.DataSource = CustomerManager.AllCustomers;
            }
            else
            {
                if (Validation.ValidateInteger(searchValue, out var value, out var message))
                {
                    customerGridView.DataSource = CustomerManager.GetCustomerById(value);
                }
                else
                {
                    customerGridView.DataSource = CustomerManager.GetCustomerByStringValue(searchValue);
                }
            }
        }
    }
}
