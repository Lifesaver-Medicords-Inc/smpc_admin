using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smpc_admin.Models;
using smpc_admin.Enums;

namespace smpc_admin.AccessControl
{
    public class UserSession
    {
        public static UserModel CurrentUser { get; private set; }
        public static IEnumerable<PositionAccessModel> CurrentPositionAccess { get; private set; }
        public static UserPermissionModel CurrentUserPermission { get; private set; }

        public static void SetCurrentUser(UserModel user)
        {
            CurrentUser = user;
        }

        public static void SetCurrentPositionAccess(IEnumerable<PositionAccessModel> access)
        {
            CurrentPositionAccess = access;
        }

        public static void SetCurrentUserPermission(UserPermissionModel permissions)
        {
            CurrentUserPermission = permissions;
        }

        //User permission [create,update,delete]
        public static bool HasPermission(UserPermission permissioCode)
        {

            if (CurrentUserPermission == null) return false;

            switch (permissioCode)
            {
                case UserPermission.Create:
                    return CurrentUserPermission.CanCreate;
                case UserPermission.Update:
                    return CurrentUserPermission.CanUpdate;
                case UserPermission.Delete:
                    return CurrentUserPermission.CanDelete;
                default:
                    return false;
            }
        }

        //Position Access [access code]
        public static bool HasAccess(string accessCode)
        {

            if (CurrentPositionAccess.Any() || CurrentPositionAccess == null) return false;

            var ecode = PositionExtensions.FromCodeString(accessCode);

            if (ecode == null) return false;

            var stringCode = ecode.ToString();

            var code = CurrentPositionAccess.Where(a => a.Code == stringCode);

            return code != null;
            
        }
    }
}
