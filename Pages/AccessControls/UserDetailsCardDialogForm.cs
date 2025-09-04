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
using Serilog;
using smpc_admin.Pages.Shared;
using smpc_admin.Pages.Layout;

namespace smpc_admin.Pages.AccessControls
{
    public partial class UserDetailsCardDialogForm : Form
    {
        private UserPermissionModel _permission;
        private readonly UserModel _user;
        public event Action<int> UpdateSuccess;

  
        private int _newPositionId = 0;
        public UserDetailsCardDialogForm(UserModel user, PositionAccess positionAccessForm)
        {
            InitializeComponent();
            _user = user;
            _permission = user.Permissions;

            if(_permission != null)
            {
                 CanCreateCheckBox.Checked = _permission.CanCreate;
                 CanUpdateCheckBox.Checked = _permission.CanUpdate;
                 CanDeleteCheckBox.Checked = _permission.CanDelete;
            }

            UserNameTextLabel.Text = $"{user.FirstName} {user.LastName}";

            PositionsComboBox.DataSource = positionAccessForm.positions;
            PositionsComboBox.DisplayMember = "Name";
            PositionsComboBox.ValueMember = "Id";

            int index = positionAccessForm.positions.FindIndex(p => p.Id == _user.PositionId);
            if (index != -1)
            {
                PositionsComboBox.SelectedIndex = index;
            }

        }


        private Control FindControlRecursive(Control parent, string name)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Name == name)
                    return ctrl;

                var found = FindControlRecursive(ctrl, name);
                if (found != null)
                    return found;
            }

            return null;
        }


        private void PositionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PositionsComboBox.SelectedItem is PositionModel selected)
            {
                _newPositionId = selected.Id;
            }
        }

        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            await UpdatePositionAsync();
            await UpdatePermissionsAsync();
        }

        private async Task UpdatePositionAsync()
        {
            try
            {

                if (_user.PositionId == _newPositionId || _newPositionId < 1) return;

                var res = await UserWithPositionService.UpdateUserPositionAsync(new UserModel
                {
                    Id = _user.Id,
                    PositionId = _newPositionId
                });

               

                if (res != null && res.Success)
                {
                    this.Close();
                    UpdateSuccess?.Invoke(_user.Id);
                }
     
            }
            catch (Exception ex)
            {
                Log.Error($"[ERROR] Updating position: {ex.Message}");
            }
          
        }

        private async Task UpdatePermissionsAsync()
        {

            if (_permission == null)
                return;

            try
            {
                await UserService.UpdatePermissionAsync(_permission);
            }
            catch (Exception ex)
            {
               Log.Error($"[ERROR] Updating permissions: {ex.Message}");
            }
          
        }

        private void CanCreateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_permission != null && sender is CheckBox cb)
                _permission.CanCreate = cb.Checked;
        }

        private void CanUpdateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_permission != null && sender is CheckBox cb)
                _permission.CanUpdate = cb.Checked;
        }

        private void CanDeleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_permission != null && sender is CheckBox cb)
                _permission.CanDelete = cb.Checked;
        }
    }
}
