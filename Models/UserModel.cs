using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace smpc_admin.Models
{
    public class UserModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("employee_id")]
        public string EmployeeId { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("position_id")]
        public int PositionId { set; get; }
        [JsonProperty("department")]
        public string Department { set; get; }

        [JsonProperty("permissions")]
        public UserPermissionModel Permissions { get; set; }
        [JsonProperty("position")]
        public PositionModel Position { get; set; }

    }
}
