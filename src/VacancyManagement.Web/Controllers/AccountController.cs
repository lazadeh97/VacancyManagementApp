using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Business.DTOs;
using VacancyManagementApp.Business.Services.Interfaces;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IAppUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // Qeydiyyat səhifəsi
        public IActionResult Register() => View();

        // Login səhifəsi
        public IActionResult Login()
        {
            var model = new LoginDTO();
            return View(model);
        } 

        // Qeydiyyat metodunda modelin doğruluğu yoxlanır
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterDTO model)
        {
          
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<AppUser>(model);
                
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginDTO model)
        {
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            //    foreach (var error in errors)
            //    {
            //        Console.WriteLine(error.ErrorMessage);
            //    }
            //}
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
                    return RedirectToAction("Index", "Vacancies");
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
