using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagementApp.Business.Services.Interfaces
{
    public interface IAppUserService
    {
        Task<AppUser> GetUserByIdAsync(string id);
        Task<AppUser> GetUserByEmailAsync(string email);
        Task<IdentityResult> CreateUserAsync(AppUser user, string password);
        Task<SignInResult> SignInUserAsync(AppUser user, string password, bool rememberMe);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<IList<string>> GetUserRolesAsync(AppUser user);
        Task UpdateUserAsync(AppUser user);
        Task DeleteUserAsync(string id);
    }
}
