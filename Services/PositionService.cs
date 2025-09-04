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

        public static async Task<HttpResponse<List<PositionModel>>> GetAllPositionAsync()
        {

            var res = await HttpClientHelper.Get<HttpResponse<List<PositionModel>>>($"positions");

            return res;
        }

        public static async Task<HttpResponse<PositionModel>> GetPositionAsync(int positionId)
        {

            var res = await HttpClientHelper.Get<HttpResponse<PositionModel>>($"positions/{positionId}");

            return res;
        }

    }
}
