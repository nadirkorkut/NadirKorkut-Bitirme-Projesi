using SiteManager.Domain.Abstract;
using System.Collections.Generic;

namespace SiteManager.Domain.Concrete
{
    public class ExpenseType : IEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
