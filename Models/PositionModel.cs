using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace smpc_admin.Models
{
    public class PositionModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("access")]
        public ICollection<PositionAccessModel> Access { get; set; }

        [JsonProperty("users")]
        public ICollection<UserModel> Users { get; set; }
    }
}
