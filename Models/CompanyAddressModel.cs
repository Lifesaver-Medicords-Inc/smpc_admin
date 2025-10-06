using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_admin.Models
{
    public class CompanyAddressModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("company_id")]
        public int CompanyId { get; set; }
        [JsonProperty("address_type")]
        public string AddressType { get; set; }
        [JsonProperty("unit_no")]
        public string UnitNo { get; set; }
        [JsonProperty("building_name")]
        public string BuildingName { get; set; }
        [JsonProperty("street_name")]
        public string StreetName { get; set; }
        [JsonProperty("subdivision")]
        public string Subdivision { get; set; }
        [JsonProperty("barangay")]
        public string barangay { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("province")]
        public string Province { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("postal_code")]
        public int PostalCode { get; set; }
    }
}
