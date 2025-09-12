using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_admin.Models
{
    public class VehicleFileModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("vehicle_id")]
        public int VehicleId { get; set; }
        [JsonProperty("file_name")]
        public string FileName { get; set; }
        [JsonProperty("original_name")]
        public string OriginalName { get; set; }
        [JsonProperty("file_path")]
        public string FilePath { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
    }
}
