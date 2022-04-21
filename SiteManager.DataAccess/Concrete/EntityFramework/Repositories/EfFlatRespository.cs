using Microsoft.EntityFrameworkCore;
using SiteManager.DataAccess.Abstract;
using SiteManager.DataAccess.Concrete.EntityFramework.Contexts;
using SiteManager.Domain.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfFlatRespository : EfRepository<Flat>, IFlatRepository
    {
        public EfFlatRespository(SiteManagerDbContext context) : base(context)
        {
        }

        public async Task<List<Flat>> GetAllFlats()
        {
            return await _context.Flats
                .Include(x => x.User)
                .Include(x => x.Building)
                .OrderBy(x => x.FlatNumber)
                .ToListAsync();
        }
    }
}
