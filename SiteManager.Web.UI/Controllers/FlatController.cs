using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManager.Business.Abstract;
using SiteManager.Business.DTOs;
using System.Threading.Tasks;

namespace SiteManager.Web.UI.Controllers
{
    [Authorize]
    public class FlatController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBuildingService _buildingService;
        private readonly IFlatService _flatService;

        public FlatController(IUserService userService, IBuildingService buildingService, IFlatService flatService)
        {
            _userService = userService;
            _buildingService = buildingService;
            _flatService = flatService;
        }

        public async Task<IActionResult> Index()
        {
            var flats = await _flatService.GetAllFlats();
            return View(flats.Data);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> AddFlat()
        {
            var building = await _buildingService.GetAll();
            var user = await _userService.GetAll();
            var flat = new CreateFlatDto
            {
                Buildings = building.Data,
                Users = user.Data
            };

            return View(flat);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddFlat(CreateFlatDto createFlat)
        {
            if(!ModelState.IsValid)
                return View(createFlat);

            await _flatService.Add(createFlat);
            return RedirectToAction("Index");
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> UpdateFlat(int id)
        {
            var user = await _userService.GetAll();
            var building = await _buildingService.GetAll();
            var flat = await _flatService.GetById(id);

            var updateFlat = new UpdateFlatDto()
            {
                Id = flat.Data.Id,
                Users = user.Data,
                Building = building.Data,
                FlatNumber = flat.Data.FlatNumber,
                IsEmpty = flat.Data.IsEmpty,
                TypeOfFlat = flat.Data.TypeOfFlat
            };

            return View(updateFlat);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateFlat(UpdateFlatDto updateFlat)
        {
            if (!ModelState.IsValid)
                return View(updateFlat);

            _flatService.Update(updateFlat);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteFlat(int id)
        {
            _flatService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
