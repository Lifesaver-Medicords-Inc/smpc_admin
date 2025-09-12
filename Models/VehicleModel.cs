using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace smpc_admin.Models
{
   public class VehicleModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("warehouse_id")]
        public int WarehouseId { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("plate_no")]
        public string PlateNo { get; set; }
        [JsonProperty("acquisition_year")]
        public string AcquisitionYear { get; set; }
        [JsonProperty("capacity")]
        public int Capacity { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("last_maintenance")]
        public string LastMaintenance { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("files")]
        public IEnumerable<VehicleFileModel> Files { get; set; } = new List<VehicleFileModel>();
    }
}
