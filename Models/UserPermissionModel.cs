using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace smpc_admin.Models
{
   public class UserPermissionModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("can_create")]
        public bool CanCreate { get; set; }

        [JsonProperty("can_update")]
        public bool CanUpdate { get; set; }

        [JsonProperty("can_delete")]
        public bool  CanDelete { get; set; }
    }
}
