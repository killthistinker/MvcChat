using System.Threading.Tasks;
using homework_64.Helpers;
using homework_64.Models;
using homework_64.Services.Abstractions;
using homework_64.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace homework_64.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAccountRegisterService _register;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            IAccountRegisterService register)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _register = register;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _register.CreateAsync(model, model.UserName);
                var user = model.MapToUser();
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Error", "Errors", new {statusCode = 404});
        }

        [HttpGet]
        public IActionResult LogIn(string returnUrl = null)
        {
            return View(new LoginViewModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is null) user = await _userManager.FindByNameAsync(model.Email);
                if (user is null)
                    return View(model);
                if (user.Block)
                {
                    return RedirectToAction("Error", "Errors", new {statuscode = 406});
                }
                var result = await _signInManager.PasswordSignInAsync(
                    user,
                    model.Password,
                    model.RememberMe,
                    false
                );
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        return Redirect(model.ReturnUrl);

                    return RedirectToAction("Index", "Chat");
                }

                ModelState.AddModelError("402", "Неправильный логин и (или) пароль");
            }

            return RedirectToAction("Error", "Errors", new {statusCode = 402});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}