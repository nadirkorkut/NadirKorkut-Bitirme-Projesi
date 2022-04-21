using SiteManager.Domain.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManager.DataAccess.Abstract
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<List<Expense>> GetAllExpenses();
    }
}
