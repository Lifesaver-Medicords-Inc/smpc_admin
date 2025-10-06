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
using smpc_admin.Constants;
using System.Globalization;
using Serilog;


namespace smpc_admin.Pages.Vehicles
{
    public partial class VehiclesView : UserControl
    {
        private List<VehicleModel> _originalVehicles = new List<VehicleModel>();
        private List<VehicleModel> _vehicles = new List<VehicleModel>();
        private Dictionary<int, VehicleModel> _updatedVehicles = new Dictionary<int, VehicleModel>();
        private Dictionary<int, VehicleModel> _addVehicles = new Dictionary<int, VehicleModel>();
        private List<WarehouseModel> _warehouse = new List<WarehouseModel>();
        private int _selectedWareHouseId;
        public VehiclesView()
        {
            InitializeComponent();
        }



        private void VehiclesView_Load(object sender, EventArgs e)
        {
            SaveBtn.Enabled = false;
            CancelBtn.Enabled = false;

            LoadWarehouse();


            VehiclesDataGridView.UserDeletingRow += VehiclesDataGridView_UserDeletingRow;

            VehiclesDataGridView.CellValueChanged += VehiclesDataGridView_CellValueChanged;
            VehiclesDataGridView.CurrentCellDirtyStateChanged += (s,_) =>
            {
                if (VehiclesDataGridView.IsCurrentCellDirty)
                    VehiclesDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };

            VehiclesDataGridView.CellFormatting += VehiclesDataGridView_CellFormatting;

            VehiclesDataGridView.DataError += VehiclesDataGridView_DataError;

            VehiclesDataGridView.CellClick += VehiclesDataGridView_CellClick;
        }


        private async void LoadWarehouse()
        {
            try
            {
                var res = await WarehouseService.GetAllWarehousesAsync();

                if(res != null && res.Success)
                {
                    var warehouses = res.Data;
                    _warehouse = res.Data.ToList();

                    var emptyOption = new WarehouseModel
                    {
                        Id = -0,
                        Name = "-- Select Warehouse --"
                    };

                    var mapWarehouse = warehouses.Select(a => new WarehouseModel { Name = a.Name, Id = a.Id }).ToList();

                    mapWarehouse.Insert(0, emptyOption);

                    WareHouseComboBox.DataSource = mapWarehouse;
                    WareHouseComboBox.DisplayMember = "Name";
                    WareHouseComboBox.ValueMember = "Id";
                }
            }catch(Exception ex)
            {

            }
        }


        private async void LoadVehicles(int? id, int? warehouseId)
        {
            try
            {
                var res = await VehiclesService.GetVehiclesAsync(id,warehouseId);

                if(res != null && res.Success)
                {
                   
                    _vehicles = res.Data.ToList();
                    _originalVehicles = res.Data.ToList();
                    LoadVehiclesGrid();
                }

            }catch(Exception ex)
            {
                Utils.Helpers.ShowDialogMessage($"Failed to get vehicles {ex.Message}");
                _vehicles.Clear();
                LoadVehiclesGrid();
            }
        }



