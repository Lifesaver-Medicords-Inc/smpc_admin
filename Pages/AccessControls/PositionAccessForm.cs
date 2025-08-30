using smpc_admin.ViewModels;
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
using smpc_admin.Pages.Shared;
using smpc_admin.Services;
using smpc_admin.Pages.AccessControls;
using Serilog;
using smpc_admin.Pages.Layout;
using smpc_admin.Utils;

namespace smpc_admin.Pages.AccessControls
{
    public partial class PositionAccessForm : UserControl
    {

        private ModulesAccessCodeModel viewAccessModules = new ModulesAccessCodeModel();
        public List<PositionModel> positions = new List<PositionModel>();

        private PositionModel _selectedPosition;
        private UserControl _parent;

        public PositionAccessForm()
        {
            InitializeComponent();
            LoadPositions();
            LoadModulesAccess();

            PositionsComboBox.SelectedIndexChanged += PositionComboBox_SelectedItem;


            ModulesFlowLayoutPanel.Resize += ModulesFlowLayoutPanel_Resize;
        }


        public void Host(UserControl parent)
        {
            _parent = parent;
        }


        private async void LoadPositions()
        {
            try
            {
                var res = await PositionService.GetAllPositionAsync();

                if (res.Success)
                {
                    positions = res.Data;


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
                }
            }
            catch (Exception ex)
            {
                Log.Error($"[ERROR] Loading positions: {ex.Message}");
            }
            finally
            {
                LoadModulesAccess();
            }
        }



        private void PositionAccessForm_Load(object sender, EventArgs e)
        {
            ModulesTextBox.DataBindings.Add("Text", viewAccessModules, "CodesString");
        }

        private void LoadModulesAccess()
        {

            var modulesAccess = Config.NavigationConfig.GetAllItems(Config.NavigationConfig.Items);

            if (!modulesAccess.Any()) return;


            ModulesFlowLayoutPanel.Controls.Clear();

            foreach (var item in modulesAccess)
            {

                var moduleRow = new CheckBoxAndLabelItem(item.Key, item.Key);
                moduleRow.Width = ModulesFlowLayoutPanel.ClientSize.Width;


                moduleRow.OnCheckedChanged += (s, isChecked) =>
                {
                    var row = (CheckBoxAndLabelItem)s;

                    if (isChecked)
                    {
                        viewAccessModules.AddCode(row.LabelText);
                    }
                    else
                    {
                        viewAccessModules.RemoveCode(row.LabelText);
                    }

                };


                ModulesFlowLayoutPanel.Controls.Add(moduleRow);


            }
        }


        private void PositionComboBox_SelectedItem(object sender, EventArgs e)
        {
            if (!PositionsComboBox.Focused) return;

            if (PositionsComboBox.SelectedItem == null) return;

            if (PositionsComboBox.SelectedItem is PositionModel selected)
            {

                var position = positions.Where(p => p.Id == selected.Id).FirstOrDefault();

                if (position != null)
                {
                    _selectedPosition = position;

                    var parent = _parent as AccessControlForm;
                    if (parent != null)
                    {
                        parent.OnPositionChanged(position);
                    }

                    // LoadPositionEmployees(position.Id);
                    var currentPositionAccess = position.Access;
                    

                    if(currentPositionAccess != null)
                    {

                    //Mark check in modules
                    foreach (CheckBoxAndLabelItem item in ModulesFlowLayoutPanel.Controls.OfType<CheckBoxAndLabelItem>())
                    {
                        var exist = currentPositionAccess.Where(a => a.Code == item.id).FirstOrDefault();

                        if (exist != null)
                        {
                            item.IsChecked = true;

                            viewAccessModules.AddCode(item.LabelText);
                            continue;
                        }
                        item.IsChecked = false;
                        viewAccessModules.RemoveCode(item.LabelText);

                    }

                    }


                }
                else
                {

                    foreach (CheckBoxAndLabelItem item in ModulesFlowLayoutPanel.Controls.OfType<CheckBoxAndLabelItem>())
                    {
                        item.IsChecked = false;
                    }

                    //Remove users in list
                    var parent = this.FindForm() as MainLayoutForm;

                    if (parent != null)
                    {
                        var control = Utils.Helpers.FindControlRecursive(parent, "PositionUsersForm");

                        if (control is PositionUsersForm userList)
                        {
                            userList.RemoveUsers();
                        }
   
                    }

                }

            }
        }

        private void ModulesFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in ModulesFlowLayoutPanel.Controls)
            {
                ctrl.Width = ModulesFlowLayoutPanel.ClientSize.Width - 10;
            }
        }

        private async void Save_Click(object sender, EventArgs e)
        {
            try
            {

                if (_selectedPosition == null) return;

                var access = new List<PositionAccessModel>();

                foreach (var a in viewAccessModules.Codes)
                {
                    access.Add(new PositionAccessModel
                    {
                        PositionId = _selectedPosition.Id,
                        Code = a
                    });
                }

                var res = await PositionAccessService.UpdatePositionAllAccessAsync(access, _selectedPosition.Id);



                if (res != null && res.Success)
                {
                    LoadPositions();
                }


            }
            catch (Exception ex)
            {
                Log.Error($"[ERROR] Updating position access: {ex.Message}");
             
            }
        }
    }
}
