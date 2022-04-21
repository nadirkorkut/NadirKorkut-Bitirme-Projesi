using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManager.Business.Abstract;
using SiteManager.Business.DTOs;
using System.Threading.Tasks;

namespace SiteManager.Web.UI.Controllers
{
    [Authorize]
    public class BuildingController : Controller
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        public async Task<IActionResult> Index()
        {
            var buildings = await _buildingService.GetAll();
            return View(buildings.Data);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult AddBuilding()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddBuilding(BuildingDto building)
        {
            if (!ModelState.IsValid)
                return View(building);

            await _buildingService.Add(building);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> UpdateBuilding(int id)
        {
            var building = await _buildingService.GetById(id);
            return View(building.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateBuilding(BuildingDto building)
        {
            if(!ModelState.IsValid)
                return View(building);

            _buildingService.Update(building);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBuilding(int id)
        {
            _buildingService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
