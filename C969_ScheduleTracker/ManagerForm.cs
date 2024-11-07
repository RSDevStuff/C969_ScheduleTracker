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

namespace C969_ScheduleTracker
{
    public partial class ManagerForm : Form
    {
        private int _userId;
        private int _customerId;

        public ManagerForm(int userId)
        {
            _userId = userId;
            var appointmentQuery = new MySqlCommand();
            var customerQuery = new MySqlCommand();

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

            var customerList = DbManager.ExecuteQueryToBindingList<Customer>(customerQuery);
            var appointmentList = DbManager.ExecuteQueryToBindingList<Appointment>(appointmentQuery);

            // Debug print out to reflect current rows and date
            MessageBox.Show("Appointment List Count: " + appointmentList.Count().ToString() + "\n" + "Customer List Count: " + customerList.Count().ToString());

            // Populate DataGridViews
            AppointmentManager.LoadAppointmentsFromDb(appointmentList);
            CustomerManager.LoadCustomersFromDb(customerList);

            appointmentGridView.DataSource = AppointmentManager.GetAppointmentByUserId(_userId);
            customerGridView.DataSource = CustomerManager.AllCustomers;

            // Appointment GridView Appearance and Behavior
            appointmentGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            appointmentGridView.Columns["UserId"].Visible = false;
            appointmentGridView.Columns["CustomerId"].Visible = false;
            appointmentGridView.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            appointmentGridView.Columns["Start"].DefaultCellStyle.Format = "HH:mm";
            appointmentGridView.Columns["End"].DefaultCellStyle.Format = "HH:mm";
            appointmentGridView.RowHeadersVisible = false;
            appointmentGridView.AllowUserToAddRows = false;
            appointmentGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Customer GridView Appearance and Behavior
            customerGridView.Columns["CustomerId"].Visible = false;
            customerGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            customerGridView.RowHeadersVisible = false;
            customerGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customerGridView.AllowUserToAddRows = false;
            customerGridView.SelectionChanged += customerGridView_SelectionChanged;
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
                            AppointmentManager.GetAppointmentByUserIdAndDate(_userId, currentDate, currentDate.AddDays(1));
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
                    Validation.ValidateInteger(selectedRow.Cells["customerId"].Value.ToString(), out int _customerId, out var message);
                    dateTimePicker.Value = Convert.ToDateTime(selectedRow.Cells["Date"].Value);
                    startTimePicker.Value = Convert.ToDateTime(selectedRow.Cells["Start"].Value);
                    endTimePicker.Value = Convert.ToDateTime(selectedRow.Cells["End"].Value);
                    customerIdBox.Text = selectedRow.Cells["CustomerId"].Value?.ToString() ?? "";
                    customerIdBox.Enabled = false;
                    customerTextBox.Text = selectedRow.Cells["Customer"].Value?.ToString() ?? "";
                    addAppointmentButton.Enabled = false;
                    removeAppointmentButton.Enabled = true;
                    updateAppointmentButton.Enabled = true;
                    if (Enum.TryParse(typeof(AppointmentType), selectedRow.Cells["Type"].Value?.ToString(), out var appointmentType))
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
            dateTimePicker.Value = DateTime.Now;
            startTimePicker.Value = DateTime.Now;
            endTimePicker.Value = DateTime.Now.AddHours(1);
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
                    Validation.ValidateInteger(selectedRow.Cells["customerId"].Value.ToString(), out int _customerId, out var message);
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
            string customerName;
            string selectedType = "";
            int customerId;
            bool validForm = true;

            // Creating a new appointment object
            Appointment newAppointment = new Appointment();

            // Pulling out the parts we want from the DateTimePickers
            DateTime selectedDate = dateTimePicker.Value.Date;
            TimeSpan selectedStartTime = startTimePicker.Value.TimeOfDay;
            TimeSpan selectedEndTime = endTimePicker.Value.TimeOfDay;

            //Combining into legible DateTimes
            startDateTime = selectedDate.Add(selectedStartTime);
            endDateTime = selectedDate.Add(selectedEndTime);

            // Validate Appointment Date
            if (!Validation.ValidateDateTime(startDateTime, out errorMessage))
            {
                errorMessages += errorMessage + "\n";
                validForm = false;
            }
            else
            {
                if (Validation.ValidateAppointmentTime(startDateTime, endDateTime, AppointmentManager.AllAppointments,
                        out errorMessage))
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
                if (!Validation.ValidateCustomerId(customerId, CustomerManager.AllCustomers, out customerName, out errorMessage)) 
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

            selectedType = Enum.GetName(typeof(AppointmentType), typeComboBox.SelectedIndex);
            newAppointment.Type = selectedType;
            newAppointment.UserId = _userId;

            if (validForm)
            {
                MessageBox.Show(newAppointment.ToString());
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
                if(!Validation.ValidateInteger(customerIdBox.Text, out int value, out errorMessage))
                {
                    errorMessages += "Customer ID: " + errorMessage + "\n";
                    MessageBox.Show(errorMessages, "Not An ID Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerIdBox.Clear();
                }
                else
                {
                    if (!Validation.ValidateCustomerId(value, CustomerManager.AllCustomers, out string customerName, out errorMessage))
                    {
                        customerTextBox.Clear();
                        MessageBox.Show("Customer ID: " + errorMessage, "Invalid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        customerTextBox.Text = customerName;
                    }
                }
            }
        }
    }
}
