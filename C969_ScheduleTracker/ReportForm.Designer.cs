namespace C969_ScheduleTracker
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            reportFormLabel = new Label();
            reportDataView = new DataGridView();
            startLabel = new Label();
            startDatePicker = new DateTimePicker();
            endLabel = new Label();
            endDatePicker = new DateTimePicker();
            runReportButton = new Button();
            clearReportButton = new Button();
            closeButton = new Button();
            appointmentTypeRadioButton = new RadioButton();
            consultantAppointmentRadioButton = new RadioButton();
            customerAppointmentRadioButton = new RadioButton();
            consultantDropBox = new ComboBox();
            consultantLabel = new Label();
            reportInfoTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)reportDataView).BeginInit();
            SuspendLayout();
            // 
            // reportFormLabel
            // 
            reportFormLabel.AutoSize = true;
            reportFormLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reportFormLabel.Location = new Point(12, 7);
            reportFormLabel.Name = "reportFormLabel";
            reportFormLabel.Size = new Size(83, 30);
            reportFormLabel.TabIndex = 0;
            reportFormLabel.Text = "Reports";
            // 
            // reportDataView
            // 
            reportDataView.AllowUserToAddRows = false;
            reportDataView.AllowUserToDeleteRows = false;
            reportDataView.AllowUserToResizeColumns = false;
            reportDataView.AllowUserToResizeRows = false;
            reportDataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reportDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reportDataView.Location = new Point(244, 77);
            reportDataView.Name = "reportDataView";
            reportDataView.ReadOnly = true;
            reportDataView.RowHeadersVisible = false;
            reportDataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reportDataView.Size = new Size(536, 237);
            reportDataView.TabIndex = 37;
            // 
            // startLabel
            // 
            startLabel.AutoSize = true;
            startLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startLabel.Location = new Point(16, 83);
            startLabel.Name = "startLabel";
            startLabel.Size = new Size(42, 21);
            startLabel.TabIndex = 39;
            startLabel.Text = "Start";
            // 
            // startDatePicker
            // 
            startDatePicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startDatePicker.Format = DateTimePickerFormat.Short;
            startDatePicker.Location = new Point(107, 77);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(121, 29);
            startDatePicker.TabIndex = 40;
            // 
            // endLabel
            // 
            endLabel.AutoSize = true;
            endLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            endLabel.Location = new Point(17, 118);
            endLabel.Name = "endLabel";
            endLabel.Size = new Size(36, 21);
            endLabel.TabIndex = 41;
            endLabel.Text = "End";
            // 
            // endDatePicker
            // 
            endDatePicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            endDatePicker.Format = DateTimePickerFormat.Short;
            endDatePicker.Location = new Point(107, 112);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(121, 29);
            endDatePicker.TabIndex = 42;
            // 
            // runReportButton
            // 
            runReportButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            runReportButton.Location = new Point(22, 320);
            runReportButton.Name = "runReportButton";
            runReportButton.Size = new Size(106, 39);
            runReportButton.TabIndex = 43;
            runReportButton.Text = "Run Report";
            runReportButton.UseVisualStyleBackColor = true;
            runReportButton.Click += runReportButton_Click;
            // 
            // clearReportButton
            // 
            clearReportButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearReportButton.Location = new Point(134, 320);
            clearReportButton.Name = "clearReportButton";
            clearReportButton.Size = new Size(106, 39);
            clearReportButton.TabIndex = 44;
            clearReportButton.Text = "Clear";
            clearReportButton.UseVisualStyleBackColor = true;
            clearReportButton.Click += clearReportButton_Click;
            // 
            // closeButton
            // 
            closeButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            closeButton.Location = new Point(674, 320);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(106, 39);
            closeButton.TabIndex = 45;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // appointmentTypeRadioButton
            // 
            appointmentTypeRadioButton.AutoSize = true;
            appointmentTypeRadioButton.Checked = true;
            appointmentTypeRadioButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appointmentTypeRadioButton.Location = new Point(19, 40);
            appointmentTypeRadioButton.Name = "appointmentTypeRadioButton";
            appointmentTypeRadioButton.Size = new Size(170, 25);
            appointmentTypeRadioButton.TabIndex = 46;
            appointmentTypeRadioButton.TabStop = true;
            appointmentTypeRadioButton.Text = "Appointment Type";
            appointmentTypeRadioButton.UseVisualStyleBackColor = true;
            appointmentTypeRadioButton.CheckedChanged += appointmentTypeRadioButton_CheckedChanged;
            // 
            // consultantAppointmentRadioButton
            // 
            consultantAppointmentRadioButton.AutoSize = true;
            consultantAppointmentRadioButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            consultantAppointmentRadioButton.Location = new Point(221, 40);
            consultantAppointmentRadioButton.Name = "consultantAppointmentRadioButton";
            consultantAppointmentRadioButton.Size = new Size(224, 25);
            consultantAppointmentRadioButton.TabIndex = 47;
            consultantAppointmentRadioButton.Text = "Consultant Appointments";
            consultantAppointmentRadioButton.UseVisualStyleBackColor = true;
            consultantAppointmentRadioButton.CheckedChanged += consultantAppointmentRadioButton_CheckedChanged;
            // 
            // customerAppointmentRadioButton
            // 
            customerAppointmentRadioButton.AutoSize = true;
            customerAppointmentRadioButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customerAppointmentRadioButton.Location = new Point(469, 40);
            customerAppointmentRadioButton.Name = "customerAppointmentRadioButton";
            customerAppointmentRadioButton.Size = new Size(214, 25);
            customerAppointmentRadioButton.TabIndex = 48;
            customerAppointmentRadioButton.Text = "Customer Appointments";
            customerAppointmentRadioButton.UseVisualStyleBackColor = true;
            customerAppointmentRadioButton.CheckedChanged += customerAppointmentRadioButton_CheckedChanged;
            // 
            // consultantDropBox
            // 
            consultantDropBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            consultantDropBox.FormattingEnabled = true;
            consultantDropBox.Location = new Point(107, 147);
            consultantDropBox.Name = "consultantDropBox";
            consultantDropBox.Size = new Size(121, 29);
            consultantDropBox.TabIndex = 50;
            // 
            // consultantLabel
            // 
            consultantLabel.AutoSize = true;
            consultantLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            consultantLabel.Location = new Point(17, 150);
            consultantLabel.Name = "consultantLabel";
            consultantLabel.Size = new Size(85, 21);
            consultantLabel.TabIndex = 49;
            consultantLabel.Text = "Consultant";
            // 
            // reportInfoTextBox
            // 
            reportInfoTextBox.BorderStyle = BorderStyle.None;
            reportInfoTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reportInfoTextBox.Location = new Point(26, 196);
            reportInfoTextBox.Multiline = true;
            reportInfoTextBox.Name = "reportInfoTextBox";
            reportInfoTextBox.ReadOnly = true;
            reportInfoTextBox.Size = new Size(202, 81);
            reportInfoTextBox.TabIndex = 51;
            reportInfoTextBox.Text = "A report for getting the count of each appointment type in the database given a period of time.";
            reportInfoTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 366);
            Controls.Add(reportInfoTextBox);
            Controls.Add(consultantDropBox);
            Controls.Add(consultantLabel);
            Controls.Add(customerAppointmentRadioButton);
            Controls.Add(consultantAppointmentRadioButton);
            Controls.Add(appointmentTypeRadioButton);
            Controls.Add(closeButton);
            Controls.Add(clearReportButton);
            Controls.Add(runReportButton);
            Controls.Add(endDatePicker);
            Controls.Add(endLabel);
            Controls.Add(startDatePicker);
            Controls.Add(startLabel);
            Controls.Add(reportDataView);
            Controls.Add(reportFormLabel);
            Name = "ReportForm";
            Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)reportDataView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label reportFormLabel;
        private DataGridView reportDataView;
        private Label startLabel;
        private DateTimePicker startDatePicker;
        private Label endLabel;
        private DateTimePicker endDatePicker;
        private Button runReportButton;
        private Button clearReportButton;
        private Button closeButton;
        private RadioButton appointmentTypeRadioButton;
        private RadioButton consultantAppointmentRadioButton;
        private RadioButton customerAppointmentRadioButton;
        private ComboBox consultantDropBox;
        private Label consultantLabel;
        private TextBox reportInfoTextBox;
    }
}