using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManager.PaymentAPI.DTOs;
using SiteManager.PaymentAPI.Entities;
using SiteManager.PaymentAPI.ResponseMessage;
using SiteManager.PaymentAPI.Services.Abstract;
using System.Threading.Tasks;

namespace SiteManager.PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public PaymentController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var creditCards = await _creditCardService.GetAllAsync();

            if(creditCards != null)
                return Ok(creditCards);

            return BadRequest(creditCards);
        }

        [Route("CreateCreditCard")]
        [HttpPost]
        public async Task<string> CreateCreditCard(CreditCardDto creditCardDto)
        {
            var creditCard = new CreditCard()
            {
                Owner = creditCardDto.Owner,
                CardNumber = creditCardDto.CardNumber,
                ValidMonth = creditCardDto.ValidMonth,
                ValidYear = creditCardDto.ValidYear,
                Cvv = creditCardDto.Cvv,
                Balance = creditCardDto.Balance
            };

            await _creditCardService.Add(creditCard);
            return "Credit Card created successfully";
        }
    }
}
