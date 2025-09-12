using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace smpc_admin.Models
{
    public class WarehouseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("warehouse_manager")]
        public string WarehouseManager { get; set; }
        [JsonProperty("is_inactive")]
        public bool IsInactive { get; set; }
    }
}
