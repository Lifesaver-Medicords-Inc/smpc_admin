
namespace smpc_admin.Pages.AccessControls
{
    partial class AccessControlView
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
            this.AccessViewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.TopSplitContainer = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AccessViewSplitContainer)).BeginInit();
            this.AccessViewSplitContainer.Panel1.SuspendLayout();
            this.AccessViewSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopSplitContainer)).BeginInit();
            this.TopSplitContainer.Panel1.SuspendLayout();
            this.TopSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // AccessViewSplitContainer
            // 
            this.AccessViewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccessViewSplitContainer.Location = new System.Drawing.Point(4, 4);
            this.AccessViewSplitContainer.Name = "AccessViewSplitContainer";
            this.AccessViewSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // AccessViewSplitContainer.Panel1
            // 
            this.AccessViewSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AccessViewSplitContainer.Panel1.Controls.Add(this.TopSplitContainer);
            // 
            // AccessViewSplitContainer.Panel2
            // 
            this.AccessViewSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AccessViewSplitContainer.Size = new System.Drawing.Size(722, 626);
            this.AccessViewSplitContainer.SplitterDistance = 280;
            this.AccessViewSplitContainer.SplitterWidth = 1;
            this.AccessViewSplitContainer.TabIndex = 0;
            // 
            // TopSplitContainer
            // 
            this.TopSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.TopSplitContainer.IsSplitterFixed = true;
            this.TopSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.TopSplitContainer.Name = "TopSplitContainer";
            this.TopSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // TopSplitContainer.Panel1
            // 
            this.TopSplitContainer.Panel1.Controls.Add(this.label1);
            this.TopSplitContainer.Size = new System.Drawing.Size(722, 280);
            this.TopSplitContainer.SplitterDistance = 40;
            this.TopSplitContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ACCESS CONTROL";
            // 
            // AccessControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AccessViewSplitContainer);
            this.Name = "AccessControlView";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(730, 634);
            this.AccessViewSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AccessViewSplitContainer)).EndInit();
            this.AccessViewSplitContainer.ResumeLayout(false);
            this.TopSplitContainer.Panel1.ResumeLayout(false);
            this.TopSplitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopSplitContainer)).EndInit();
            this.TopSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer AccessViewSplitContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer TopSplitContainer;
    }
}
