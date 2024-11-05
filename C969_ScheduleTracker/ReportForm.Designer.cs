﻿namespace C969_ScheduleTracker
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
            typeLabel = new Label();
            typeComboBox = new ComboBox();
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
            reportDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reportDataView.Location = new Point(263, 77);
            reportDataView.Name = "reportDataView";
            reportDataView.Size = new Size(493, 237);
            reportDataView.TabIndex = 37;
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeLabel.Location = new Point(13, 80);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(42, 21);
            typeLabel.TabIndex = 31;
            typeLabel.Text = "Type";
            // 
            // typeComboBox
            // 
            typeComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(103, 77);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(121, 29);
            typeComboBox.TabIndex = 38;
            // 
            // startLabel
            // 
            startLabel.AutoSize = true;
            startLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startLabel.Location = new Point(12, 120);
            startLabel.Name = "startLabel";
            startLabel.Size = new Size(42, 21);
            startLabel.TabIndex = 39;
            startLabel.Text = "Start";
            // 
            // startDatePicker
            // 
            startDatePicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startDatePicker.Format = DateTimePickerFormat.Short;
            startDatePicker.Location = new Point(103, 114);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(121, 29);
            startDatePicker.TabIndex = 40;
            // 
            // endLabel
            // 
            endLabel.AutoSize = true;
            endLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            endLabel.Location = new Point(13, 155);
            endLabel.Name = "endLabel";
            endLabel.Size = new Size(36, 21);
            endLabel.TabIndex = 41;
            endLabel.Text = "End";
            // 
            // endDatePicker
            // 
            endDatePicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            endDatePicker.Format = DateTimePickerFormat.Short;
            endDatePicker.Location = new Point(103, 149);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(121, 29);
            endDatePicker.TabIndex = 42;
            // 
            // runReportButton
            // 
            runReportButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            runReportButton.Location = new Point(22, 331);
            runReportButton.Name = "runReportButton";
            runReportButton.Size = new Size(106, 39);
            runReportButton.TabIndex = 43;
            runReportButton.Text = "Run Report";
            runReportButton.UseVisualStyleBackColor = true;
            // 
            // clearReportButton
            // 
            clearReportButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearReportButton.Location = new Point(134, 331);
            clearReportButton.Name = "clearReportButton";
            clearReportButton.Size = new Size(106, 39);
            clearReportButton.TabIndex = 44;
            clearReportButton.Text = "Clear";
            clearReportButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            closeButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            closeButton.Location = new Point(650, 331);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(106, 39);
            closeButton.TabIndex = 45;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
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
            // 
            // consultantDropBox
            // 
            consultantDropBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            consultantDropBox.FormattingEnabled = true;
            consultantDropBox.Location = new Point(103, 184);
            consultantDropBox.Name = "consultantDropBox";
            consultantDropBox.Size = new Size(121, 29);
            consultantDropBox.TabIndex = 50;
            // 
            // consultantLabel
            // 
            consultantLabel.AutoSize = true;
            consultantLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            consultantLabel.Location = new Point(13, 187);
            consultantLabel.Name = "consultantLabel";
            consultantLabel.Size = new Size(85, 21);
            consultantLabel.TabIndex = 49;
            consultantLabel.Text = "Consultant";
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 377);
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
            Controls.Add(typeComboBox);
            Controls.Add(reportDataView);
            Controls.Add(typeLabel);
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
        private Label typeLabel;
        private ComboBox typeComboBox;
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
    }
}