using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smpc_admin.Models;
using smpc_admin.Utils;

namespace smpc_admin.Services
{
    class VehiclesService
    {
        public static async Task<HttpResponse<VehicleModel>> CreateVehicleAsync(VehicleModel vehicle)
        {
            var res = await HttpClientHelper.Post<HttpResponse<VehicleModel>>("vehicles",vehicle);
            return res;

        
        }

        public static async Task<HttpResponse<VehicleModel>> GetVehicleAsync(int id)
        {
            var res = await HttpClientHelper.Get<HttpResponse<VehicleModel>>($"vehicles/{id}");
            return res;

        }

        public static async Task<HttpResponse<IEnumerable<VehicleModel>>> GetVehiclesAsync(int? id = null, int? warehouseId = null, string type = null, string model = null, string status = null)
        {

            var queryParams = new List<string>();
            if (id.HasValue) queryParams.Add($"id={id.Value}");
            if (warehouseId.HasValue) queryParams.Add($"warehouseId={warehouseId.Value}");
            if (!string.IsNullOrWhiteSpace(type)) queryParams.Add($"type={Uri.EscapeDataString(type)}");
            if (!string.IsNullOrWhiteSpace(model)) queryParams.Add($"model={Uri.EscapeDataString(model)}");
            if (!string.IsNullOrWhiteSpace(status)) queryParams.Add($"status={Uri.EscapeDataString(status)}");

            string queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";

            var res = await HttpClientHelper.Get<HttpResponse<IEnumerable<VehicleModel>>>($"vehicles{queryString}");

            return res;
        }

        public static async Task<HttpResponse<VehicleModel>> UpdateVehicleAsync(VehicleModel vehicle)
        {
            var res = await HttpClientHelper.Put<HttpResponse<VehicleModel>>($"vehicles/{vehicle.Id}", vehicle);
            return res;

        }

        public static async Task<HttpResponse<VehicleModel>> DeleteVehicleAsync(int id)
        {
            var res = await HttpClientHelper.Delete<HttpResponse<VehicleModel>>($"vehicles/{id}");
            return res;

        }

    }
}
