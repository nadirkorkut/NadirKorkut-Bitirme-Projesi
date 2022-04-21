namespace SiteManager.Business.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
    }
}
