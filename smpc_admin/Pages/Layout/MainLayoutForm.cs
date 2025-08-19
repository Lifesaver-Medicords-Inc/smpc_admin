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
using smpc_admin.Utils;
using smpc_admin.AccessControl;
using smpc_admin.Config;
using smpc_admin.Models;



namespace smpc_admin.Pages.Layout
{
    public partial class MainLayoutForm : Form
    {


        public MainLayoutForm()
        {
            InitializeComponent();
            PopulateNavigationTreeView();
            this.FormClosed += MainForm_FormClosed;
        }

        private void PopulateNavigationTreeView()
        {
            NavigationBarTreeView.Nodes.Clear();

            foreach (var item in NavigationConfig.Items)
            {
                if (!UserSession.HasAccess(item.Code)) continue;

                TreeNode parentNode = new TreeNode(item.Text)
                {
                    Name = item.Code
                };

                foreach (var child in item.Children)
                {
                  if (!UserSession.HasAccess(child.Code)) continue;

                    TreeNode childNode = new TreeNode(child.Text)
                    {
                        Name = child.Code
                    };

                    // If child has sub-children
                    foreach (var grandchild in child.Children)
                    {
                        if (!UserSession.HasAccess(grandchild.Code)) continue;

                        var grandchildNode = new TreeNode(grandchild.Text)
                        {
                            Name = grandchild.Code 
                        };
                        childNode.Nodes.Add(grandchildNode);
                    }
                    parentNode.Nodes.Add(childNode);
                }

                NavigationBarTreeView.Nodes.Add(parentNode);
            }

            NavigationBarTreeView.ExpandAll();

        }


        public void showForm(string tabTitle, Control control)
        {

            if (tabTitle == null || control == null) return;

            MainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(control);
        }
        private void removeTab(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
        }

        private void navigationBarTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var code = e.Node.Name;

             if (!UserSession.HasAccess(code)) return;

                RoutesService route = new RoutesService(e.Node.Name);
                showForm(route.GetTitle(), route.GetForm());
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
