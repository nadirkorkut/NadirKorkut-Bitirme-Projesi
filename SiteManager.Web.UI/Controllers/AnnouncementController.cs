using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManager.Business.Abstract;
using SiteManager.Business.DTOs;
using System.Threading.Tasks;

namespace SiteManager.Web.UI.Controllers
{
    [Authorize]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var announcements = await _announcementService.GetAll();
            return View(announcements.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddAnnouncement(AnnouncementDto announcement)
        {
            if (!ModelState.IsValid)
                return View(announcement);

            await _announcementService.Add(announcement);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> UpdateAnnouncement(int id)
        {
            var announcement = await _announcementService.GetById(id);
            return View(announcement.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementDto announcement)
        {
            if (!ModelState.IsValid)
                return View(announcement);

            _announcementService.Update(announcement);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAnnouncement(int id)
        {
            _announcementService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
