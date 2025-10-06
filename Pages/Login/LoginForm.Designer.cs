
namespace smpc_admin.Pages.Login
{
    partial class LoginForm
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
            this.formInputPanel = new System.Windows.Forms.Panel();
            this.submitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.employeeIdTextbox = new System.Windows.Forms.TextBox();
            this.employeeIdLabel = new System.Windows.Forms.Label();
            this.formInputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // formInputPanel
            // 
            this.formInputPanel.Controls.Add(this.submitBtn);
            this.formInputPanel.Controls.Add(this.cancelBtn);
            this.formInputPanel.Controls.Add(this.passwordTextBox);
            this.formInputPanel.Controls.Add(this.passwordLabel);
            this.formInputPanel.Controls.Add(this.employeeIdTextbox);
            this.formInputPanel.Controls.Add(this.employeeIdLabel);
            this.formInputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formInputPanel.Location = new System.Drawing.Point(0, 0);
            this.formInputPanel.Name = "formInputPanel";
            this.formInputPanel.Size = new System.Drawing.Size(344, 261);
            this.formInputPanel.TabIndex = 0;
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.submitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.submitBtn.Location = new System.Drawing.Point(184, 185);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(125, 32);
            this.submitBtn.TabIndex = 5;
            this.submitBtn.Text = "Login";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Red;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelBtn.Location = new System.Drawing.Point(38, 185);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(125, 32);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Location = new System.Drawing.Point(38, 120);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(271, 20);
            this.passwordTextBox.TabIndex = 3;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(35, 102);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(69, 15);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password";
            // 
            // employeeIdTextbox
            // 
            this.employeeIdTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.employeeIdTextbox.Location = new System.Drawing.Point(38, 65);
            this.employeeIdTextbox.Name = "employeeIdTextbox";
            this.employeeIdTextbox.Size = new System.Drawing.Size(271, 20);
            this.employeeIdTextbox.TabIndex = 1;
            // 
            // employeeIdLabel
            // 
            this.employeeIdLabel.AutoSize = true;
            this.employeeIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeIdLabel.Location = new System.Drawing.Point(35, 47);
            this.employeeIdLabel.Name = "employeeIdLabel";
            this.employeeIdLabel.Size = new System.Drawing.Size(88, 15);
            this.employeeIdLabel.TabIndex = 0;
            this.employeeIdLabel.Text = "Employee ID";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 261);
            this.Controls.Add(this.formInputPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(360, 300);
            this.MinimumSize = new System.Drawing.Size(360, 300);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.formInputPanel.ResumeLayout(false);
            this.formInputPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel formInputPanel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox employeeIdTextbox;
        private System.Windows.Forms.Label employeeIdLabel;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}