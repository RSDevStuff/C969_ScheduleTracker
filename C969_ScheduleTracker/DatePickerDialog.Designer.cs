namespace C969_ScheduleTracker
{
    partial class DatePickerDialog
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
            specificDatePicker = new DateTimePicker();
            selectDateOK = new Button();
            selectDateCancel = new Button();
            SuspendLayout();
            // 
            // specificDatePicker
            // 
            specificDatePicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            specificDatePicker.Format = DateTimePickerFormat.Short;
            specificDatePicker.Location = new Point(26, 24);
            specificDatePicker.Name = "specificDatePicker";
            specificDatePicker.Size = new Size(200, 29);
            specificDatePicker.TabIndex = 0;
            // 
            // selectDateOK
            // 
            selectDateOK.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            selectDateOK.Location = new Point(26, 72);
            selectDateOK.Name = "selectDateOK";
            selectDateOK.Size = new Size(75, 29);
            selectDateOK.TabIndex = 1;
            selectDateOK.Text = "Select";
            selectDateOK.UseVisualStyleBackColor = true;
            selectDateOK.Click += selectDateOK_Click;
            // 
            // selectDateCancel
            // 
            selectDateCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            selectDateCancel.Location = new Point(151, 72);
            selectDateCancel.Name = "selectDateCancel";
            selectDateCancel.Size = new Size(75, 29);
            selectDateCancel.TabIndex = 2;
            selectDateCancel.Text = "Cancel";
            selectDateCancel.UseVisualStyleBackColor = true;
            // 
            // DatePickerDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 113);
            Controls.Add(selectDateCancel);
            Controls.Add(selectDateOK);
            Controls.Add(specificDatePicker);
            Name = "DatePickerDialog";
            Text = "Pick Specific Date";
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker specificDatePicker;
        private Button selectDateOK;
        private Button selectDateCancel;
    }
}