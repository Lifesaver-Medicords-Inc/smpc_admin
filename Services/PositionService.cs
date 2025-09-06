using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smpc_admin.Models;
using smpc_admin.Utils;
using System.Net.Http;

namespace smpc_admin.Services
{
    class PositionService
    {
        public async static Task<HttpResponse<PositionModel>> CreatePositionAsync(PositionModel position)
        {

            var res = await HttpClientHelper.Post<HttpResponse<PositionModel>>("positions", position);

            return res;

        }

        public static async Task<HttpResponse<List<PositionModel>>> GetAllPositionAsync(int? id = null, string name = null, string code = null)
        {

            var queryParams = new List<string>();
            if (id.HasValue) queryParams.Add($"id={id.Value}");
            if (!string.IsNullOrWhiteSpace(name)) queryParams.Add($"name={Uri.EscapeDataString(name)}");
            if (!string.IsNullOrWhiteSpace(code)) queryParams.Add($"code={Uri.EscapeDataString(code)}");

            string queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";

            var res = await HttpClientHelper.Get<HttpResponse<List<PositionModel>>>($"positions{queryString}");

            return res;
        }

        public static async Task<HttpResponse<PositionModel>> GetPositionAsync(int positionId)
        {

            var res = await HttpClientHelper.Get<HttpResponse<PositionModel>>($"positions/{positionId}");

            return res;
        }

    }
}
