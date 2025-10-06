using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smpc_admin.Models;


namespace smpc_admin.Models
{
    public class CompanyModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("company_code")]
        public string CompanyCode { get; set; }
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }
        [JsonProperty("legal_name")]
        public string LegalName { get; set; }
        [JsonProperty("trade_name")]
        public string TradeName { get; set; }
        [JsonProperty("business_type")]
        public string BusinessType { get; set; }
        [JsonProperty("sec_registration_no")]
        public string SecRegistrationNo { get; set; }
        [JsonProperty("dti_registration_no")]
        public string DtiRegistrationNo { get; set; }
        [JsonProperty("tin")]
        public string tin { get; set; }
        [JsonProperty("bir_branch_code")]
        public string BirBranchCode { get; set; }
        [JsonProperty("rdo_code")]
        public string RdoCode { get; set; }
        [JsonProperty("industry")]
        public string Industry { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("is_head_office")]
        public bool IsHeadOffice { get; set; }
        [JsonProperty("beg_bal")]
        public float BegBal { get; set; }
        [JsonProperty("monthly_rate")]
        public float MonthlyRate { get; set; }
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
        [JsonProperty("start_fiscal_date")]
        public string StartFiscalYearDate { get; set; }
        [JsonProperty("end_fiscal_date")]
        public string EndFiscalYearDate { get; set; }
        [JsonProperty("address")]
        public CompanyAddressModel Address { get; set; }
        [JsonProperty("contacts")]
        public CompanyContactModel[] Contacts { get; set; }
    }
}
