using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969_ScheduleTracker
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            appointmentTypeRadioButton.Checked = true;
            MySqlCommand userQuery = DbManager.GrabAllUsers();
            BindingList<User> users = (BindingList<User>)DbManager.ExecuteQuery(userQuery, typeof(User));
            consultantDropBox.DataSource = users;
            consultantDropBox.DisplayMember = "Username";
            consultantDropBox.ValueMember = "UserId";
            consultantDropBox.Enabled = false;
            startDatePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            endDatePicker.Value = startDatePicker.Value.AddMonths(1).AddDays(-1);
        }

        private void appointmentTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var selectedRadioButton = (RadioButton)sender;
            if (selectedRadioButton.Checked)
            {
                consultantDropBox.Enabled = false;
                reportInfoTextBox.Text = "A report for getting the count of each appointment type in the database given a period of time.";
            }
        }

        private void consultantAppointmentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var selectedRadioButton = (RadioButton)sender;
            if (selectedRadioButton.Checked)
            {
                consultantDropBox.Enabled = true;
                reportInfoTextBox.Text = "A report for getting all appointments by selected consultant given a period of time.";
            }

        }

        private void customerAppointmentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var selectedRadioButton = (RadioButton)sender;
            if (selectedRadioButton.Checked)
            {
                consultantDropBox.Enabled = false;
                reportInfoTextBox.Text = "A report for getting the count of each customer's appointment given a period of time.";
            }
        }
        private void runReportButton_Click(object sender, EventArgs e)
        {
            DateTime start = startDatePicker.Value.Date;
            DateTime end = endDatePicker.Value.Date.AddDays(1);
            var validForm = true;
            if (start > end)
            {
                validForm = false;
                MessageBox.Show("End date must be greater than start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                startDatePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                endDatePicker.Value = startDatePicker.Value.AddMonths(1).AddDays(-1);
            }

            if (validForm)
            {
                //Lambda for finding the radio button that's checked.
                var selectedRadioButton = Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                if (selectedRadioButton == null) return;

                switch (selectedRadioButton.Name)
                {
                    case "appointmentTypeRadioButton":
                        runAppointmentTypeReport(start, end);
                        break;
                    case "consultantAppointmentRadioButton":
                        var selectedUser = consultantDropBox.SelectedValue.ToString();
                        runConsultantAppointmentsReport(selectedUser, start, end);
                        break;
                    case "customerAppointmentRadioButton":
                        runCustomerAppointmentReport(start, end);
                        break;
                }
            }
        }
        private void runAppointmentTypeReport(DateTime start, DateTime end)
        {
            var query = DbManager.GetTypeCounts(start.ToUniversalTime().Date, end.ToUniversalTime().Date);
            DataTable appointmentTypes = (DataTable)DbManager.ExecuteQuery(query);
            reportDataView.DataSource = appointmentTypes;

        }

        private void runConsultantAppointmentsReport(string userId, DateTime start, DateTime end)
        {
            var appointmentList = new BindingList<Appointment>();
            // Lambda for filtering all appointments down to only those with a user Id
            // Filters AllAppointments using (if appointment userId = input userId), then adds to list for each one.
            AppointmentManager.AllAppointments.Where(appointment =>
                appointment.UserId.ToString() == userId && appointment.Start >= start && appointment.Start <= end).ToList().ForEach(appointment => appointmentList.Add(appointment));
            reportDataView.DataSource = appointmentList;
            reportDataView.Columns["Date"].Visible = false;
            reportDataView.Columns["UserId"].Visible = false;
            reportDataView.Columns["AppointmentId"].Visible = false;
            reportDataView.Columns["UserId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        private void runCustomerAppointmentReport(DateTime start, DateTime end)
        {
            var query = DbManager.GetCustomerAppointmentCounts(start, end);
            DataTable customerCounts = (DataTable)DbManager.ExecuteQuery(query);
            reportDataView.DataSource = customerCounts;
        }

        private void clearReportButton_Click(object sender, EventArgs e)
        {
            reportDataView.DataSource = null;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
