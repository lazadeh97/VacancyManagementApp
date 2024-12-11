using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Core.Entities;
using VacancyManagementApp.Core.Interfaces;
using VacancyManagementApp.Infrastructure.DAL;

namespace VacancyManagementApp.Infrastructure.Repositories
{
    //public class AppRoleRepository : GenericRepository<AppRole>, IAppRoleRepository
    //{
    //    public AppRoleRepository(ApplicationDbContext context) : base(context) { }

    //    public async Task<AppRole> GetRoleByNameAsync(string roleName)
    //    {
    //        return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
    //    }
    //}
}
