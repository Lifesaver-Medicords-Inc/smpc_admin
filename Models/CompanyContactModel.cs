using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_admin.Models
{
    public class CompanyContactModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("company_id")]
        public int Company { get; set; }
        [JsonProperty("full_name")]
        public string Fullname { get; set; }
        [JsonProperty("designation")]
        public string Designation { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone_no")]
        public string PhoneNumber { get; set; }
        [JsonProperty("mobile_no")]
        public string MobileNumber { get; set; }
        [JsonProperty("is_primary_contact")]
        public bool IsPrimaryContact { get; set; }
    }
}
