using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SiteManager.PaymentAPI.Entities;
using SiteManager.PaymentAPI.Models;
using SiteManager.PaymentAPI.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManager.PaymentAPI.Services.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly IMongoCollection<CreditCard> _creditCards;
        private readonly PaymentDatabaseSettings _settings;
        public CreditCardManager(IOptions<PaymentDatabaseSettings> settings)
        {
            _settings = settings.Value;
            MongoClient mongoClient = new MongoClient(_settings.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(_settings.DatabaseName);
            _creditCards = mongoDatabase.GetCollection<CreditCard>(_settings.PaymentCollectionName);
        }
        public async Task Add(CreditCard creditCard)
        {
            await _creditCards.InsertOneAsync(creditCard);
        }

        public async Task Delete(string id)
        {
            await _creditCards.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<CreditCard>> GetAllAsync()
        {
            return await _creditCards.Find(x => true).ToListAsync();
        }

        public async Task<CreditCard> GetByIdAsync(string id)
        {
            return await _creditCards.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task Update(string id, CreditCard creditCard)
        {
           await _creditCards.ReplaceOneAsync(x =>x.Id == id, creditCard);
        }
    }
}
