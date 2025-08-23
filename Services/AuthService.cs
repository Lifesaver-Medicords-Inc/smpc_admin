using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smpc_admin.Models;
using smpc_admin.Utils;

namespace smpc_admin.Services
{
    class AuthService
    {
        public async static Task<HttpResponseModel<UserModel>> LoginAsync(Dictionary<string,dynamic> data)
        {
            var res = await HttpClientHelper.Post<HttpResponseModel<UserModel>>("login", data);
            return res;
        }

        public async static Task<HttpResponseModel<UserModel>> LogOutAsync(Dictionary<string, dynamic> data)
        {
            var res = await HttpClientHelper.Post<HttpResponseModel<UserModel>>("logout", data);
            return res;
        }
    }
}
