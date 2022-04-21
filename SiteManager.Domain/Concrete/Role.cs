using Microsoft.AspNetCore.Identity;
using SiteManager.Domain.Abstract;

namespace SiteManager.Domain.Concrete
{
    public class Role : IdentityRole, IEntity
    {
    }
}
