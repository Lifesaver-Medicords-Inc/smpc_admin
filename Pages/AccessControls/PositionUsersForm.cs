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
using Serilog;

namespace smpc_admin.Pages.AccessControls
{
    public partial class PositionUsersForm : UserControl
    {

    
        public PositionUsersForm()
        {
            InitializeComponent();
            UsersFlowLayoutPanel.Resize += UsersFlowLayoutPanel_Resize;
        }


        public async Task LoadPositionUsersAsync(int positionId)
        {
            try
            {

               LoaderIndicatorOverlay.ShowOverlay();

                var res = await UserWithPositionService.GetAllUsersInPositionAsync(positionId);

                if (res?.Success == true)
                {
                   var users = res.Data
                        .Select(u => new UserModel
                        {
                            Id = u.Id,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            PositionId = u.PositionId
                        }).ToList();
                    LoadUsersList(users);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"[ERROR] Loading position users: {ex.Message}");
            }
            finally
            {
             LoaderIndicatorOverlay.HideOverlay();
            }
        }

        public void LoadUsersList(List<UserModel> users)
        {
            UsersFlowLayoutPanel.Controls.Clear();
            UsersFlowLayoutPanel.PerformLayout();
            UsersFlowLayoutPanel.Invalidate();
            UsersFlowLayoutPanel.Refresh();

            if (!users.Any())
                return;

            foreach (var user in users)
            {
                AddUser(user);
            }

        }

        public void AddUser(UserModel user)
        {
            var row = new PositionUsersItemForm(user, true)
            {
                Width = UsersFlowLayoutPanel.ClientSize.Width,
                Tag = user.Id
            };

            row.UserClicked += (s, u) =>
            {
                ShowUserDetailsForm(u);
            };

            UsersFlowLayoutPanel.Controls.Add(row);
        }
 
        private void UsersFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in UsersFlowLayoutPanel.Controls)
            {
                ctrl.Width = UsersFlowLayoutPanel.ClientSize.Width - 10;
            }
        }

        public async void ShowUserDetailsForm(UserModel user)
        {
            var userDetailsDialog = new UserDetailsCardDialogForm(user);

            userDetailsDialog.UpdateSuccess += async(positionId) => {
                if (InvokeRequired)
                {
                    Invoke(new Action(async () =>
                    {
                        await LoadPositionUsersAsync(positionId);
                    }));
                }
                else
                {

                    await LoadPositionUsersAsync(positionId);
                    UsersFlowLayoutPanel.Refresh();
                }
            };

            await userDetailsDialog.LoadPositionsAsync();
            userDetailsDialog.ShowDialog();
        }



    }

}
