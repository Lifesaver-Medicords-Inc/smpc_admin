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
using smpc_admin.Config;
using smpc_admin.Models;
using smpc_admin.Pages.Shared;



namespace smpc_admin.Pages.Layout
{
    public partial class MainLayoutForm : Form
    {


        public MainLayoutForm()
        {
            InitializeComponent();
            PopulateNavigationTreeView();
            this.FormClosed += MainForm_FormClosed;

            var redBoxForm = new RedBoxForm();
            MainViewPanel.Panel2.Controls.Clear();
            redBoxForm.Dock = DockStyle.Fill;
            MainViewPanel.Panel2.Controls.Add(redBoxForm);
        }

        private void PopulateNavigationTreeView()
        {
            NavigationBarTreeView.BeginUpdate();
            NavigationBarTreeView.Nodes.Clear();

            NavigationConfig.PopulateNavigationTree(NavigationBarTreeView.Nodes, NavigationConfig.Items);

            NavigationBarTreeView.ExpandAll();
            NavigationBarTreeView.EndUpdate();
        }



        public void showForm(string tabTitle, Control control)
        {

            if (tabTitle == null || control == null) return;

            MainViewPanel.Panel1.Controls.Clear();
            control.Dock = DockStyle.Fill;
            MainViewPanel.Panel1.Controls.Add(control);
        }
        private void removeTab(object sender, EventArgs e)
        {
            MainViewPanel.Panel1.Controls.Clear();
        }

        private void navigationBarTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var code = e.Node.Name;

             if (!SessionService.HasAccess(code)) return;

                RoutesService route = new RoutesService(e.Node.Name);
                showForm(route.GetTitle(), route.GetForm());
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
