﻿namespace C969_ScheduleTracker
{
    partial class LogIn
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            locationLabel = new Label();
            userNameLabel = new Label();
            userNameTextBox = new TextBox();
            userPwTextBox = new TextBox();
            passwordLabel = new Label();
            signInButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            locationLabel.Location = new Point(264, 9);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(99, 17);
            locationLabel.TabIndex = 0;
            locationLabel.Text = "Location: US/FR";
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userNameLabel.Location = new Point(12, 62);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(106, 30);
            userNameLabel.TabIndex = 1;
            userNameLabel.Text = "Username";
            // 
            // userNameTextBox
            // 
            userNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userNameTextBox.Location = new Point(124, 63);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(225, 29);
            userNameTextBox.TabIndex = 2;
            // 
            // userPwTextBox
            // 
            userPwTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userPwTextBox.Location = new Point(124, 108);
            userPwTextBox.Name = "userPwTextBox";
            userPwTextBox.Size = new Size(225, 29);
            userPwTextBox.TabIndex = 4;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordLabel.Location = new Point(12, 107);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(99, 30);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Password";
            // 
            // signInButton
            // 
            signInButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signInButton.Location = new Point(124, 166);
            signInButton.Name = "signInButton";
            signInButton.Size = new Size(106, 37);
            signInButton.TabIndex = 5;
            signInButton.Text = "Sign In";
            signInButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exitButton.Location = new Point(243, 166);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(106, 37);
            exitButton.TabIndex = 6;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(139, 21);
            label1.TabIndex = 7;
            label1.Text = "Schedule Manager";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 215);
            Controls.Add(label1);
            Controls.Add(exitButton);
            Controls.Add(signInButton);
            Controls.Add(userPwTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(userNameTextBox);
            Controls.Add(userNameLabel);
            Controls.Add(locationLabel);
            Name = "Form1";
            Text = "Sign In";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label locationLabel;
        private Label userNameLabel;
        private TextBox userNameTextBox;
        private TextBox userPwTextBox;
        private Label passwordLabel;
        private Button signInButton;
        private Button exitButton;
        private Label label1;
    }
}