        private void LoadVehiclesGrid()
        {
            VehiclesDataGridView.DataSource = null;
           
            var bindingList = new BindingList<VehicleModel>(_vehicles);
            VehiclesDataGridView.AutoGenerateColumns = false;
            VehiclesDataGridView.DataSource = bindingList;

 
            if (VehiclesDataGridView.Columns["Type"] is DataGridViewComboBoxColumn typeColumn)
            {
                var allTypes = _vehicles
                    .Select(v => v.Type?.Trim())
                    .Where(t => !string.IsNullOrWhiteSpace(t))
                    .Select(t => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(t.ToLower()))
                    .Distinct()
                    .Union(Enum.GetNames(typeof(VehicleTypesEnum)))
                    .Distinct()
                    .ToList();

                typeColumn.DataSource = allTypes;
                typeColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                typeColumn.FlatStyle = FlatStyle.Flat;
            }

            // === Status column ===
            if (VehiclesDataGridView.Columns["Status"] is DataGridViewComboBoxColumn statusColumn)
            {
                var allStatuses = _vehicles
                    .Select(v => v.Status?.Trim())
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(s => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(s.ToLower()))
                    .Distinct()
                    .Union(Enum.GetNames(typeof(VehicleStatusEnum)))
                    .Distinct()
                    .ToList();

                statusColumn.DataSource = allStatuses;
                statusColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                statusColumn.FlatStyle = FlatStyle.Flat;
            }


            if (VehiclesDataGridView.Columns["Warehouse"] is DataGridViewComboBoxColumn warehouseColumn)
            {


                var availableWarehouses = _warehouse
               .Select(w => new
               {
                   w.Id,
                   Name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(w.Name.ToLower())
               })
               .ToList();

                warehouseColumn.DataSource = availableWarehouses;
                warehouseColumn.ValueMember = "Id";     
                warehouseColumn.DisplayMember = "Name";
                warehouseColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                warehouseColumn.FlatStyle = FlatStyle.Flat;
            }


            foreach (DataGridViewColumn column in VehiclesDataGridView.Columns)
            {
                if (string.IsNullOrEmpty(column.DataPropertyName))
                {
                    column.DataPropertyName = column.Name;
                }
            }

            _originalVehicles = _vehicles;
        }



