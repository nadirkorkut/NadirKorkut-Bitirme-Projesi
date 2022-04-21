using SiteManager.Domain.Abstract;
using System.Collections.Generic;

namespace SiteManager.Domain.Concrete
{
    public class Building : IEntity
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public byte NumberOfFlats { get; set; }
        public ICollection<Flat> Flats { get; set; }
    }
}
