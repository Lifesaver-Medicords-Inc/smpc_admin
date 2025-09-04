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

namespace smpc_admin.Pages.Users
{
    public partial class UserDetailsForm : Form
    {

        private UserModel _user;
        private List<PositionModel> _positions;
        public Action<UserModel> UpdateSuccess;
        public Action<int> DeleteSuccess;
        private bool _isLoading = true;

        public UserDetailsForm(UserModel user, List<PositionModel> positions)
        {
            InitializeComponent();
            _user = user;
            _positions = positions;
            LoadUser(user);
        }



        private void UserDetailsForm_Load(object sender, EventArgs e)
        {

            PositionsComboBox.DataSource = _positions;
            PositionsComboBox.DisplayMember = "Name";
            PositionsComboBox.ValueMember = "Id";

          
            if (_positions.Any(p => p.Id == _user.PositionId))
            {
                PositionsComboBox.SelectedValue = _user.PositionId;
            }


        
            var departments = Utils.Departments.List;
            DepartmentComboBox.DataSource = departments;


            if (!string.IsNullOrWhiteSpace(_user.Department))
            {
                var match = departments.FirstOrDefault(d =>
                    d.Equals(_user.Department.Trim(), StringComparison.OrdinalIgnoreCase));
                if (match != null)
                    DepartmentComboBox.SelectedItem = match;
            }

  
     
            FirstNameTextBox.Text = _user.FirstName;
            LastNameTextBox.Text = _user.LastName;

            _isLoading = false;
        }

        private void LoadUser(UserModel user)
        {
            FirstNameTextBox.Text = user.FirstName;
            LastNameTextBox.Text = user.LastName;
    

            if (user.Permissions != null)
            {
                CanCreateCheckBox.Checked = user.Permissions.CanCreate;
                CanUpdateCheckBox.Checked = user.Permissions.CanUpdate;
                CanDeleteCheckBox.Checked = user.Permissions.CanDelete;
            }
        }

        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {

                _user.FirstName = FirstNameTextBox.Text;
                _user.LastName = LastNameTextBox.Text;
   
                var res = await UserService.UpdateUserAsync(_user);

                await UserService.UpdatePermissionAsync(_user.Permissions);

                if (res != null && res.Success && res.Data != null)
                {
                    UpdateSuccess?.Invoke(res.Data);
                    this.Close();
                }
            }catch(Exception ex)
            {
                Utils.Helpers.ShowDialogMessage("Failed to update user");
            }
        }

        private async void RemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {

                var res = await UserService.DeleteUserAsync(_user.Id);

                if(res != null && res.Success)
                {
                    DeleteSuccess?.Invoke(_user.Id);
                    this.Close();
                }

            }catch(Exception ex)
            {
                Utils.Helpers.ShowDialogMessage("Failed to remove user");
            }
        }



        private void PositionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;

            if (PositionsComboBox.SelectedItem is PositionModel selected)
            {
                _user.PositionId = selected.Id;
            }
        }

        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            if (DepartmentComboBox.SelectedItem is string selected)
            {
                _user.Department = DepartmentComboBox.SelectedItem as string;
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


    }
}

