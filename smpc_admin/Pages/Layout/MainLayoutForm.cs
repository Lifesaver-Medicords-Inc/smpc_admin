using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using smpc_admin.Pages.Login;
using smpc_admin.Services;
using smpc_admin.Helpers;

namespace smpc_admin.Pages.Layout
{
    public partial class MainLayoutForm : Form
    {



        private int tabCount = 0;
        public MainLayoutForm()
        {
            InitializeComponent();
        }

        private void MainLayoutForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();

            if (DialogResult.OK == login.ShowDialog())
            {
                this.Enabled = true;
            }
            else
            {
                Application.Exit();
            }
        }




        public void showForm(string tabTitle, Control control)
        {
            tabCount++;
            Button closeButton = new Button();
            closeButton.Text = "X";
            closeButton.Size = new Size(20, 20);
            closeButton.Click += removeTab;
            closeButton.ForeColor = Color.Red;

            TabPage newTab = new TabPage(tabTitle);
            newTab.Controls.Add(closeButton);
            closeButton.Location = new Point(newTab.Width, 10); // Adjust position as needed

            //control.Width = this.Width - 235; 
            viewTabContainer.Height = this.Height * 2;
            //control.Height = this.Height;
            control.Width = this.Width - 550;
            newTab.Controls.Add(control);
            newTab.AutoScroll = true;
            viewTabContainer.TabPages.Add(newTab);
            viewTabContainer.SelectTab(newTab);
        }
        private void removeTab(object sender, EventArgs e)
        {
            viewTabContainer.TabPages.Remove(viewTabContainer.SelectedTab);
            //tabControl1.SelectTab();
        }


        private void Sidebar_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // || e.Node.Name.Contains("Sales Order") || e.Node.Name.Contains("Ship Type Setup") e.Node.Name.Contains("PURCHASE ORDER") ||
            if (e.Node.Name.Contains("DASHBOARD") || e.Node.Name.Contains("PURCHASE RETURN"))
            {
                Utils.ShowDialogMessage("error", "This module is not available at the moment!");
                return;
            }
            if (!e.Node.Name.Contains("parent"))
            {
                RoutesService route = new RoutesService(e.Node.Name);
                showForm(route.GetTitle(), route.GetForm());
            }
        }
    }
}
