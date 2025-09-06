using smpc_admin.Models;
using smpc_admin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_admin.Services
{
    class WarehouseService
    {
        public static async Task<HttpResponse<WarehouseModel>> GetWarehouseAsync(int id)
        {
            var res = await HttpClientHelper.Get<HttpResponse<WarehouseModel>>($"warehouses/{id}");
            return res;

        }

        public static async Task<HttpResponse<IEnumerable<WarehouseModel>>> GetAllWarehousesAsync(int? id = null, string name = null, string warehouseManager = null, string code = null)
        {

            var queryParams = new List<string>();
            if (id.HasValue) queryParams.Add($"id={id.Value}");
            if (!string.IsNullOrWhiteSpace(name)) queryParams.Add($"name={Uri.EscapeDataString(name)}");
            if (!string.IsNullOrWhiteSpace(warehouseManager)) queryParams.Add($"warehouse-manager={Uri.EscapeDataString(warehouseManager)}");
            if (!string.IsNullOrWhiteSpace(code)) queryParams.Add($"code={Uri.EscapeDataString(code)}");

            string queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";

            var res = await HttpClientHelper.Get<HttpResponse<IEnumerable<WarehouseModel>>>($"warehouses{queryString}");

            return res;
        }

    }
}
