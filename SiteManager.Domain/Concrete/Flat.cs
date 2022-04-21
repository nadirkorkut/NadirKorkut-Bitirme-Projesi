using SiteManager.Domain.Abstract;
using System.Collections.Generic;

namespace SiteManager.Domain.Concrete
{
    public class Flat : IEntity
    {
        public int Id { get; set; }
        public byte FlatNumber { get; set; }
        public bool IsEmpty { get; set; }
        public string TypeOfFlat { get; set; } // 2+1,3+1,..
        public ICollection<Expense> Expenses { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
