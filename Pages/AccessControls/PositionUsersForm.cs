using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using smpc_admin.Services;
using smpc_admin.Models;
using smpc_admin.Pages.Shared;

namespace smpc_admin.Pages.AccessControls
{
    public partial class PositionUsersForm : UserControl
    {
        public PositionUsersForm()
        {
            InitializeComponent();
            UsersFlowLayoutPanel.Resize += UsersFlowLayoutPanel_Resize;
           
        }


       public async void LoadPositonUsers(int positionId)
        {
            try
            {
                LoaderIndicatorOverlay.ShowOverlay();

                var res = await UserWithPositionService.GetAllUsersInPositionAsync(positionId);

                if(res != null && res.Success)
                {
                    var users = res.Data
                        .Select(u => new UserModel 
                        { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, PositionId = u.PositionId
                        }).ToList();


                    UsersFlowLayoutPanel.Controls.Clear();

                    foreach(var user in users)
                    {

                        var row = new PositionUsersItemForm(user, true);

                        UsersFlowLayoutPanel.Controls.Add(row);

                    }
                    
                }

            }
            catch(Exception ex)
            {

            }
            finally
            {
                LoaderIndicatorOverlay.HideOverlay();
            }
        }

        private void UsersFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in UsersFlowLayoutPanel.Controls)
            {
                ctrl.Width = UsersFlowLayoutPanel.ClientSize.Width - 10;
            }
        }
    }
}
