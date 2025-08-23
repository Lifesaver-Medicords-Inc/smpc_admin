
namespace smpc_admin.Pages.AccessControls
{
    partial class PositionUsersItemForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.ActiveStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(9, 6);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(68, 13);
            this.UserNameLabel.TabIndex = 0;
            this.UserNameLabel.Text = "USERNAME";
            // 
            // ActiveStatusLabel
            // 
            this.ActiveStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ActiveStatusLabel.AutoSize = true;
            this.ActiveStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActiveStatusLabel.Location = new System.Drawing.Point(325, 6);
            this.ActiveStatusLabel.Name = "ActiveStatusLabel";
            this.ActiveStatusLabel.Size = new System.Drawing.Size(49, 13);
            this.ActiveStatusLabel.TabIndex = 1;
            this.ActiveStatusLabel.Text = "ACTIVE";
            // 
            // PositionUsersItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ActiveStatusLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.Name = "PositionUsersItemForm";
            this.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Size = new System.Drawing.Size(383, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label ActiveStatusLabel;
    }

    #endregion
}