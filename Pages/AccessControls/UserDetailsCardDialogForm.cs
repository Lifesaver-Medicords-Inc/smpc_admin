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
namespace smpc_admin.Pages.AccessControls
{
    public partial class UserDetailsCardDialogForm : Form
    {
       public int Id { get; private set; }
       public int PositionId { get; private set; }
       private int NewPositionId { get; set; }
       private PositionModel Position { get; set; }
       private UserPermissionModel Permision { get; set; }
        public UserDetailsCardDialogForm(UserModel user)
        {
            InitializeComponent();
            LoadPositions();
            Id = user.Id;
            PositionId = user.PositionId;
            Permision = user.Permissions;
            NewPositionId = user.PositionId;

            UserNameTextLabel.Text = $"{user.FirstName} {user.LastName}";
            UpdateBtn.Enabled = false;
        }



        private async void LoadPositions()
        {
            try
            {
                var res = await PositionService.GetAllPositionAsync();

                if (res.Success)
                {
                    var emptyOption = new PositionModel
                    {
                        Id = -0,
                        Name = "-- Select Position --"
                    };

                    var positions = res.Data.Select(a => new PositionModel { Name = a.Name, Id = a.Id }).ToList();

                    positions.Insert(0, emptyOption);

                    PositionsComboBox.DataSource = positions;
                    PositionsComboBox.DisplayMember = "Name";
                    PositionsComboBox.ValueMember = "Id";

                    PositionsComboBox.SelectedValue = PositionId;
                   
                }

            }
            catch(Exception ex)
            {

            }
        }

        private void PositionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = PositionsComboBox.SelectedItem as PositionModel;

            if (selectedItem.Id == PositionId) return;

            UpdateBtn.Enabled = true;
            NewPositionId = selectedItem.Id;

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdatePosition();
        }

        private async void UpdatePosition()
        {

            if (NewPositionId == PositionId) return;
            try
            {
                var res = await UserWithPositionService.UpdateUserPositionAsync(Id, NewPositionId);

                if(res != null && res.Success)
                {
                    Log.Information($"RES: {res.Data.Id}");
                
                }
            }catch(Exception ex)
            {

            }
            finally
            {

            }
        }

        private async void UpdatePermissions()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}
