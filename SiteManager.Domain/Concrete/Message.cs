using SiteManager.Domain.Abstract;

namespace SiteManager.Domain.Concrete
{
    public class Message : IEntity
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
    }
}
