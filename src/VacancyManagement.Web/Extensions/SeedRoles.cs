using Microsoft.AspNetCore.Identity;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagement.Web.Extensions
{
    public static class SeedRolesExtensions
    {
        public static async Task SeedRoles(this IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            string[] roles = { "SuperAdmin", "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var newRole = new AppRole
                    {
                        Name = role,
                        Description = $"{role} rolunun təsviri"
                    };
                    await roleManager.CreateAsync(newRole);
                }
            }
        }
    }
}
