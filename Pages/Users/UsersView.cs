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
using Serilog;
using smpc_admin.Models;

namespace smpc_admin.Pages.Users
{
    public partial class UsersView : UserControl
    {

        private List<UserModel> _users;
        private List<PositionModel> _positions;
        public UsersView()
        {
            InitializeComponent();
            LoadUsers();
            LoadPositions();
            UsersDataGridView.CellDoubleClick += UsersDataGridView_CellDoubleClick;

        }


        private async void LoadUsers()
        {
            try
            {
                var res = await UserService.GetUsersAsync();

                if (res != null && res.Success)
                {
                    var users = res.Data.ToList();
                    _users = users;

                    PopulateGrid(users);

                }

            }catch(Exception ex)
            {

            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            var text = SearchTextbox.Text.ToLower();

            List<UserModel> filtered;

            if (text == "")
            {
                filtered = _users.ToList();
            }
            else
            {
               filtered = _users.Where(u => u.FirstName.ToLower().Contains(text) || u.LastName.ToLower().Contains(text)).ToList();
            }


            PopulateGrid(filtered);

        }

        private void PopulateGrid(List<UserModel> users)
        {
            UsersDataGridView.Rows.Clear();

            foreach (var user in users)
            {
                var position = user.Position;
                var permissions = user.Permissions;

                string permissionString = "";

                if (permissions != null)
                {
                    if (permissions.CanCreate)
                        permissionString += "Create ";

                    if (permissions.CanUpdate)
                        permissionString += "Update ";

                    if (permissions.CanDelete)
                        permissionString += "Delete ";
                }

                UsersDataGridView.Rows.Add(
                    user.EmployeeId,
                    user.FirstName,
                    user.LastName,
                    position?.Name ?? "N/A",
                    user.Department ?? "N/A",
                    permissionString
                );
            }
        }



        private async void LoadPositions()
        {
            try
            {
                var res = await PositionService.GetAllPositionAsync();

                if (res != null && res.Success)
                {
                    _positions = res.Data;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"[ERROR] Loading positions: {ex.Message}");
            }
          
        }

        private void UsersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string employeeId = UsersDataGridView.Rows[e.RowIndex].Cells[0].Value?.ToString();

            var selectedUser = _users.FirstOrDefault(u => u.EmployeeId == employeeId);

            if (selectedUser != null)
            {
                var detailsForm = new UserDetailsForm(selectedUser, _positions);

                detailsForm.UpdateSuccess += (user) =>
                {
                    _users = _users.Where(u => u.Id != user.Id).ToList();

                    _users.Add(user);

                    PopulateGrid(_users);
                };

                detailsForm.DeleteSuccess += (id) =>
                {
                    _users = _users.Where(u => u.Id != id).ToList();

                    PopulateGrid(_users);
                };

                detailsForm.ShowDialog();
            }

            
        }

        private void NewUserBtn_Click(object sender, EventArgs e)
        {
            var createDialog = new CreateUserForm(_positions);
     

            createDialog.CreateSuccess += (user) => {
                _users.Add(user);
                PopulateGrid(_users);
            };

            createDialog.ShowDialog();

        }
    }
}