        private void VehiclesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (VehiclesDataGridView.Columns[e.ColumnIndex].Name == "Capacity" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int capacity))
                {
                    e.Value = $"{capacity} kg";
                    e.FormattingApplied = true;
                }
            }


            if (VehiclesDataGridView.Columns[e.ColumnIndex].Name == "Files" &&
                e.RowIndex >= 0 )
            {
                Image original = Properties.Resources.folder_icon;
                Image resized = new Bitmap(original, new Size(20, 20));

                e.Value = resized;
                e.FormattingApplied = true;
            }
        }

        private void VehiclesDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.RowIndex >= VehiclesDataGridView.Rows.Count)
                return;

            var row = VehiclesDataGridView.Rows[e.RowIndex];

            if (row != null && !row.IsNewRow)
            {
                var vehicle = GetVehicleFromRow(row);

                bool isOriginal = vehicle.Id > 0 && _vehicles.Any(v => v.Id == vehicle.Id);

                if (!isOriginal)
                {
                   
                    _addVehicles[vehicle.Id] = vehicle;
                }
                else
                {
                    _updatedVehicles[vehicle.Id] = vehicle;
                }

                SaveBtn.Enabled = true;
                CancelBtn.Enabled = true;
            }
        }




        private VehicleModel GetVehicleFromRow(DataGridViewRow row)
        {
            var vehicle = row.DataBoundItem as VehicleModel;
            return vehicle ?? new VehicleModel
            {
                Type = row.Cells["Type"].Value?.ToString(),
                Model = row.Cells["Model"].Value?.ToString(),
                Description = row.Cells["Description"].Value?.ToString(),
                PlateNo = row.Cells["PlateNo"].Value?.ToString(),
                AcquisitionYear = row.Cells["AcquisitionYear"].Value?.ToString(),
                Capacity = int.TryParse(row.Cells["Capacity"].Value?.ToString(), out int capacityVal) ? capacityVal : 0,
                Status = row.Cells["Status"].Value?.ToString(),
                LastMaintenance = row.Cells["LastMaintenance"].Value?.ToString(),
                Notes = row.Cells["Notes"].Value?.ToString(),
                Id = int.TryParse(row.Cells["Id"].Value?.ToString(), out int idVal) ? idVal : 0,
                WarehouseId = int.TryParse(row.Cells["Warehouse"].Value?.ToString(), out int val) ? val : 0

            };
        }



        private async void VehiclesDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow)
            {
                e.Cancel = true;
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this row?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            var vehicle = e.Row.DataBoundItem as VehicleModel;

            if (vehicle != null)
            {
                try
                {
                    var res = await VehiclesService.DeleteVehicleAsync(vehicle.Id);
                    if (res == null || !res.Success)
                    {
                        MessageBox.Show("Failed to delete vehicle from server.");
                        e.Cancel = true; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting vehicle.");
                    e.Cancel = true;
                }
            }
        }

         private async Task<List<VehicleModel>> UploadNewVehicles()
        {
            try
            {
                var vehicles = _addVehicles;


                var uploadTasks = vehicles.Select(async vehicle =>
                {
                    vehicle.Value.WarehouseId = _selectedWareHouseId;
                    var response = await VehiclesService.CreateVehicleAsync(vehicle.Value);
                    if (response != null && response.Success)
                    {
                        Log.Information($"UPLOAD NEW: {response.Data.Id}");
                        return response.Data;
                    }
                    else
                    {
                        return null;
                    }
                }).ToList();

     
                var results = await Task.WhenAll(uploadTasks);

                var successfulUploads = results.Where(v => v != null).ToList();

                return successfulUploads;

            }
            catch(Exception ex)
            {
                Utils.Helpers.ShowDialogMessage("Failed to uplaod new vehicles");
                 return new List<VehicleModel>();
            }
        }



        private async Task<List<VehicleModel>> UpdateVehicles()
        {
            try
            {
                var vehicles = _updatedVehicles;

                var uploadTasks = vehicles.Select(async vehicle =>
                {
                    var response = await VehiclesService.UpdateVehicleAsync(vehicle.Value);
                    if (response != null && response.Success)
                    {
                        Log.Information($"UPLOAD UPDATE: {response.Data.Id}");
                        return  response.Data;
                    }
                    else
                    {
                        return null;
                    }
                }).ToList();


                var results = await Task.WhenAll(uploadTasks);

                var successfulUploads = results.Where(v => v != null).ToList();

                return successfulUploads;
            }
            catch (Exception ex)
            {
                Utils.Helpers.ShowDialogMessage("Failed to update vehicles");
                return new List<VehicleModel>();
            }
        }


        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {

                var updateDataRow = new List<VehicleModel>();

                var uploadResult = await UploadNewVehicles();

                if (uploadResult != null && uploadResult.Any())
                {
                    updateDataRow.AddRange(uploadResult);
                }

               
                var updateResult = await UpdateVehicles();

                if (updateResult != null && updateResult.Any())
                {
                    updateDataRow.AddRange(updateResult);
                }

                foreach (var row in updateDataRow)
                {
                    var exist = _vehicles.FirstOrDefault(v => v.Type == row.Type && v.Model == row.Model
                    && v.Description == row.Description && v.PlateNo == row.PlateNo 
                    && v.AcquisitionYear == row.AcquisitionYear && v.Capacity == row.Capacity 
                    && v.Status == row.Status && v.LastMaintenance == row.LastMaintenance && v.Notes == row.Notes);

                    if (exist != null)
                    {
   
                        _vehicles.Remove(exist);

                        if (_selectedWareHouseId > 0 && exist.WarehouseId != _selectedWareHouseId)
                        {
                            continue;
                        }
                    }

                    _vehicles.Add(row);

                }

                _addVehicles.Clear();
                _updatedVehicles.Clear();

                LoadVehiclesGrid();

            }
            catch(Exception ex)
            {
              
            }
        }



        private void CancelBtn_Click(object sender, EventArgs e)
        {
            _addVehicles.Clear();
            _updatedVehicles.Clear();
            _vehicles = _originalVehicles;
            LoadVehiclesGrid();
            SaveBtn.Enabled = false;
            CancelBtn.Enabled = false;

        }

        private void WareHouseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WareHouseComboBox.SelectedItem is WarehouseModel selected)
            {
                if(selected.Id >= 0)
                {
                    _selectedWareHouseId = selected.Id;
                  LoadVehicles(null, selected.Id);
                }

            }
        }



        private void VehiclesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           
            e.Cancel = true; // prevent the exception from showing the default dialog
        }



        private void VehiclesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
    
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName = VehiclesDataGridView.Columns[e.ColumnIndex].Name;
            if (columnName == "Files")
            {
                var row = VehiclesDataGridView.Rows[e.RowIndex];
                var vehicle = row.DataBoundItem as VehicleModel;

                if(vehicle != null)
                {
                    var filesDialog =new VehicleFilesDialogForm(vehicle);
                    filesDialog.ShowDialog();
                }


            }
        }

    }


}
