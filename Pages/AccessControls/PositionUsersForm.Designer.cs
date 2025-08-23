
namespace smpc_admin.Pages.AccessControls
{
    partial class PositionUsersForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.usersLabel = new System.Windows.Forms.Label();
            this.UsersFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.usersLabel);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.UsersFlowLayoutPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1044, 630);
            this.splitContainer1.SplitterDistance = 31;
            this.splitContainer1.TabIndex = 0;
            // 
            // usersLabel
            // 
            this.usersLabel.AutoSize = true;
            this.usersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersLabel.Location = new System.Drawing.Point(7, 10);
            this.usersLabel.Name = "usersLabel";
            this.usersLabel.Size = new System.Drawing.Size(60, 17);
            this.usersLabel.TabIndex = 0;
            this.usersLabel.Text = "USERS";
            // 
            // UsersFlowLayoutPanel
            // 
            this.UsersFlowLayoutPanel.AutoScroll = true;
            this.UsersFlowLayoutPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.UsersFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.UsersFlowLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.UsersFlowLayoutPanel.Name = "UsersFlowLayoutPanel";
            this.UsersFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.UsersFlowLayoutPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UsersFlowLayoutPanel.Size = new System.Drawing.Size(1044, 595);
            this.UsersFlowLayoutPanel.TabIndex = 0;
            this.UsersFlowLayoutPanel.WrapContents = false;
            // 
            // PositionUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.Name = "PositionUsersForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(1052, 638);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label usersLabel;
        private System.Windows.Forms.FlowLayoutPanel UsersFlowLayoutPanel;
    }
}
