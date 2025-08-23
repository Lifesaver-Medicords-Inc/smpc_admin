using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace smpc_admin.Models
{
   public class PositionAccessModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("position_id")]
        public int PositionId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
       
    }
}
