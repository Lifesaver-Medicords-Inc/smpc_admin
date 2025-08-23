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
        public async static Task<HttpResponseModel<PositionModel>> CreatePositionAsync(PositionModel position)
        {

            var res = await HttpClientHelper.Post<HttpResponseModel<PositionModel>>("positions", position);

            return res;

        }

        public static async Task<HttpResponseModel<List<PositionModel>>> GetAllPositionAsync()
        {

            var res = await HttpClientHelper.Get<HttpResponseModel<List<PositionModel>>>($"positions");

            return res;
        }

        public static async Task<HttpResponseModel<PositionModel>> GetPositionAsync(int positionId)
        {

            var res = await HttpClientHelper.Get<HttpResponseModel<PositionModel>>($"positions/{positionId}");

            return res;
        }

    }
}
