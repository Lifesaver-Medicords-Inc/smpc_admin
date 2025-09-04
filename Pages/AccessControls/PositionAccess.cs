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
using static smpc_admin.Config.NavigationConfig;
using System.Windows.Forms.VisualStyles;

namespace smpc_admin.Pages.AccessControls
{
    public partial class PositionAccess : UserControl
    {

        private ModulesAccessCodeModel viewAccessModules = new ModulesAccessCodeModel();
        public List<PositionModel> positions = new List<PositionModel>();

        private PositionModel _selectedPosition;
        private UserControl _parent;

        public PositionAccess()
        {
            InitializeComponent();
            LoadPositions();
            LoadModulesAccess();

            PositionsComboBox.SelectedIndexChanged += PositionComboBox_SelectedItem;
            ModulesCheckedListBox.ItemCheck += ModulesCheckedListBox_ItemCheck;

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

                if (res != null && res.Success)
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

                    UncheckAllItems(ModulesCheckedListBox);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"[ERROR] Loading positions: {ex.Message}");
            }
        }



        private void PositionAccessForm_Load(object sender, EventArgs e)
        {
            ModulesTextBox.DataBindings.Add("Text", viewAccessModules, "CodesString");
        }

        private void LoadModulesAccess()
        {

            var modulesAccess = Config.NavigationConfig.GetAllItemsKeyValue(Config.NavigationConfig.Items);

            if (!modulesAccess.Any()) return;


            ModulesCheckedListBox.Controls.Clear();

            foreach (var item in modulesAccess)
            {

                ModulesCheckedListBox.Items.Add(item);
            }
        }

        private void ModulesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (ModulesCheckedListBox.Items[e.Index] is ModuleItem item)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    viewAccessModules.AddCode(item.Code);
                }
                else
                {
                    viewAccessModules.RemoveCode(item.Code);
                }
            }
            ModulesTextBox.Text = viewAccessModules.CodesString;
        }
        private void CheckModules(List<string> selectedCodes)
        {
            for (int i = 0; i < ModulesCheckedListBox.Items.Count; i++)
            {
                if (ModulesCheckedListBox.Items[i] is ModuleItem module)
                {
                    if (selectedCodes.Contains(module.Code))
                    {
                        ModulesCheckedListBox.SetItemChecked(i, true);
                    }
                }
            }
        }


        private void PositionComboBox_SelectedItem(object sender, EventArgs e)
        {
            if (!PositionsComboBox.Focused) return;
            if (PositionsComboBox.SelectedItem == null) return;
          

            if (PositionsComboBox.SelectedItem is PositionModel selected)
            {
                var position = positions.FirstOrDefault(p => p.Id == selected.Id);
                if (position != null)
                {
                    _selectedPosition = position;

              
                    if (_parent is AccessControlView parent)
                    {
                        parent.OnPositionChanged(position);
                    }

                 
                    for (int i = 0; i < ModulesCheckedListBox.Items.Count; i++)
                    {
                        ModulesCheckedListBox.SetItemChecked(i, false);
                    }

                 
               
                    var currentPositionAccess = position.Access;
                    if (currentPositionAccess != null && currentPositionAccess.Any())
                    {
                        var accessCodes = currentPositionAccess.Select(a => a.Code).ToList();
                        CheckModules(accessCodes);

                        foreach (var code in accessCodes)
                        {
                            viewAccessModules.AddCode(code);
                        }
                    }
                }
                else
                {
                  
                    for (int i = 0; i < ModulesCheckedListBox.Items.Count; i++)
                    {
                        ModulesCheckedListBox.SetItemChecked(i, false);
                    }

            
                    if (this.FindForm() is MainLayoutForm mainLayout)
                    {
                        var control = Utils.Helpers.FindControlRecursive(mainLayout, "PositionUsersForm");
                        if (control is PositionUsers userList)
                        {
                            userList.RemoveUsers();
                        }
                    }
                }
            }
        }

        private void UncheckAllItems(CheckedListBox clb)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, false);
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
  