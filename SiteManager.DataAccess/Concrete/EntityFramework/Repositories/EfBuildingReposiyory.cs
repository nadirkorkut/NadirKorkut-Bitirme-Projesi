using SiteManager.DataAccess.Abstract;
using SiteManager.DataAccess.Concrete.EntityFramework.Contexts;
using SiteManager.Domain.Concrete;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfBuildingReposiyory : EfRepository<Building>, IBuildingRepository
    {
        public EfBuildingReposiyory(SiteManagerDbContext context) : base(context)
        {
        }
    }
}
