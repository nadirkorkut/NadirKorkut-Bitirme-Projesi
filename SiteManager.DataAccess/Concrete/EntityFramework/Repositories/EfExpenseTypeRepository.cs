using SiteManager.DataAccess.Abstract;
using SiteManager.DataAccess.Concrete.EntityFramework.Contexts;
using SiteManager.Domain.Concrete;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfExpenseTypeRepository : EfRepository<ExpenseType>, IExpenseTypeRepository
    {
        public EfExpenseTypeRepository(SiteManagerDbContext context) : base(context)
        {
        }
    }
}
