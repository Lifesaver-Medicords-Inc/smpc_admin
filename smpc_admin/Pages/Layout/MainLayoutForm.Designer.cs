
namespace smpc_admin.Pages.Layout
{
    partial class MainLayoutForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("User Permissions");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Position Access");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Access Controls", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Positions");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Admin tools", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.navigationBarTreeView = new System.Windows.Forms.TreeView();
            this.viewTabContainer = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.navigationBarTreeView);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.viewTabContainer);
            this.mainSplitContainer.Size = new System.Drawing.Size(800, 450);
            this.mainSplitContainer.SplitterDistance = 182;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // navigationBarTreeView
            // 
            this.navigationBarTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationBarTreeView.Location = new System.Drawing.Point(0, 0);
            this.navigationBarTreeView.Name = "navigationBarTreeView";
            treeNode1.Name = "ADMIN USER PERMISSION";
            treeNode1.Text = "User Permissions";
            treeNode2.Name = "ADMIN POSITION ACCESS";
            treeNode2.Text = "Position Access";
            treeNode3.Name = "accessControl";
            treeNode3.Text = "Access Controls";
            treeNode4.Name = "ADMIN POSITION";
            treeNode4.Text = "Positions";
            treeNode5.Name = "ADMIN TOOLS";
            treeNode5.Text = "Admin tools";
            this.navigationBarTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.navigationBarTreeView.Size = new System.Drawing.Size(182, 450);
            this.navigationBarTreeView.TabIndex = 0;
            // 
            // viewTabContainer
            // 
            this.viewTabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewTabContainer.Location = new System.Drawing.Point(0, 0);
            this.viewTabContainer.Name = "viewTabContainer";
            this.viewTabContainer.SelectedIndex = 0;
            this.viewTabContainer.Size = new System.Drawing.Size(614, 450);
            this.viewTabContainer.TabIndex = 0;
            // 
            // MainLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "MainLayoutForm";
            this.Text = "SMPC Admin";
            this.Load += new System.EventHandler(this.MainLayoutForm_Load);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.TreeView navigationBarTreeView;
        private System.Windows.Forms.TabControl viewTabContainer;
    }
}