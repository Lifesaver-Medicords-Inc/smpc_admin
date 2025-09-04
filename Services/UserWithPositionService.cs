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
        public static async Task<HttpResponse<IEnumerable<UserModel>>> GetAllUsersInPositionAsync(int id)
        {
            var res = await HttpClientHelper.Get<HttpResponse<IEnumerable<UserModel>>>($"users/with-position/{id}");
            return res;

        }

        public static async Task<HttpResponse<PositionModel>> UpdateUserPositionAsync(UserModel user)
        {
            var res = await HttpClientHelper.Put<HttpResponse<PositionModel>>($"users/position/{user.Id}", user );

            return res;

        }
    }
}
