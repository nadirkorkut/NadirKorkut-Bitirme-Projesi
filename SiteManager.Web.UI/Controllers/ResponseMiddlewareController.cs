using Microsoft.AspNetCore.Mvc;

namespace SiteManager.Web.UI.Controllers
{
    public class ResponseMiddlewareController : Controller
    {
        public IActionResult PageNotFound()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult InternalServerError()
        {
            return View();
        }
    }
}
