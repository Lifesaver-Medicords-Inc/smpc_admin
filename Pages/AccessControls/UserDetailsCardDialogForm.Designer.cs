
namespace smpc_admin.Pages.AccessControls
{
    partial class UserDetailsCardDialogForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UserNameTextLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.permissionsLabel = new System.Windows.Forms.Label();
            this.PositionsComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CanDeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.CanUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.CanCreateCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel1.Controls.Add(this.UpdateBtn);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Size = new System.Drawing.Size(854, 426);
            this.splitContainer1.SplitterDistance = 169;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.UpdateBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.UpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdateBtn.Location = new System.Drawing.Point(721, 133);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(127, 30);
            this.UpdateBtn.TabIndex = 1;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.UpdateBtn.UseVisualStyleBackColor = false;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.31455F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.68545F));
            this.tableLayoutPanel1.Controls.Add(this.UserNameTextLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.userNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.positionLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.permissionsLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.PositionsComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(844, 129);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // UserNameTextLabel
            // 
            this.UserNameTextLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserNameTextLabel.AutoSize = true;
            this.UserNameTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTextLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UserNameTextLabel.Location = new System.Drawing.Point(140, 13);
            this.UserNameTextLabel.Name = "UserNameTextLabel";
            this.UserNameTextLabel.Size = new System.Drawing.Size(85, 17);
            this.UserNameTextLabel.TabIndex = 3;
            this.UserNameTextLabel.Text = "USERNAME";
            // 
            // userNameLabel
            // 
            this.userNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userNameLabel.Location = new System.Drawing.Point(3, 13);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(98, 17);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "USERNAME:";
            // 
            // positionLabel
            // 
            this.positionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.positionLabel.AutoSize = true;
            this.positionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.positionLabel.Location = new System.Drawing.Point(3, 56);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(86, 17);
            this.positionLabel.TabIndex = 1;
            this.positionLabel.Text = "POSITION:";
            // 
            // permissionsLabel
            // 
            this.permissionsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.permissionsLabel.AutoSize = true;
            this.permissionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permissionsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.permissionsLabel.Location = new System.Drawing.Point(3, 99);
            this.permissionsLabel.Name = "permissionsLabel";
            this.permissionsLabel.Size = new System.Drawing.Size(117, 17);
            this.permissionsLabel.TabIndex = 2;
            this.permissionsLabel.Text = "PERMISSIONS:";
            // 
            // PositionsComboBox
            // 
            this.PositionsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PositionsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionsComboBox.FormattingEnabled = true;
            this.PositionsComboBox.Location = new System.Drawing.Point(140, 46);
            this.PositionsComboBox.Name = "PositionsComboBox";
            this.PositionsComboBox.Size = new System.Drawing.Size(701, 28);
            this.PositionsComboBox.TabIndex = 4;
            this.PositionsComboBox.SelectedIndexChanged += new System.EventHandler(this.PositionsComboBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CanDeleteCheckBox);
            this.panel1.Controls.Add(this.CanUpdateCheckBox);
            this.panel1.Controls.Add(this.CanCreateCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(140, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 37);
            this.panel1.TabIndex = 5;
            // 
            // CanDeleteCheckBox
            // 
            this.CanDeleteCheckBox.AutoSize = true;
            this.CanDeleteCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CanDeleteCheckBox.Location = new System.Drawing.Point(291, 9);
            this.CanDeleteCheckBox.Name = "CanDeleteCheckBox";
            this.CanDeleteCheckBox.Size = new System.Drawing.Size(97, 19);
            this.CanDeleteCheckBox.TabIndex = 2;
            this.CanDeleteCheckBox.Text = "Can Delete";
            this.CanDeleteCheckBox.UseVisualStyleBackColor = true;
            this.CanDeleteCheckBox.CheckedChanged += new System.EventHandler(this.CanDeleteCheckBox_CheckedChanged);
            // 
            // CanUpdateCheckBox
            // 
            this.CanUpdateCheckBox.AutoSize = true;
            this.CanUpdateCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CanUpdateCheckBox.Location = new System.Drawing.Point(140, 9);
            this.CanUpdateCheckBox.Name = "CanUpdateCheckBox";
            this.CanUpdateCheckBox.Size = new System.Drawing.Size(101, 19);
            this.CanUpdateCheckBox.TabIndex = 1;
            this.CanUpdateCheckBox.Text = "Can Update";
            this.CanUpdateCheckBox.UseVisualStyleBackColor = true;
            this.CanUpdateCheckBox.CheckedChanged += new System.EventHandler(this.CanUpdateCheckBox_CheckedChanged);
            // 
            // CanCreateCheckBox
            // 
            this.CanCreateCheckBox.AutoSize = true;
            this.CanCreateCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CanCreateCheckBox.Location = new System.Drawing.Point(5, 9);
            this.CanCreateCheckBox.Name = "CanCreateCheckBox";
            this.CanCreateCheckBox.Size = new System.Drawing.Size(97, 19);
            this.CanCreateCheckBox.TabIndex = 0;
            this.CanCreateCheckBox.Text = "Can Create";
            this.CanCreateCheckBox.UseVisualStyleBackColor = true;
            this.CanCreateCheckBox.CheckedChanged += new System.EventHandler(this.CanCreateCheckBox_CheckedChanged);
            // 
            // UserDetailsCardDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(878, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserDetailsCardDialogForm";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Access";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label UserNameTextLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Label permissionsLabel;
        private System.Windows.Forms.ComboBox PositionsComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CanDeleteCheckBox;
        private System.Windows.Forms.CheckBox CanUpdateCheckBox;
        private System.Windows.Forms.CheckBox CanCreateCheckBox;
    }
}