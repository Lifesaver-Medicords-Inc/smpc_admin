
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
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.NavigationBarTreeView = new System.Windows.Forms.TreeView();
            this.MainViewPanel = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainViewPanel)).BeginInit();
            this.MainViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.NavigationBarTreeView);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.MainViewPanel);
            this.mainSplitContainer.Size = new System.Drawing.Size(1122, 874);
            this.mainSplitContainer.SplitterDistance = 182;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // NavigationBarTreeView
            // 
            this.NavigationBarTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NavigationBarTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavigationBarTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavigationBarTreeView.Location = new System.Drawing.Point(0, 0);
            this.NavigationBarTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.NavigationBarTreeView.Name = "NavigationBarTreeView";
            this.NavigationBarTreeView.Size = new System.Drawing.Size(182, 874);
            this.NavigationBarTreeView.TabIndex = 0;
            this.NavigationBarTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.navigationBarTreeView_AfterSelect);
            // 
            // MainViewPanel
            // 
            this.MainViewPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MainViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainViewPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainViewPanel.Location = new System.Drawing.Point(0, 0);
            this.MainViewPanel.Name = "MainViewPanel";
            this.MainViewPanel.Size = new System.Drawing.Size(936, 874);
            this.MainViewPanel.SplitterDistance = 647;
            this.MainViewPanel.TabIndex = 0;
            // 
            // MainLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 874);
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "MainLayoutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMPC Admin";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainViewPanel)).EndInit();
            this.MainViewPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.TreeView NavigationBarTreeView;
        private System.Windows.Forms.SplitContainer MainViewPanel;
    }
}