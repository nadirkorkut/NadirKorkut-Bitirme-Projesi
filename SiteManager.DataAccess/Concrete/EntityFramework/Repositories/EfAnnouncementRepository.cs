using SiteManager.DataAccess.Abstract;
using SiteManager.DataAccess.Concrete.EntityFramework.Contexts;
using SiteManager.Domain.Concrete;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfAnnouncementRepository : EfRepository<Announcement>, IAnnouncementRepository
    {
        public EfAnnouncementRepository(SiteManagerDbContext context) : base(context)
        {

        }
    }
}
