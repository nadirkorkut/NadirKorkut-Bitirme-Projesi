using Microsoft.AspNetCore.Identity;
using SiteManager.Domain.Abstract;
using System.Collections.Generic;

namespace SiteManager.Domain.Concrete
{
    public class User : IdentityUser, IEntity
    {
        public string NationalityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicensePlate { get; set; }
        public ICollection<Flat> Flats { get; set; }
    }
}
