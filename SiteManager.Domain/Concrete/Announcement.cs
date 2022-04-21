using SiteManager.Domain.Abstract;

namespace SiteManager.Domain.Concrete
{
    public class Announcement : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
