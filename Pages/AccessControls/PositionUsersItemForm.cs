using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using smpc_admin.Models;

namespace smpc_admin.Pages.AccessControls
{
    public partial class PositionUsersItemForm : UserControl
    {

   
        public UserModel User { get; private set; }
        public PositionUsersItemForm(UserModel user, bool isActive = false)
        {
            InitializeComponent();

            User = user;
            UserNameLabel.Text = $"{user.FirstName} {user.LastName}";
            ActiveStatusLabel.Text = isActive ? "ACTIVE" : "INACTIVE";


            this.Click += OnItemClick;

        }


        private void OnItemClick(object sender, EventArgs e)
        {
           var userDetailsDialog = new UserDetailsCardDialogForm(User);

            userDetailsDialog.ShowDialog();
        }
    }
}
