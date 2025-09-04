using smpc_admin.Models;
using smpc_admin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_admin.Services
{
    class PositionAccessService
    {
        public static async Task<HttpResponse<PositionModel>> CreatePositionAccessAsync(PositionAccessModel positionAccess)
        {
            var res = await HttpClientHelper.Post<HttpResponse<PositionModel>>("positions-access", positionAccess);

            return res;
        }


        public static async Task<HttpResponse<List<PositionAccessModel>>> UpdatePositionAllAccessAsync(List<PositionAccessModel> positionAccess, int positionId)
        {
            var res = await HttpClientHelper.Post<HttpResponse<List<PositionAccessModel>>>($"position-access/update-all-access/{positionId}", positionAccess);
            return res;
        }
    }
}
