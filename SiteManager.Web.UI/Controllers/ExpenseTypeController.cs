using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManager.Business.Abstract;
using SiteManager.Business.DTOs;
using System.Threading.Tasks;

namespace SiteManager.Web.UI.Controllers
{
    [Authorize]
    public class ExpenseTypeController : Controller
    {
        private readonly IExpenseTypeService _expenseTypeService;

        public ExpenseTypeController(IExpenseTypeService expenseTypeService)
        {
            _expenseTypeService = expenseTypeService;
        }

        public async Task<IActionResult> Index()
        {
            
            var expenseType = await _expenseTypeService.GetAll();
            return View(expenseType.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddExpenseType()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddExpenseType(ExpenseTypeDto expenseType)
        {
            if(!ModelState.IsValid)
                return View(expenseType);

            await _expenseTypeService.Add(expenseType);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> UpdateExpenseType(int id)
        {
            var expenseType = await _expenseTypeService.GetById(id);
            if (expenseType.Data == null)
                return RedirectToAction("Index");

            return View(expenseType.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateExpenseType(ExpenseTypeDto expenseType)
        {
            if(!ModelState.IsValid)
                return View(expenseType);

            _expenseTypeService.Update(expenseType);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteExpenseType(int id)
        {
            _expenseTypeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
