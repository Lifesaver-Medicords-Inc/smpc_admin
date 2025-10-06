using smpc_admin.Models;
using smpc_admin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_admin.Services
{
    class CompanyService
    {
        public static async Task<HttpResponse<CompanyModel>> CreateCompaniesAsync(CompanyModel company)
        {
            var res = await HttpClientHelper.Post<HttpResponse<CompanyModel>>("companies", company);
            return res;

        }

        public static async Task<HttpResponse<CompanyModel>> GetCompanyAsync(int id)
        {
            var res = await HttpClientHelper.Get<HttpResponse<CompanyModel>>($"companies/{id}");
            return res;
        }

        public static async Task<HttpResponse<IEnumerable<CompanyModel>>> GetCompaniesAsync(int? id = null, string companyName = null, string status = null) 
        {
            var queryParams = new List<string>();
            if (id.HasValue) queryParams.Add($"id={id.Value}");
            if (!string.IsNullOrWhiteSpace(companyName)) queryParams.Add($"company_name={Uri.EscapeDataString(companyName)}");
            if (!string.IsNullOrWhiteSpace(status)) queryParams.Add($"status={Uri.EscapeDataString(status)}");

            string queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";

            var res = await HttpClientHelper.Get<HttpResponse<IEnumerable<CompanyModel>>>($"companies{queryString}");
            return res;
        }

        public static async Task<HttpResponse<CompanyModel>> UpdateCompanyAsync(CompanyModel company)
        {
            var res = await HttpClientHelper.Put<HttpResponse<CompanyModel>>($"companies/{company.Id}", company);
            
            return res;
        }

        public static async Task<HttpResponse<CompanyModel>> DeleteCompanyAsync(int Id)
        {
            var res = await HttpClientHelper.Delete<HttpResponse<CompanyModel>>($"companies/{Id}");

            return res;
        }

        public static async Task<HttpResponse<IEnumerable<CurrencyModel>>> GetCurrencyAsync(string Id)
        {
            var res = await HttpClientHelper.Get<HttpResponse<IEnumerable<CurrencyModel>>>($"currency/{Id}");

            return res;
        }
    }
}
