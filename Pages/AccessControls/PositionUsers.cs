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
    public partial class PositionUsers : UserControl
    {

        private List<UserModel> _users;
        private List<PositionModel> _positions;
        private PositionAccess _positionAccessForm;
    
        public PositionUsers()
        {
            InitializeComponent();
            _positionAccessForm = new PositionAccess();

            UsersDataGridView.Columns.Clear();

            UsersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UserName",
                HeaderText = "", // No header
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            UsersDataGridView.CellDoubleClick += UsersDataGridView_CellDoubleClick;
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

                if (res != null && res.Success)
                {
                  _users = res.Data
                        .Select(u => new UserModel
                        {
                            Id = u.Id,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            PositionId = u.PositionId,
                            Permissions = u.Permissions
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

            if (!users.Any())
                return;

            foreach (var user in users)
            {
                AddUser(user);
            }

        }

       
        public void AddUser(UserModel user)
        {
            int rowIndex = UsersDataGridView.Rows.Add($"{user.FirstName} {user.LastName}");
            UsersDataGridView.Rows[rowIndex].Tag = user; 
        }

        public void RemoveUser(int id)
        {
            _users = _users.Where(u => u.Id != id).ToList();
            LoadUsersList(_users);
        }

        public void RemoveUsers()
        {
            _users = new List<UserModel>();
            UsersDataGridView.Controls.Clear();

        }

        private void UsersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = UsersDataGridView.Rows[e.RowIndex];
                if (row.Tag is UserModel user)
                {
                    var userDetailsDialog = new UserDetailsCardDialogForm(user, _positionAccessForm);

                    userDetailsDialog.UpdateSuccess += (id) => { RemoveUser(id); };
                    userDetailsDialog.ShowDialog();
                }
            }
        }

    }

}
