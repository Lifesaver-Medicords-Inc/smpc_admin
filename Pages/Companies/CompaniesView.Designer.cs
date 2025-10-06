
namespace smpc_admin.Pages.Companies
{
    partial class CompaniesView
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
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.CompanyDataGridView = new System.Windows.Forms.DataGridView();
            this.CompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.NewCompanyBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "COMPANIES";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 832);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // CompanyDataGridView
            // 
            this.CompanyDataGridView.AllowUserToAddRows = false;
            this.CompanyDataGridView.AllowUserToDeleteRows = false;
            this.CompanyDataGridView.AllowUserToResizeColumns = false;
            this.CompanyDataGridView.AllowUserToResizeRows = false;
            this.CompanyDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CompanyDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.CompanyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompanyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyCode,
            this.CompanyName,
            this.Id});
            this.CompanyDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CompanyDataGridView.Location = new System.Drawing.Point(3, 114);
            this.CompanyDataGridView.Name = "CompanyDataGridView";
            this.CompanyDataGridView.ReadOnly = true;
            this.CompanyDataGridView.RowHeadersVisible = false;
            this.CompanyDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CompanyDataGridView.Size = new System.Drawing.Size(1101, 742);
            this.CompanyDataGridView.TabIndex = 2;
            this.CompanyDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CompanyDataGridView_CellDoubleClick);
            // 
            // CompanyCode
            // 
            this.CompanyCode.HeaderText = "COMPANY CODE";
            this.CompanyCode.Name = "CompanyCode";
            this.CompanyCode.ReadOnly = true;
            // 
            // CompanyName
            // 
            this.CompanyName.HeaderText = "COMPANY NAME";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 90);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1101, 90);
            this.panel2.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.NewCompanyBtn);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 54);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1101, 36);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // NewCompanyBtn
            // 
            this.NewCompanyBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.NewCompanyBtn.Location = new System.Drawing.Point(3, 3);
            this.NewCompanyBtn.Name = "NewCompanyBtn";
            this.NewCompanyBtn.Size = new System.Drawing.Size(223, 30);
            this.NewCompanyBtn.TabIndex = 5;
            this.NewCompanyBtn.Text = "New Entries";
            this.NewCompanyBtn.UseVisualStyleBackColor = true;
            this.NewCompanyBtn.Click += new System.EventHandler(this.NewCompanyBtn_Click);
            // 
            // CompaniesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CompanyDataGridView);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label1);
            this.Name = "CompaniesView";
            this.Size = new System.Drawing.Size(1104, 856);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView CompanyDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button NewCompanyBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}
