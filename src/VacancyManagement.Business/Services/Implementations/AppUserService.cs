using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Business.Services.Interfaces;
using VacancyManagementApp.Core.Entities;
using VacancyManagementApp.Core.Interfaces;

namespace VacancyManagementApp.Business.Services.Implementations
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"User creation failed. Errors: {errors}");
            }
            return result;
        }

        public async Task<SignInResult> SignInUserAsync(AppUser user, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);
            return result;
        }
        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<IList<string>> GetUserRolesAsync(AppUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        Task IAppUserService.DeleteUserAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<AppUser> IAppUserService.GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        Task<AppUser> IAppUserService.GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task IAppUserService.UpdateUserAsync(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
