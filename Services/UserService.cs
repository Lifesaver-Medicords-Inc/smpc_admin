using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smpc_admin.Models;
using smpc_admin.Utils;

namespace smpc_admin.Services
{
    class UserService
    {

        public static async Task<HttpResponse<UserModel>> CreateUserAsync(UserModel user)
        {
            var res = await HttpClientHelper.Post<HttpResponse<UserModel>>("users", user);
            return res;
        
        }

        public static async Task<HttpResponse<UserModel>> GetUserAsync(int id)
        {
            var res = await HttpClientHelper.Get<HttpResponse<UserModel>>($"users/{id}");
            return res;
        }

        public static async Task<HttpResponse<IEnumerable<UserModel>>> GetUsersAsync(int? id = null, string firstName = null, string lastName = null, string department = null)
        {

            var queryParams = new List<string>();
            if (id.HasValue) queryParams.Add($"id={id.Value}");
            if (!string.IsNullOrWhiteSpace(firstName)) queryParams.Add($"first-name={Uri.EscapeDataString(firstName)}");
            if (!string.IsNullOrWhiteSpace(lastName)) queryParams.Add($"last-name={Uri.EscapeDataString(lastName)}");
            if (!string.IsNullOrWhiteSpace(department)) queryParams.Add($"department={Uri.EscapeDataString(department)}");

            string queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";


            var res = await HttpClientHelper.Get<HttpResponse<IEnumerable<UserModel>>>($"users{queryString}");
            return res;
        }

        public static async Task<HttpResponse<UserModel>> UpdateUserAsync(UserModel user)
        {
            var res = await HttpClientHelper.Put<HttpResponse<UserModel>>($"users/{user.Id}", user);
            return res;
        }

        public static async Task<HttpResponse<UserModel>> DeleteUserAsync(int id)
        {
            var res = await HttpClientHelper.Delete<HttpResponse<UserModel>>($"users/{id}");
            return res;
        }

        public static async Task<HttpResponse<UserPermissionModel>> CreateUserPermissionAsync(UserPermissionModel permissions)
        {
            var res = await HttpClientHelper.Post<HttpResponse<UserPermissionModel>>("permissions", permissions);
            return res;
          
        }
        public static async Task<HttpResponse<UserPermissionModel>> GetUserPermissionAsync(int id)
        {
            var res = await HttpClientHelper.Get<HttpResponse<UserPermissionModel>>($"user-permissions/{id}");
            return res;

        }
        public static async Task<HttpResponse<UserPermissionModel>> UpdatePermissionAsync(UserPermissionModel permissions)
        {
            var res = await HttpClientHelper.Put<HttpResponse<UserPermissionModel>>($"permissions/{permissions.Id}", permissions);
            return res;
        }
    }
}
