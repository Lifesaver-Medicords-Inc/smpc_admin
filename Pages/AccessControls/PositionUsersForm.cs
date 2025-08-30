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

        private List<UserModel> _users;
        private List<PositionModel> _positions;
        private PositionAccessForm _positionAccessForm;
    
        public PositionUsersForm()
        {
            InitializeComponent();
            UsersFlowLayoutPanel.Resize += UsersFlowLayoutPanel_Resize;
            _positionAccessForm = new PositionAccessForm();
        }


        public void SetPositions(List<PositionModel> positions)
        {
            _positions = positions;
        }

        public async Task LoadPositionUsersAsync(int positionId)
        {
            try
            {

                var res = await UserWithPositionService.GetAllUsersInPositionAsync(positionId);

                if (res?.Success == true)
                {
                  _users = res.Data
                        .Select(u => new UserModel
                        {
                            Id = u.Id,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            PositionId = u.PositionId
                        }).ToList();
                    LoadUsersList(_users);
                }
                else
                {
                    RemoveUsers();
                }
            }
            catch (Exception ex)
            {
                Log.Error($"[ERROR] Loading position users: {ex.Message}");
                RemoveUsers();
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
 
        public void RemoveUser(int id)
        {
            _users = _users.Where(u => u.Id != id).ToList();
            LoadUsersList(_users);
        }

        public void RemoveUsers()
        {
            _users = new List<UserModel>();
            UsersFlowLayoutPanel.Controls.Clear();

        }

        private void UsersFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in UsersFlowLayoutPanel.Controls)
            {
                ctrl.Width = UsersFlowLayoutPanel.ClientSize.Width - 10;
            }
        }

        public  void ShowUserDetailsForm(UserModel user)
        {
            var userDetailsDialog = new UserDetailsCardDialogForm(user, _positionAccessForm);

            userDetailsDialog.UpdateSuccess += (id) => { RemoveUser(id); };
            userDetailsDialog.ShowDialog();
        }



    }

}
