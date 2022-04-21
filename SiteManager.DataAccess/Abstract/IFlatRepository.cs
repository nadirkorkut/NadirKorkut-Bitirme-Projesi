using SiteManager.Domain.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManager.DataAccess.Abstract
{
    public interface IFlatRepository : IRepository<Flat>
    {
        Task<List<Flat>> GetAllFlats();
    }
}
