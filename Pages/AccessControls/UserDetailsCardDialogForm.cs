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

namespace smpc_admin.Pages.AccessControls
{
    public partial class UserDetailsCardDialogForm : Form
    {
        private int Id { get; }
        private int PositionId { get; }
        private int NewPositionId { get; set; }
        private UserPermissionModel _permission;
        private UserPermissionModel _newPermission;
        private readonly UserModel _user;
        public event Action<int> UpdateSuccess;

        public UserDetailsCardDialogForm(UserModel user)
        {
            InitializeComponent();
            _user = user;
            Id = user.Id;
            PositionId = user.PositionId;
            NewPositionId = user.PositionId;
            _permission = user.Permissions;
            _newPermission = user.Permissions;

            UserNameTextLabel.Text = $"{user.FirstName} {user.LastName}";

            LoadUserPermissionsAsync();
        }

        public async Task LoadPositionsAsync()
        {
            try
            {

                LoaderIndicatorOverlay.ShowOverlay();


                var res = await PositionService.GetAllPositionAsync();

                if (res?.Success == true)
                {
                    var positions = res.Data.Select(p => new PositionModel
                    {
                        Id = p.Id,
                        Name = p.Name
                    }).ToList();

                    positions.Insert(0, new PositionModel { Id = 0, Name = "-- Select Position --" });

                    PositionsComboBox.DataSource = positions;
                    PositionsComboBox.DisplayMember = "Name";
                    PositionsComboBox.ValueMember = "Id";
                    PositionsComboBox.SelectedValue = PositionId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Loading positions: {ex.Message}");
            }
            finally
            {
                LoaderIndicatorOverlay.HideOverlay();
            }
        }

        private void PositionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PositionsComboBox.SelectedItem is PositionModel selected && selected.Id != PositionId)
            {
                NewPositionId = selected.Id;
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
                LoaderIndicatorOverlay.ShowOverlay();

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
               
            }
            finally
            {
                LoaderIndicatorOverlay.HideOverlay();
            }
        }

        private async Task UpdatePositionAsync()
        {
            try
            {
                LoaderIndicatorOverlay.ShowOverlay();

                var res = await UserWithPositionService.UpdateUserPositionAsync(new UserModel
                {
                    Id = Id,
                    PositionId = NewPositionId
                });

                if (res?.Success == true)
                {
                    UpdateSuccess?.Invoke(PositionId);
                }
                this.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                LoaderIndicatorOverlay.HideOverlay();
            }
        }

        private async Task UpdatePermissionsAsync()
        {
            if (_permission == null || _newPermission == null || _permission.Equals(_newPermission))
                return;

            try
            {
                LoaderIndicatorOverlay.ShowOverlay();
                await UserService.UpdateUserPermissionAsync(_newPermission);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Updating permissions: {ex.Message}");
            }
            finally
            {
                LoaderIndicatorOverlay.HideOverlay();
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
