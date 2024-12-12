using Microsoft.AspNetCore.Identity;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagement.Web.Extensions
{
    public static class SeedRolesExtensions
    {
        //public static async Task SeedRoles(this IServiceProvider serviceProvider)
        //{
        //    var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
        //    string[] roles = { "SuperAdmin", "Admin", "User" };

        //    foreach (var role in roles)
        //    {
        //        if (!await roleManager.RoleExistsAsync(role))
        //        {
        //            var newRole = new AppRole
        //            {
        //                Name = role
        //                //,
        //                //Description = $"{role} rolunun təsviri"
        //            };
        //            await roleManager.CreateAsync(newRole);
        //        }
        //    }
        //}

        public static async Task SeedRoles(this IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            // Rolları yarat
            var roles = new[] { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new AppRole { Name = role });
                }
            }

            // Admin istifadəçisini yarat
            var adminEmail = "admin@example.com";
            var adminPassword = "Admin@123";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new AppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "Admin User",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

    }
}
