using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smpc_admin.Models;
using smpc_admin.Utils;

namespace smpc_admin.Services
{
    class UserWithPositionService
    {
        public static async Task<HttpResponseModel<IEnumerable<UserModel>>> GetAllUsersInPositionAsync(int id)
        {
            var res = await HttpClientHelper.Get<HttpResponseModel<IEnumerable<UserModel>>>($"users/with-position/{id}");
            return res;

        }

        public static async Task<HttpResponseModel<PositionModel>> UpdateUserPositionAsync(int userId, int positionId)
        {
            var res = await HttpClientHelper.Put<HttpResponseModel<PositionModel>>($"users/position/{userId}", new { Id = userId, PositionId = positionId} );

            return res;

        }
    }
}
