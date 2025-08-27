
namespace smpc_admin.Pages.AccessControls
{
    partial class AccessControlForm
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
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.TopSplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopSplitContainer)).BeginInit();
            this.TopSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.TopSplitContainer);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainSplitContainer.Size = new System.Drawing.Size(1235, 906);
            this.mainSplitContainer.SplitterDistance = 409;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // TopSplitContainer
            // 
            this.TopSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.TopSplitContainer.Name = "TopSplitContainer";
            // 
            // TopSplitContainer.Panel1
            // 
            this.TopSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            // 
            // TopSplitContainer.Panel2
            // 
            this.TopSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TopSplitContainer.Size = new System.Drawing.Size(1235, 409);
            this.TopSplitContainer.SplitterDistance = 541;
            this.TopSplitContainer.TabIndex = 0;
            // 
            // AccessControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "AccessControlForm";
            this.Size = new System.Drawing.Size(1235, 906);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopSplitContainer)).EndInit();
            this.TopSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.SplitContainer TopSplitContainer;
    }
}
