using SiteManager.DataAccess.Abstract;
using SiteManager.DataAccess.Concrete.EntityFramework.Contexts;
using SiteManager.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRoleRepository : EfRepository<Role>, IRoleRepository
    {
        public EfRoleRepository(SiteManagerDbContext context) : base(context)
        {
        }
    }
}
