namespace SiteManager.PaymentAPI.Models
{
    public class PaymentDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string PaymentCollectionName { get; set; }
    }
}
