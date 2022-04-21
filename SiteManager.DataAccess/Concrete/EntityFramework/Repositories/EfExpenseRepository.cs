using Microsoft.EntityFrameworkCore;
using SiteManager.DataAccess.Abstract;
using SiteManager.DataAccess.Concrete.EntityFramework.Contexts;
using SiteManager.Domain.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfExpenseRepository : EfRepository<Expense>, IExpenseRepository
    {
        public EfExpenseRepository(SiteManagerDbContext context) : base(context)
        {
        }

        public async Task<List<Expense>> GetAllExpenses()
        {
            return await _context.Expenses
                 .Include(x => x.ExpenseType)
                 .Include(x => x.Flat)
                 .ThenInclude(x => x.User).ToListAsync();
        }
    }
}
