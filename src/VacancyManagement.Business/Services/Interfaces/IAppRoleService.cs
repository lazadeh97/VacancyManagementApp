using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagementApp.Business.Services.Interfaces
{
    public interface IAppRoleService
    {
        Task<AppRole> GetRoleByIdAsync(string id);
        Task CreateRoleAsync(AppRole role);
        Task UpdateRoleAsync(AppRole role);
        Task DeleteRoleAsync(string id);
        Task AssignRoleToUserAsync(string userId, string roleName);
    }
}
