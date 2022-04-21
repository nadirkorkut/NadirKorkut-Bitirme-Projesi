using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManager.Business.Abstract;
using SiteManager.Business.DTOs;
using System;
using System.Threading.Tasks;

namespace SiteManager.Web.UI.Controllers
{
    [Authorize]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IExpenseTypeService _expenseTypeService;
        private readonly IFlatService _flatService;

        public ExpenseController(IExpenseService expenseService, IExpenseTypeService expenseTypeService, IFlatService flatService)
        {
            _expenseService = expenseService;
            _expenseTypeService = expenseTypeService;
            _flatService = flatService;
        }

        public async Task<IActionResult> Index()
        {
            var expense = await _expenseService.GetAllExpenses();
            return View(expense.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddExpense()
        {
            var expenseType = await _expenseTypeService.GetAll();
            var flat = await _flatService.GetAll();
            var createExpense = new CreateExpenseDto
            {
                ExpenseTypes = expenseType.Data,
                Flats = flat.Data,
            };
            
            return View(createExpense);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddExpense(CreateExpenseDto createExpense)
        {
            if(!ModelState.IsValid)
                return View(createExpense);

            createExpense.InvoiceDate = DateTime.Now;
            createExpense.IsPaid = false;

            await _expenseService.Add(createExpense);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateExpense(int id)
        {
            var flat = await _flatService.GetAll();
            var expenseType = await _expenseTypeService.GetAll();
            var expense = await _expenseService.GetById(id);

            var updateExpense = new UpdateExpenseDto()
            {
                Id = expense.Data.Id,
                Flats = flat.Data,
                ExpenseTypes = expenseType.Data,
                Price = expense.Data.Price,
                InvoiceDate = DateTime.Now,
                IsPayment = expense.Data.IsPayment
            };

            return View(updateExpense);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateExpense(UpdateExpenseDto updateExpense)
        {
            if (!ModelState.IsValid)
                return View(updateExpense);

            _expenseService.Update(updateExpense);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteExpense(int id)
        {
            _expenseService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
