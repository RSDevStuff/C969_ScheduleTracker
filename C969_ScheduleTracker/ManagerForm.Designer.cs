﻿namespace C969_ScheduleTracker
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
            clearButton = new Button();
            exitButton = new Button();
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
            endsTextBox = new TextBox();
            endsLabel = new Label();
            startsTextBox = new TextBox();
            startsLabel = new Label();
            dateTextBox = new TextBox();
            dateLabel = new Label();
            selectedAppointmentLabel = new Label();
            customersTab = new TabPage();
            countryTextBox = new TextBox();
            custClearButton = new Button();
            searchTextBox = new TextBox();
            customerExitButton = new Button();
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
            appointmentsTab.Controls.Add(clearButton);
            appointmentsTab.Controls.Add(exitButton);
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
            appointmentsTab.Controls.Add(endsTextBox);
            appointmentsTab.Controls.Add(endsLabel);
            appointmentsTab.Controls.Add(startsTextBox);
            appointmentsTab.Controls.Add(startsLabel);
            appointmentsTab.Controls.Add(dateTextBox);
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
            // clearButton
            // 
            clearButton.Location = new Point(251, 293);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(75, 39);
            clearButton.TabIndex = 19;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(719, 293);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 39);
            exitButton.TabIndex = 18;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            // 
            // reportsButton
            // 
            reportsButton.Location = new Point(638, 293);
            reportsButton.Name = "reportsButton";
            reportsButton.Size = new Size(75, 39);
            reportsButton.TabIndex = 17;
            reportsButton.Text = "Reports";
            reportsButton.UseVisualStyleBackColor = true;
            // 
            // updateAppointmentButton
            // 
            updateAppointmentButton.Location = new Point(170, 293);
            updateAppointmentButton.Name = "updateAppointmentButton";
            updateAppointmentButton.Size = new Size(75, 39);
            updateAppointmentButton.TabIndex = 16;
            updateAppointmentButton.Text = "Update";
            updateAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // removeAppointmentButton
            // 
            removeAppointmentButton.Location = new Point(89, 293);
            removeAppointmentButton.Name = "removeAppointmentButton";
            removeAppointmentButton.Size = new Size(75, 39);
            removeAppointmentButton.TabIndex = 15;
            removeAppointmentButton.Text = "Remove";
            removeAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // addAppointmentButton
            // 
            addAppointmentButton.Location = new Point(8, 293);
            addAppointmentButton.Name = "addAppointmentButton";
            addAppointmentButton.Size = new Size(75, 39);
            addAppointmentButton.TabIndex = 14;
            addAppointmentButton.Text = "Add";
            addAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // dateRangeBox
            // 
            dateRangeBox.FormattingEnabled = true;
            dateRangeBox.Items.AddRange(new object[] { "All", "Today", "Week", "Month", "Year" });
            dateRangeBox.Location = new Point(678, 6);
            dateRangeBox.Name = "dateRangeBox";
            dateRangeBox.Size = new Size(116, 29);
            dateRangeBox.TabIndex = 13;
            dateRangeBox.SelectedIndexChanged += dateRangeBox_SelectedIndexChanged;
            // 
            // dateRangeLabel
            // 
            dateRangeLabel.AutoSize = true;
            dateRangeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateRangeLabel.Location = new Point(582, 9);
            dateRangeLabel.Name = "dateRangeLabel";
            dateRangeLabel.Size = new Size(98, 21);
            dateRangeLabel.TabIndex = 12;
            dateRangeLabel.Text = "Date Range";
            // 
            // appointmentGridView
            // 
            appointmentGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appointmentGridView.Location = new Point(249, 43);
            appointmentGridView.Name = "appointmentGridView";
            appointmentGridView.Size = new Size(545, 244);
            appointmentGridView.TabIndex = 11;
            appointmentGridView.SelectionChanged += appointmentGridView_SelectionChanged;
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(89, 186);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(133, 29);
            typeComboBox.TabIndex = 10;
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(5, 186);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(42, 21);
            typeLabel.TabIndex = 9;
            typeLabel.Text = "Type";
            // 
            // customerTextBox
            // 
            customerTextBox.Location = new Point(89, 148);
            customerTextBox.Name = "customerTextBox";
            customerTextBox.Size = new Size(133, 29);
            customerTextBox.TabIndex = 8;
            // 
            // customerLabel
            // 
            customerLabel.AutoSize = true;
            customerLabel.Location = new Point(5, 151);
            customerLabel.Name = "customerLabel";
            customerLabel.Size = new Size(78, 21);
            customerLabel.TabIndex = 7;
            customerLabel.Text = "Customer";
            // 
            // endsTextBox
            // 
            endsTextBox.Location = new Point(89, 113);
            endsTextBox.Name = "endsTextBox";
            endsTextBox.Size = new Size(133, 29);
            endsTextBox.TabIndex = 6;
            // 
            // endsLabel
            // 
            endsLabel.AutoSize = true;
            endsLabel.Location = new Point(5, 116);
            endsLabel.Name = "endsLabel";
            endsLabel.Size = new Size(43, 21);
            endsLabel.TabIndex = 5;
            endsLabel.Text = "Ends";
            // 
            // startsTextBox
            // 
            startsTextBox.Location = new Point(89, 78);
            startsTextBox.Name = "startsTextBox";
            startsTextBox.Size = new Size(133, 29);
            startsTextBox.TabIndex = 4;
            // 
            // startsLabel
            // 
            startsLabel.AutoSize = true;
            startsLabel.Location = new Point(5, 81);
            startsLabel.Name = "startsLabel";
            startsLabel.Size = new Size(49, 21);
            startsLabel.TabIndex = 3;
            startsLabel.Text = "Starts";
            // 
            // dateTextBox
            // 
            dateTextBox.Location = new Point(89, 43);
            dateTextBox.Name = "dateTextBox";
            dateTextBox.Size = new Size(133, 29);
            dateTextBox.TabIndex = 2;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(5, 46);
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
            customersTab.Controls.Add(countryTextBox);
            customersTab.Controls.Add(custClearButton);
            customersTab.Controls.Add(searchTextBox);
            customersTab.Controls.Add(customerExitButton);
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
            // countryTextBox
            // 
            countryTextBox.Location = new Point(89, 183);
            countryTextBox.Name = "countryTextBox";
            countryTextBox.Size = new Size(133, 29);
            countryTextBox.TabIndex = 40;
            // 
            // custClearButton
            // 
            custClearButton.Location = new Point(251, 293);
            custClearButton.Name = "custClearButton";
            custClearButton.Size = new Size(75, 39);
            custClearButton.TabIndex = 39;
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
            // customerExitButton
            // 
            customerExitButton.Location = new Point(719, 293);
            customerExitButton.Name = "customerExitButton";
            customerExitButton.Size = new Size(75, 39);
            customerExitButton.TabIndex = 37;
            customerExitButton.Text = "Exit";
            customerExitButton.UseVisualStyleBackColor = true;
            // 
            // updateCustomerButton
            // 
            updateCustomerButton.Location = new Point(170, 293);
            updateCustomerButton.Name = "updateCustomerButton";
            updateCustomerButton.Size = new Size(75, 39);
            updateCustomerButton.TabIndex = 35;
            updateCustomerButton.Text = "Update";
            updateCustomerButton.UseVisualStyleBackColor = true;
            // 
            // removeCustomerButton
            // 
            removeCustomerButton.Location = new Point(89, 293);
            removeCustomerButton.Name = "removeCustomerButton";
            removeCustomerButton.Size = new Size(75, 39);
            removeCustomerButton.TabIndex = 34;
            removeCustomerButton.Text = "Remove";
            removeCustomerButton.UseVisualStyleBackColor = true;
            // 
            // addCustomerButton
            // 
            addCustomerButton.Location = new Point(8, 293);
            addCustomerButton.Name = "addCustomerButton";
            addCustomerButton.Size = new Size(75, 39);
            addCustomerButton.TabIndex = 33;
            addCustomerButton.Text = "Add";
            addCustomerButton.UseVisualStyleBackColor = true;
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
            customerGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customerGridView.Location = new Point(249, 43);
            customerGridView.MultiSelect = false;
            customerGridView.Name = "customerGridView";
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
            cityTextBox.TabIndex = 27;
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
            phoneTextBox.TabIndex = 25;
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
            addressTextBox.TabIndex = 23;
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
            nameTextBox.TabIndex = 21;
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
        private TextBox dateTextBox;
        private Label dateLabel;
        private Label selectedAppointmentLabel;
        private ComboBox typeComboBox;
        private Label typeLabel;
        private TextBox customerTextBox;
        private Label customerLabel;
        private TextBox endsTextBox;
        private Label endsLabel;
        private TextBox startsTextBox;
        private Label startsLabel;
        private ComboBox dateRangeBox;
        private Label dateRangeLabel;
        private DataGridView appointmentGridView;
        private Button removeAppointmentButton;
        private Button addAppointmentButton;
        private Button exitButton;
        private Button reportsButton;
        private Button updateAppointmentButton;
        private TextBox searchTextBox;
        private Button customerExitButton;
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
    }
}