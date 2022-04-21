using SiteManager.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.Business.Abstract
{
    public interface IRoleService
    {
        Task<Role> RemoveRole();
        Task<Role> CreateRole();
        Task<Role> UpdateRole();
    }
}
