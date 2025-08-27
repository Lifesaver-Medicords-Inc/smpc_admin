using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smpc_admin.Models;

namespace smpc_admin.Services
{
    class SessionService
    {
        public static UserModel CurrentUser { get; private set; }
        public static IEnumerable<PositionAccessModel> CurrentPositionAccess { get; private set; } = Enumerable.Empty<PositionAccessModel>();
        public static UserPermissionModel CurrentUserPermission { get; private set; }

        public static void SetCurrentUser(UserModel user)
        {
            CurrentUser = user;
        }

        public static void SetCurrentPositionAccess(IEnumerable<PositionAccessModel> access)
        {
            CurrentPositionAccess = access ?? Enumerable.Empty<PositionAccessModel>();
        }

        public static void SetCurrentUserPermission(UserPermissionModel permissions)
        {
            CurrentUserPermission = permissions;
        }

        // Check permission: "create", "update", "delete"
        public static bool HasPermission(string permissionKey)
        {
            if (string.IsNullOrWhiteSpace(permissionKey) || CurrentUserPermission == null)
                return false;

            switch (permissionKey)
            {
                case "create":
                    return CurrentUserPermission.CanCreate;
                case "update":
                    return CurrentUserPermission.CanUpdate;
                case "delete":
                    return CurrentUserPermission.CanDelete;
                default:
                    return false;
            }
        }

        // Check access by string code like "ADMIN POSITIONS", "USER PERMISSION"
        public static bool HasAccess(string accessCode)
        {

     
            if (string.IsNullOrWhiteSpace(accessCode) || !CurrentPositionAccess.Any()) return false;

            return CurrentPositionAccess.Any(a =>
                string.Equals(a.Code.Trim(), accessCode.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    }
}
