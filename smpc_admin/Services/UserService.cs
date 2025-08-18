using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smpc_admin.Models;
using smpc_admin.Helpers;

namespace smpc_admin.Services
{
    class UserService
    {
        public static async Task<HttpResponseModel<UserPermissionModel>> CreateUserPermissionAsync(UserPermissionModel permissions)
        {
            var res = await HttpClientHelper.Post<HttpResponseModel<UserPermissionModel>>("", permissions);
            return res;
          
        }
        public static async Task<HttpResponseModel<UserPermissionModel>> GetUserPermissionsAsync(int id)
        {
            var res = await HttpClientHelper.Get<HttpResponseModel<UserPermissionModel>>($"/{id}");
            return res;

        }
        public static async Task<HttpResponseModel<UserPermissionModel>> UpdateUserPermissionAsync(UserPermissionModel permissions)
        {
            var res = await HttpClientHelper.Put<HttpResponseModel<UserPermissionModel>>("", permissions);
            return res;
        }
    }
}
