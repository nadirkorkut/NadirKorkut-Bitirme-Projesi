using MongoDB.Bson.Serialization.Attributes;

namespace SiteManager.PaymentAPI.Entities
{
    public class CreditCard
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Owner { get; set; }
        public string CardNumber { get; set; }
        public string ValidMonth { get; set; }
        public string ValidYear { get; set; }
        public string Cvv { get; set; }
        public int Balance { get; set; }
    }
}
