using System.Threading.Tasks;
using homework_64.Models;
using homework_64.Services.Abstractions;
using homework_64.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace homework_64.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IAdminService _adminService;
 

        public ProfileController(IProfileService profileService, IAdminService adminService)
        {
            _profileService = profileService;
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                User user = await _profileService.GetUser(User.Identity.Name);
                if (user!= null)
                {
                    return View(user);
                }
            }

            return RedirectToAction("Error", "Errors", new { statusCode = 404 });
        }

        [HttpGet]
        public IActionResult Edit(int userId)
        {
            ProfileEditViewModel model = new ProfileEditViewModel();
            model.UserId = userId;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProfileEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _profileService.Edit(model);
                return View("Index");
            }
            return RedirectToAction("Error", "Errors", new { statusCode = 404 });
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllUsers()
        {
            var users = _profileService.GetUsers();
            return View(users);
        }
        
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult BlockUser(int userId)
        {
            _adminService.BlockUser(userId);
            return RedirectToAction("GetAllUsers");
        }
    }
}