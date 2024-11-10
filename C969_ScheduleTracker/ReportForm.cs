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
            typeComboBox.DataSource = Enum.GetValues(typeof(AppointmentType));
            consultantDropBox.DataSource = users;
            consultantDropBox.DisplayMember = "Username";
            consultantDropBox.ValueMember = "UserId";
            consultantDropBox.Enabled = false;
        }

        private void appointmentTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var selectedRadioButton = (RadioButton)sender;
            if (selectedRadioButton.Checked)
            {
                consultantDropBox.Enabled = false;
                typeComboBox.Enabled = true;
                reportInfoTextBox.Text = "A report for getting the count of each appointment type in the database.";
            }
        }

        private void consultantAppointmentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var selectedRadioButton = (RadioButton)sender;
            if (selectedRadioButton.Checked)
            {
                consultantDropBox.Enabled = true;
                typeComboBox.Enabled = false;
                reportInfoTextBox.Text = "A report for getting all appointments by selected consultant.";
            }

        }

        private void customerAppointmentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var selectedRadioButton = (RadioButton)sender;
            if (selectedRadioButton.Checked)
            {
                consultantDropBox.Enabled = false;
                typeComboBox.Enabled = false;
                reportInfoTextBox.Text = "A report for getting the count of each customer's appointment given a period of time.";
            }
        }
        private void runReportButton_Click(object sender, EventArgs e)
        {
            //Lambda for finding the radio button that's checked.
            var selectedRadioButton = Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton == null) return;

            switch (selectedRadioButton.Name)
            {
                case "appointmentTypeRadioButton":
                    // Run first report
                    break;
                case "consultantAppointmentRadioButton":
                    // Run second report
                    break;
                case "customerAppointmentRadioButton":
                    // Run third report
                    break;
            }
        }
        private void runAppointmentTypeReport(DateTime start, DateTime end)
        {
            var query = DbManager.GetTypeCounts(start.ToUniversalTime().Date, end.ToUniversalTime().Date);
            
        }

        private void runConsultantAppointmentsReport(DateTime start, DateTime end, int userId)
        {
            // Implementation
        }

        private void runCustomerAppointmentReport(DateTime start, DateTime end, int customerId)
        {
            // Implementation
        }
    }
}
