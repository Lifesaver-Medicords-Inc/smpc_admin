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
using smpc_admin.Services;
using smpc_admin.Utils;

namespace smpc_admin.Pages.Users
{
    public partial class CreateUserForm : Form
    {
        private UserModel _user = new UserModel();
        public event Action<UserModel> CreateSuccess;
        private string _selectedPositionName;
        public CreateUserForm(List<PositionModel> positions)
        {
            InitializeComponent();


            _user.Permissions = new UserPermissionModel
            {
                CanCreate = false,
                CanDelete = false,
                CanUpdate = false,
            };

            _user.Position = new PositionModel();

            var emptyOption = new PositionModel
            {
                Id = -0,
                Name = "-- Select Position --"
            };

            var mapPositions = positions.Select(a => new PositionModel { Name = a.Name, Id = a.Id }).ToList();

            mapPositions.Insert(0, emptyOption);

            PositionsComboBox.DataSource = mapPositions;
            PositionsComboBox.DisplayMember = "Name";
            PositionsComboBox.ValueMember = "Id";



            DepartmentComboBox.DataSource = Utils.Departments.List;
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {

            try
            {
                _user.FirstName = FirstNameTextBox.Text;
                _user.LastName = LastNameTextBox.Text;
                _user.Password = PasswordTextBox.Text;
  

                var res = await UserService.CreateUserAsync(_user);

                if (res != null && res.Success)
                {
                    var data = res.Data;

                    _user.Permissions.UserId = data.Id;
                    _user.Position.Name = _selectedPositionName;
                    _user.Position.Id = _user.PositionId;

                    await UserService.CreateUserPermissionAsync(_user.Permissions);

                    CreateSuccess?.Invoke(_user);

                    this.Close();

                }

            } catch (Exception ex)
            {
                Utils.Helpers.ShowDialogMessage("Failed to create user");
            }
         
        }

        private void PositionsComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (PositionsComboBox.SelectedItem is PositionModel selected)
            {
                _user.PositionId = selected.Id;
                _selectedPositionName = selected.Name;
            }
        }

        private void CanCreateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox cb)
                _user.Permissions.CanCreate = cb.Checked;
        }

        private void CanUpdateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox cb)
                _user.Permissions.CanUpdate = cb.Checked;
        }

   

        private void CanDeleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox cb)
                _user.Permissions.CanDelete = cb.Checked;
        }

        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           _user.Department = DepartmentComboBox.SelectedItem as string;
        }
    }
}
