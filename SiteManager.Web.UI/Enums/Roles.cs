using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiteManager.Web.UI.Enums
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }

    public enum RoleType : byte
    {
        [Description(Roles.Admin)]
        Admin = 1,
        [Description(Roles.User)]
        User = 2,
    }
}
