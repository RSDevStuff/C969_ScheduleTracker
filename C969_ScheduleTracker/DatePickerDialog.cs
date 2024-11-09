using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_ScheduleTracker
{
    public partial class DatePickerDialog : Form
    {
        public DateTime SelectedDate { get; private set; }

        public DatePickerDialog()
        {
            InitializeComponent();
        }

        private void selectDateOK_Click(object sender, EventArgs e)
        {
            SelectedDate = specificDatePicker.Value.Date;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
