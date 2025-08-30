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
        private int _id { get; }
        private int _positionId { get; }
        private int _newPositionId { get; set; }
        private UserPermissionModel _permission;
        private UserPermissionModel _newPermission;
        private readonly UserModel _user;
        public event Action<int> UpdateSuccess;
        private readonly PositionAccessForm _positionAccessForm;
        private readonly List<PositionModel> _positions;
        public UserDetailsCardDialogForm(UserModel user, PositionAccessForm positionAccessForm)
        {
            InitializeComponent();
            _user = user;
            _id = user.Id;
            _positionId = user.PositionId;
            _newPositionId = user.PositionId;
            _permission = user.Permissions;
            _newPermission = user.Permissions;

            UserNameTextLabel.Text = $"{user.FirstName} {user.LastName}";

            LoadUserPermissionsAsync();
            _positionAccessForm = positionAccessForm;
            _positions = _positionAccessForm.positions;

            LoadPositionsAsync();
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

        public void  LoadPositionsAsync()
        {
            PositionsComboBox.DataSource =_positions;
            PositionsComboBox.DisplayMember = "Name";
            PositionsComboBox.ValueMember = "Id";
            PositionsComboBox.SelectedValue = _positionId;
        }

        private void PositionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PositionsComboBox.SelectedItem is PositionModel selected && selected.Id != _positionId)
            {
                _newPositionId = selected.Id;
            }
        }

        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            await UpdatePositionAsync();
            await UpdatePermissionsAsync();
        }

        private async void LoadUserPermissionsAsync()
        {
            try
            {
              

                var res = await UserService.GetUserPermissionAsync(_user.Id);

                if (res?.Success == true && res.Data != null)
                {
                    _permission = res.Data;
                    _newPermission = res.Data;

                    CanCreateCheckBox.Checked = res.Data.CanCreate;
                    CanUpdateCheckBox.Checked = res.Data.CanUpdate;
                    CanDeleteCheckBox.Checked = res.Data.CanDelete;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"[ERROR] Load user permission: {ex.Message}");
            }
            
        }

        private async Task UpdatePositionAsync()
        {
            try
            {
                if (_positionId == _newPositionId) return;

                var res = await UserWithPositionService.UpdateUserPositionAsync(new UserModel
                {
                    Id = _id,
                    PositionId = _newPositionId
                });

                if (res?.Success == true)
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

            if (_permission == null || _newPermission == null)
                return;

            try
            {
                await UserService.UpdateUserPermissionAsync(_newPermission);
            }
            catch (Exception ex)
            {
               Log.Error($"[ERROR] Updating permissions: {ex.Message}");
            }
          
        }

        private void CanCreateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_newPermission != null && sender is CheckBox cb)
                _newPermission.CanCreate = cb.Checked;
        }

        private void CanUpdateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_newPermission != null && sender is CheckBox cb)
                _newPermission.CanUpdate = cb.Checked;
        }

        private void CanDeleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_newPermission != null && sender is CheckBox cb)
                _newPermission.CanDelete = cb.Checked;
        }
    }
}
