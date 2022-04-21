using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManager.Business.Abstract;
using SiteManager.Business.DTOs;
using System.Threading.Tasks;

namespace SiteManager.Web.UI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var userList = await _userService.GetAll();
            return View(userList.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddUser(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            await _userService.CreateUser(registerDto);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> UpdateUser(string id)
        {
            var user = await _userService.GetById(id);
            return View(user.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return View(userDto);

            await _userService.UpdateUser(userDto);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UserDelete(string id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
