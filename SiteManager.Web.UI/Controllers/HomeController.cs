using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiteManager.Business.Abstract;
using SiteManager.Business.DTOs;
using SiteManager.Domain.Concrete;
using SiteManager.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManager.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IBuildingService _buildingService;
        private readonly IExpenseService _expenseService;
        private readonly IExpenseTypeService _expenseTypeService;
        private readonly IFlatService _flatService;
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public HomeController(IAnnouncementService announcementService, IBuildingService buildingService, IExpenseService expenseService, IExpenseTypeService expenseTypeService, IFlatService flatService, IUserService userService, IMessageService messageService, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _announcementService = announcementService;
            _buildingService = buildingService;
            _expenseService = expenseService;
            _expenseTypeService = expenseTypeService;
            _flatService = flatService;
            _userService = userService;
            _messageService = messageService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var announcements = await _announcementService.GetAll();
            return View(announcements.Data);
        }
        public async Task<IActionResult> GetAllBuilding()
        {
            var buildings = await _buildingService.GetAll();
            return View(buildings.Data);
        }
        public async Task<IActionResult> GetAllFlat()
        {
            var flats = await _flatService.GetAllFlats();
            return View(flats.Data);
        }
        public async Task<IActionResult> GetExpense()
        {
            var user = _userService.GetUserSession();
            var expense = await _expenseService.GetAllExpenses();
            var expenseDetail = expense.Data.Where(x => x.IsPayment == false && x.UserName == user.UserName).ToList();
            return View(expenseDetail);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
