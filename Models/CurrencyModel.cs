using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smpc_admin.Models;

namespace smpc_admin.Models
{
    class CurrencyModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("rate_value")]
        public string RateValue { get; set; }
    }
}
