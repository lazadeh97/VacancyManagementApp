using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Business.DTOs;
using VacancyManagementApp.Business.Services.Interfaces;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _userService;

        public AccountController(IAppUserService userService)
        {
            _userService = userService;
        }

        // Qeydiyyat səhifəsi
        public IActionResult Register() => View();

        // Login səhifəsi
        public IActionResult Login() => View();

        // Qeydiyyat metodunda modelin doğruluğu yoxlanır
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                var result = await _userService.CreateUserAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        // Login metodunda istifadəçi doğrulaması edilir
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                // İstifadəçini username vasitəsilə tapırıq
                var user = await _userService.GetUserByUsernameAsync(model.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "User not found.");
                    return View(model);
                }

                // İstifadəçi ilə autentifikasiya (login)
                var result = await _userService.SignInUserAsync(user, model.Password, model.RememberMe);

                if (result.Succeeded)
                {
                    // İstifadəçinin rollarını yoxlayırıq
                    var roles = await _userService.GetUserRolesAsync(user);

                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else if (roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "User" });
                    }

                    // Default olaraq əsas səhifəyə yönləndir
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(model);
        }

    }
}
