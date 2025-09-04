
namespace smpc_admin.Pages.Users
{
    partial class UsersView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HeaderSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.InputSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SearchTextbox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NewUserBtn = new System.Windows.Forms.Button();
            this.UsersDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.UsersViewSplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderSplitContainer)).BeginInit();
            this.HeaderSplitContainer.Panel1.SuspendLayout();
            this.HeaderSplitContainer.Panel2.SuspendLayout();
            this.HeaderSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputSplitContainer)).BeginInit();
            this.InputSplitContainer.Panel1.SuspendLayout();
            this.InputSplitContainer.Panel2.SuspendLayout();
            this.InputSplitContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersViewSplitContainer)).BeginInit();
            this.UsersViewSplitContainer.Panel1.SuspendLayout();
            this.UsersViewSplitContainer.Panel2.SuspendLayout();
            this.UsersViewSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer.IsSplitterFixed = true;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SplitContainer.Panel1.Controls.Add(this.panel1);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.UsersDataGridView);
            this.SplitContainer.Size = new System.Drawing.Size(969, 832);
            this.SplitContainer.SplitterDistance = 77;
            this.SplitContainer.SplitterWidth = 2;
            this.SplitContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.HeaderSplitContainer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 77);
            this.panel1.TabIndex = 0;
            // 
            // HeaderSplitContainer
            // 
            this.HeaderSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.HeaderSplitContainer.Name = "HeaderSplitContainer";
            // 
            // HeaderSplitContainer.Panel1
            // 
            this.HeaderSplitContainer.Panel1.Controls.Add(this.SearchLabel);
            this.HeaderSplitContainer.Panel1.Controls.Add(this.InputSplitContainer);
            this.HeaderSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            // 
            // HeaderSplitContainer.Panel2
            // 
            this.HeaderSplitContainer.Panel2.Controls.Add(this.panel2);
            this.HeaderSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 40, 0, 10);
            this.HeaderSplitContainer.Size = new System.Drawing.Size(969, 77);
            this.HeaderSplitContainer.SplitterDistance = 627;
            this.HeaderSplitContainer.TabIndex = 0;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchLabel.Location = new System.Drawing.Point(0, 10);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(53, 17);
            this.SearchLabel.TabIndex = 0;
            this.SearchLabel.Text = "Search";
            // 
            // InputSplitContainer
            // 
            this.InputSplitContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InputSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.InputSplitContainer.Location = new System.Drawing.Point(0, 32);
            this.InputSplitContainer.Name = "InputSplitContainer";
            // 
            // InputSplitContainer.Panel1
            // 
            this.InputSplitContainer.Panel1.Controls.Add(this.SearchTextbox);
            this.InputSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 5, 5, 2);
            // 
            // InputSplitContainer.Panel2
            // 
            this.InputSplitContainer.Panel2.Controls.Add(this.SearchBtn);
            this.InputSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.InputSplitContainer.Size = new System.Drawing.Size(627, 35);
            this.InputSplitContainer.SplitterDistance = 521;
            this.InputSplitContainer.TabIndex = 0;
            // 
            // SearchTextbox
            // 
            this.SearchTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextbox.Location = new System.Drawing.Point(0, 5);
            this.SearchTextbox.Name = "SearchTextbox";
            this.SearchTextbox.Size = new System.Drawing.Size(516, 24);
            this.SearchTextbox.TabIndex = 1;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.Location = new System.Drawing.Point(0, 3);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(102, 30);
            this.SearchBtn.TabIndex = 2;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.NewUserBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(338, 30);
            this.panel2.TabIndex = 0;
            // 
            // NewUserBtn
            // 
            this.NewUserBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.NewUserBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.NewUserBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewUserBtn.Location = new System.Drawing.Point(234, 0);
            this.NewUserBtn.Name = "NewUserBtn";
            this.NewUserBtn.Size = new System.Drawing.Size(104, 30);
            this.NewUserBtn.TabIndex = 3;
            this.NewUserBtn.Text = "New user";
            this.NewUserBtn.UseVisualStyleBackColor = false;
            this.NewUserBtn.Click += new System.EventHandler(this.NewUserBtn_Click);
            // 
            // UsersDataGridView
            // 
            this.UsersDataGridView.AllowUserToAddRows = false;
            this.UsersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UsersDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.UsersDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UsersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.UsersDataGridView.Name = "UsersDataGridView";
            this.UsersDataGridView.ReadOnly = true;
            this.UsersDataGridView.RowHeadersVisible = false;
            this.UsersDataGridView.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4);
            this.UsersDataGridView.RowTemplate.Height = 25;
            this.UsersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UsersDataGridView.ShowEditingIcon = false;
            this.UsersDataGridView.Size = new System.Drawing.Size(969, 753);
            this.UsersDataGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "USERS";
            // 
            // UsersViewSplitContainer
            // 
            this.UsersViewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersViewSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.UsersViewSplitContainer.IsSplitterFixed = true;
            this.UsersViewSplitContainer.Location = new System.Drawing.Point(4, 4);
            this.UsersViewSplitContainer.Name = "UsersViewSplitContainer";
            this.UsersViewSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // UsersViewSplitContainer.Panel1
            // 
            this.UsersViewSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.UsersViewSplitContainer.Panel1.Controls.Add(this.label1);
            // 
            // UsersViewSplitContainer.Panel2
            // 
            this.UsersViewSplitContainer.Panel2.Controls.Add(this.SplitContainer);
            this.UsersViewSplitContainer.Size = new System.Drawing.Size(969, 867);
            this.UsersViewSplitContainer.SplitterDistance = 31;
            this.UsersViewSplitContainer.TabIndex = 1;
            // 
            // UsersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UsersViewSplitContainer);
            this.Name = "UsersView";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(977, 875);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.HeaderSplitContainer.Panel1.ResumeLayout(false);
            this.HeaderSplitContainer.Panel1.PerformLayout();
            this.HeaderSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderSplitContainer)).EndInit();
            this.HeaderSplitContainer.ResumeLayout(false);
            this.InputSplitContainer.Panel1.ResumeLayout(false);
            this.InputSplitContainer.Panel1.PerformLayout();
            this.InputSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputSplitContainer)).EndInit();
            this.InputSplitContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).EndInit();
            this.UsersViewSplitContainer.Panel1.ResumeLayout(false);
            this.UsersViewSplitContainer.Panel1.PerformLayout();
            this.UsersViewSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UsersViewSplitContainer)).EndInit();
            this.UsersViewSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer HeaderSplitContainer;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.TextBox SearchTextbox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Button NewUserBtn;
        private System.Windows.Forms.SplitContainer InputSplitContainer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer UsersViewSplitContainer;
        private System.Windows.Forms.DataGridView UsersDataGridView;
    }
}
