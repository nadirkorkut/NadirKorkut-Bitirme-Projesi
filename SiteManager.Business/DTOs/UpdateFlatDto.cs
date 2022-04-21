using System.Collections.Generic;

namespace SiteManager.Business.DTOs
{
    public class UpdateFlatDto
    {
        public int Id { get; set; }
        public byte FlatNumber { get; set; }
        public bool IsEmpty { get; set; }
        public string TypeOfFlat { get; set; }
        public string UserId { get; set; }
        public int BuildingId { get; set; }
        public ICollection<BuildingDto> Building { get; set; }
        public ICollection<UserDto> Users { get; set; }
    }
}
