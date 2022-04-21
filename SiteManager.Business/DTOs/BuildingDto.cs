using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.Business.DTOs
{
    public class BuildingDto
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public byte NumberOfFlats { get; set; }
    }
}
