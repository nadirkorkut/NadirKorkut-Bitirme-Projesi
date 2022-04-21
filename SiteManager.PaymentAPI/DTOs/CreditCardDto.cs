namespace SiteManager.PaymentAPI.DTOs
{
    public class CreditCardDto
    {
        public string Owner { get; set; }
        public string CardNumber { get; set; }
        public string ValidMonth { get; set; }
        public string ValidYear { get; set; }
        public string Cvv { get; set; }
        public int Balance { get; set; }
    }
}
