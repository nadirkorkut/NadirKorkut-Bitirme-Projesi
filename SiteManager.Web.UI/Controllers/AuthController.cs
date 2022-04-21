using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteManager.Business.DTOs;
using SiteManager.Domain.Concrete;
using System.Threading.Tasks;

namespace SiteManager.Web.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginDto
            {
                ReturnURL = returnUrl
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (result.Succeeded)
                return Redirect(model.ReturnURL ?? "/Home/Index");

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
