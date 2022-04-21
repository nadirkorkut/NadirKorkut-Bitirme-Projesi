using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.Business.DTOs
{
    public class CreateFlatDto
    {
        public byte FlatNumber { get; set; }
        public bool IsEmpty { get; set; }
        public string TypeOfFlat { get; set; }
        public string UserId { get; set; }
        public int BuildingId { get; set; }

        public ICollection<BuildingDto> Buildings { get; set; } 
        public ICollection<UserDto> Users { get; set; }
    }
}
