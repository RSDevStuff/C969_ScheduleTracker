namespace C969_ScheduleTracker
{
    partial class ManagerForm
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
            managerFormTabControl = new TabControl();
            appointmentsTab = new TabPage();
            customerIdBox = new TextBox();
            customerIdLabel = new Label();
            endTimePicker = new DateTimePicker();
            startTimePicker = new DateTimePicker();
            dateTimePicker = new DateTimePicker();
            clearButton = new Button();
            signoutButton = new Button();
            reportsButton = new Button();
            updateAppointmentButton = new Button();
            removeAppointmentButton = new Button();
            addAppointmentButton = new Button();
            dateRangeBox = new ComboBox();
            dateRangeLabel = new Label();
            appointmentGridView = new DataGridView();
            typeComboBox = new ComboBox();
            typeLabel = new Label();
            customerTextBox = new TextBox();
            customerLabel = new Label();
            endsLabel = new Label();
            startsLabel = new Label();
            dateLabel = new Label();
            selectedAppointmentLabel = new Label();
            customersTab = new TabPage();
            idBox = new TextBox();
            idLabel = new Label();
            countryTextBox = new TextBox();
            custClearButton = new Button();
            searchTextBox = new TextBox();
            custSignOutButton = new Button();
            updateCustomerButton = new Button();
            removeCustomerButton = new Button();
            addCustomerButton = new Button();
            searchLabel = new Label();
            customerGridView = new DataGridView();
            countryLabel = new Label();
            cityTextBox = new TextBox();
            cityLabel = new Label();
            phoneTextBox = new TextBox();
            phoneTextLabel = new Label();
            addressTextBox = new TextBox();
            addressLabel = new Label();
            nameTextBox = new TextBox();
            nameLabel = new Label();
            customerInformationLabel = new Label();
            managerFormTabControl.SuspendLayout();
            appointmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentGridView).BeginInit();
            customersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customerGridView).BeginInit();
            SuspendLayout();
            // 
            // managerFormTabControl
            // 
            managerFormTabControl.Controls.Add(appointmentsTab);
            managerFormTabControl.Controls.Add(customersTab);
            managerFormTabControl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            managerFormTabControl.Location = new Point(0, -2);
            managerFormTabControl.Name = "managerFormTabControl";
            managerFormTabControl.SelectedIndex = 0;
            managerFormTabControl.Size = new Size(812, 372);
            managerFormTabControl.TabIndex = 0;
            // 
            // appointmentsTab
            // 
            appointmentsTab.Controls.Add(customerIdBox);
            appointmentsTab.Controls.Add(customerIdLabel);
            appointmentsTab.Controls.Add(endTimePicker);
            appointmentsTab.Controls.Add(startTimePicker);
            appointmentsTab.Controls.Add(dateTimePicker);
            appointmentsTab.Controls.Add(clearButton);
            appointmentsTab.Controls.Add(signoutButton);
            appointmentsTab.Controls.Add(reportsButton);
            appointmentsTab.Controls.Add(updateAppointmentButton);
            appointmentsTab.Controls.Add(removeAppointmentButton);
            appointmentsTab.Controls.Add(addAppointmentButton);
            appointmentsTab.Controls.Add(dateRangeBox);
            appointmentsTab.Controls.Add(dateRangeLabel);
            appointmentsTab.Controls.Add(appointmentGridView);
            appointmentsTab.Controls.Add(typeComboBox);
            appointmentsTab.Controls.Add(typeLabel);
            appointmentsTab.Controls.Add(customerTextBox);
            appointmentsTab.Controls.Add(customerLabel);
            appointmentsTab.Controls.Add(endsLabel);
            appointmentsTab.Controls.Add(startsLabel);
            appointmentsTab.Controls.Add(dateLabel);
            appointmentsTab.Controls.Add(selectedAppointmentLabel);
            appointmentsTab.Location = new Point(4, 30);
            appointmentsTab.Name = "appointmentsTab";
            appointmentsTab.Padding = new Padding(3);
            appointmentsTab.Size = new Size(804, 338);
            appointmentsTab.TabIndex = 0;
            appointmentsTab.Text = "Appointments";
            appointmentsTab.UseVisualStyleBackColor = true;
            // 
            // customerIdBox
            // 
            customerIdBox.Location = new Point(99, 189);
            customerIdBox.Name = "customerIdBox";
            customerIdBox.Size = new Size(133, 29);
            customerIdBox.TabIndex = 24;
            customerIdBox.TextChanged += customerIdBox_TextChanged;
            // 
            // customerIdLabel
            // 
            customerIdLabel.AutoSize = true;
            customerIdLabel.Location = new Point(5, 192);
            customerIdLabel.Name = "customerIdLabel";
            customerIdLabel.Size = new Size(97, 21);
            customerIdLabel.TabIndex = 23;
            customerIdLabel.Text = "Customer ID";
            // 
            // endTimePicker
            // 
            endTimePicker.Format = DateTimePickerFormat.Time;
            endTimePicker.Location = new Point(99, 119);
            endTimePicker.Name = "endTimePicker";
            endTimePicker.ShowUpDown = true;
            endTimePicker.Size = new Size(133, 29);
            endTimePicker.TabIndex = 22;
            // 
            // startTimePicker
            // 
            startTimePicker.Format = DateTimePickerFormat.Time;
            startTimePicker.Location = new Point(99, 84);
            startTimePicker.Name = "startTimePicker";
            startTimePicker.ShowUpDown = true;
            startTimePicker.Size = new Size(133, 29);
            startTimePicker.TabIndex = 21;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Location = new Point(99, 49);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(133, 29);
            dateTimePicker.TabIndex = 20;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(251, 293);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(75, 39);
            clearButton.TabIndex = 29;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // signoutButton
            // 
            signoutButton.Location = new Point(719, 293);
            signoutButton.Name = "signoutButton";
            signoutButton.Size = new Size(75, 39);
            signoutButton.TabIndex = 31;
            signoutButton.Text = "Signout";
            signoutButton.UseVisualStyleBackColor = true;
            signoutButton.Click += signoutButton_Click;
            // 
            // reportsButton
            // 
            reportsButton.Location = new Point(638, 293);
            reportsButton.Name = "reportsButton";
            reportsButton.Size = new Size(75, 39);
            reportsButton.TabIndex = 30;
            reportsButton.Text = "Reports";
            reportsButton.UseVisualStyleBackColor = true;
            reportsButton.Click += reportsButton_Click;
            // 
            // updateAppointmentButton
            // 
            updateAppointmentButton.Location = new Point(170, 293);
            updateAppointmentButton.Name = "updateAppointmentButton";
            updateAppointmentButton.Size = new Size(75, 39);
            updateAppointmentButton.TabIndex = 28;
            updateAppointmentButton.Text = "Update";
            updateAppointmentButton.UseVisualStyleBackColor = true;
            updateAppointmentButton.Click += updateAppointmentButton_Click;
            // 
            // removeAppointmentButton
            // 
            removeAppointmentButton.Location = new Point(89, 293);
            removeAppointmentButton.Name = "removeAppointmentButton";
            removeAppointmentButton.Size = new Size(75, 39);
            removeAppointmentButton.TabIndex = 27;
            removeAppointmentButton.Text = "Remove";
            removeAppointmentButton.UseVisualStyleBackColor = true;
            removeAppointmentButton.Click += removeAppointmentButton_Click;
            // 
            // addAppointmentButton
            // 
            addAppointmentButton.Location = new Point(8, 293);
            addAppointmentButton.Name = "addAppointmentButton";
            addAppointmentButton.Size = new Size(75, 39);
            addAppointmentButton.TabIndex = 26;
            addAppointmentButton.Text = "Add";
            addAppointmentButton.UseVisualStyleBackColor = true;
            addAppointmentButton.Click += addAppointmentButton_Click;
            // 
            // dateRangeBox
            // 
            dateRangeBox.FormattingEnabled = true;
            dateRangeBox.Items.AddRange(new object[] { "All", "Today", "Week", "Month", "Year", "Specific Date" });
            dateRangeBox.Location = new Point(669, 6);
            dateRangeBox.Name = "dateRangeBox";
            dateRangeBox.Size = new Size(125, 29);
            dateRangeBox.TabIndex = 13;
            dateRangeBox.SelectedIndexChanged += dateRangeBox_SelectedIndexChanged;
            // 
            // dateRangeLabel
            // 
            dateRangeLabel.AutoSize = true;
            dateRangeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateRangeLabel.Location = new Point(565, 9);
            dateRangeLabel.Name = "dateRangeLabel";
            dateRangeLabel.Size = new Size(98, 21);
            dateRangeLabel.TabIndex = 12;
            dateRangeLabel.Text = "Date Range";
            // 
            // appointmentGridView
            // 
            appointmentGridView.AllowUserToDeleteRows = false;
            appointmentGridView.AllowUserToResizeColumns = false;
            appointmentGridView.AllowUserToResizeRows = false;
            appointmentGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appointmentGridView.Location = new Point(249, 41);
            appointmentGridView.Name = "appointmentGridView";
            appointmentGridView.ReadOnly = true;
            appointmentGridView.Size = new Size(545, 244);
            appointmentGridView.TabIndex = 11;
            appointmentGridView.CellFormatting += appointmentGridView_CellFormatting;
            appointmentGridView.SelectionChanged += appointmentGridView_SelectionChanged;
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(99, 154);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(133, 29);
            typeComboBox.TabIndex = 23;
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(8, 157);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(42, 21);
            typeLabel.TabIndex = 9;
            typeLabel.Text = "Type";
            // 
            // customerTextBox
            // 
            customerTextBox.Location = new Point(99, 224);
            customerTextBox.Name = "customerTextBox";
            customerTextBox.Size = new Size(133, 29);
            customerTextBox.TabIndex = 25;
            // 
            // customerLabel
            // 
            customerLabel.AutoSize = true;
            customerLabel.Location = new Point(8, 227);
            customerLabel.Name = "customerLabel";
            customerLabel.Size = new Size(52, 21);
            customerLabel.TabIndex = 7;
            customerLabel.Text = "Name";
            // 
            // endsLabel
            // 
            endsLabel.AutoSize = true;
            endsLabel.Location = new Point(8, 125);
            endsLabel.Name = "endsLabel";
            endsLabel.Size = new Size(43, 21);
            endsLabel.TabIndex = 5;
            endsLabel.Text = "Ends";
            // 
            // startsLabel
            // 
            startsLabel.AutoSize = true;
            startsLabel.Location = new Point(8, 92);
            startsLabel.Name = "startsLabel";
            startsLabel.Size = new Size(49, 21);
            startsLabel.TabIndex = 3;
            startsLabel.Text = "Starts";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(8, 55);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(42, 21);
            dateLabel.TabIndex = 1;
            dateLabel.Text = "Date";
            // 
            // selectedAppointmentLabel
            // 
            selectedAppointmentLabel.AutoSize = true;
            selectedAppointmentLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            selectedAppointmentLabel.Location = new Point(3, 11);
            selectedAppointmentLabel.Name = "selectedAppointmentLabel";
            selectedAppointmentLabel.Size = new Size(181, 21);
            selectedAppointmentLabel.TabIndex = 0;
            selectedAppointmentLabel.Text = "Selected Appointment";
            // 
            // customersTab
            // 
            customersTab.Controls.Add(idBox);
            customersTab.Controls.Add(idLabel);
            customersTab.Controls.Add(countryTextBox);
            customersTab.Controls.Add(custClearButton);
            customersTab.Controls.Add(searchTextBox);
            customersTab.Controls.Add(custSignOutButton);
            customersTab.Controls.Add(updateCustomerButton);
            customersTab.Controls.Add(removeCustomerButton);
            customersTab.Controls.Add(addCustomerButton);
            customersTab.Controls.Add(searchLabel);
            customersTab.Controls.Add(customerGridView);
            customersTab.Controls.Add(countryLabel);
            customersTab.Controls.Add(cityTextBox);
            customersTab.Controls.Add(cityLabel);
            customersTab.Controls.Add(phoneTextBox);
            customersTab.Controls.Add(phoneTextLabel);
            customersTab.Controls.Add(addressTextBox);
            customersTab.Controls.Add(addressLabel);
            customersTab.Controls.Add(nameTextBox);
            customersTab.Controls.Add(nameLabel);
            customersTab.Controls.Add(customerInformationLabel);
            customersTab.Location = new Point(4, 30);
            customersTab.Name = "customersTab";
            customersTab.Padding = new Padding(3);
            customersTab.Size = new Size(804, 338);
            customersTab.TabIndex = 1;
            customersTab.Text = "Customers";
            customersTab.UseVisualStyleBackColor = true;
            // 
            // idBox
            // 
            idBox.Location = new Point(89, 218);
            idBox.Name = "idBox";
            idBox.Size = new Size(133, 29);
            idBox.TabIndex = 37;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(8, 221);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(25, 21);
            idLabel.TabIndex = 40;
            idLabel.Text = "ID";
            // 
            // countryTextBox
            // 
            countryTextBox.Location = new Point(89, 183);
            countryTextBox.Name = "countryTextBox";
            countryTextBox.Size = new Size(133, 29);
            countryTextBox.TabIndex = 36;
            // 
            // custClearButton
            // 
            custClearButton.Location = new Point(251, 293);
            custClearButton.Name = "custClearButton";
            custClearButton.Size = new Size(75, 39);
            custClearButton.TabIndex = 42;
            custClearButton.Text = "Clear";
            custClearButton.UseVisualStyleBackColor = true;
            custClearButton.Click += custClearButton_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(661, 8);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(133, 29);
            searchTextBox.TabIndex = 38;
            // 
            // custSignOutButton
            // 
            custSignOutButton.Location = new Point(719, 293);
            custSignOutButton.Name = "custSignOutButton";
            custSignOutButton.Size = new Size(75, 39);
            custSignOutButton.TabIndex = 44;
            custSignOutButton.Text = "Signout";
            custSignOutButton.UseVisualStyleBackColor = true;
            // 
            // updateCustomerButton
            // 
            updateCustomerButton.Location = new Point(170, 293);
            updateCustomerButton.Name = "updateCustomerButton";
            updateCustomerButton.Size = new Size(75, 39);
            updateCustomerButton.TabIndex = 40;
            updateCustomerButton.Text = "Update";
            updateCustomerButton.UseVisualStyleBackColor = true;
            updateCustomerButton.Click += updateCustomerButton_Click;
            // 
            // removeCustomerButton
            // 
            removeCustomerButton.Location = new Point(89, 293);
            removeCustomerButton.Name = "removeCustomerButton";
            removeCustomerButton.Size = new Size(75, 39);
            removeCustomerButton.TabIndex = 39;
            removeCustomerButton.Text = "Remove";
            removeCustomerButton.UseVisualStyleBackColor = true;
            removeCustomerButton.Click += removeCustomerButton_Click;
            // 
            // addCustomerButton
            // 
            addCustomerButton.Location = new Point(8, 293);
            addCustomerButton.Name = "addCustomerButton";
            addCustomerButton.Size = new Size(75, 39);
            addCustomerButton.TabIndex = 38;
            addCustomerButton.Text = "Add";
            addCustomerButton.UseVisualStyleBackColor = true;
            addCustomerButton.Click += addCustomerButton_Click;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchLabel.Location = new Point(594, 11);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(61, 21);
            searchLabel.TabIndex = 31;
            searchLabel.Text = "Search";
            // 
            // customerGridView
            // 
            customerGridView.AllowUserToDeleteRows = false;
            customerGridView.AllowUserToResizeRows = false;
            customerGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customerGridView.Location = new Point(249, 43);
            customerGridView.MultiSelect = false;
            customerGridView.Name = "customerGridView";
            customerGridView.ReadOnly = true;
            customerGridView.Size = new Size(545, 244);
            customerGridView.TabIndex = 30;
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Location = new Point(5, 186);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new Size(66, 21);
            countryLabel.TabIndex = 28;
            countryLabel.Text = "Country";
            // 
            // cityTextBox
            // 
            cityTextBox.Location = new Point(89, 148);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.Size = new Size(133, 29);
            cityTextBox.TabIndex = 35;
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new Point(5, 151);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(37, 21);
            cityLabel.TabIndex = 26;
            cityLabel.Text = "City";
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(89, 113);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(133, 29);
            phoneTextBox.TabIndex = 34;
            // 
            // phoneTextLabel
            // 
            phoneTextLabel.AutoSize = true;
            phoneTextLabel.Location = new Point(5, 116);
            phoneTextLabel.Name = "phoneTextLabel";
            phoneTextLabel.Size = new Size(54, 21);
            phoneTextLabel.TabIndex = 24;
            phoneTextLabel.Text = "Phone";
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(89, 78);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(133, 29);
            addressTextBox.TabIndex = 33;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(5, 81);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(66, 21);
            addressLabel.TabIndex = 22;
            addressLabel.Text = "Address";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(89, 43);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(133, 29);
            nameTextBox.TabIndex = 32;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(5, 46);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(52, 21);
            nameLabel.TabIndex = 20;
            nameLabel.Text = "Name";
            // 
            // customerInformationLabel
            // 
            customerInformationLabel.AutoSize = true;
            customerInformationLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customerInformationLabel.Location = new Point(3, 11);
            customerInformationLabel.Name = "customerInformationLabel";
            customerInformationLabel.Size = new Size(179, 21);
            customerInformationLabel.TabIndex = 19;
            customerInformationLabel.Text = "Customer Information";
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 366);
            Controls.Add(managerFormTabControl);
            Name = "ManagerForm";
            Text = "Schedule Manager";
            FormClosing += ManagerForm_FormClosing;
            managerFormTabControl.ResumeLayout(false);
            appointmentsTab.ResumeLayout(false);
            appointmentsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentGridView).EndInit();
            customersTab.ResumeLayout(false);
            customersTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)customerGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl managerFormTabControl;
        private TabPage appointmentsTab;
        private TabPage customersTab;
        private Label dateLabel;
        private Label selectedAppointmentLabel;
        private ComboBox typeComboBox;
        private Label typeLabel;
        private TextBox customerTextBox;
        private Label customerLabel;
        private Label endsLabel;
        private Label startsLabel;
        private ComboBox dateRangeBox;
        private Label dateRangeLabel;
        private DataGridView appointmentGridView;
        private Button removeAppointmentButton;
        private Button addAppointmentButton;
        private Button signoutButton;
        private Button reportsButton;
        private Button updateAppointmentButton;
        private TextBox searchTextBox;
        private Button custSignOutButton;
        private Button updateCustomerButton;
        private Button removeCustomerButton;
        private Button addCustomerButton;
        private Label searchLabel;
        private DataGridView customerGridView;
        private Label countryLabel;
        private TextBox cityTextBox;
        private Label cityLabel;
        private TextBox phoneTextBox;
        private Label phoneTextLabel;
        private TextBox addressTextBox;
        private Label addressLabel;
        private TextBox nameTextBox;
        private Label nameLabel;
        private Label customerInformationLabel;
        private Button clearButton;
        private Button custClearButton;
        private TextBox countryTextBox;
        private DateTimePicker dateTimePicker;
        private DateTimePicker endTimePicker;
        private DateTimePicker startTimePicker;
        private TextBox customerIdBox;
        private Label customerIdLabel;
        private TextBox idBox;
        private Label idLabel;
    }
}