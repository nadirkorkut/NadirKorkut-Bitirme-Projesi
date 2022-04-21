using SiteManager.PaymentAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManager.PaymentAPI.Services.Abstract
{
    public interface ICreditCardService
    {
        Task<List<CreditCard>> GetAllAsync();
        Task<CreditCard> GetByIdAsync(string id);
        Task Add(CreditCard creditCard);
        Task Delete(string id);
        Task Update(string id, CreditCard creditCard);
    }
}
