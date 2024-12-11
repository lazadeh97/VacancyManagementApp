using Microsoft.AspNetCore.Identity;
using System;
using VacancyManagement.Web.Extensions;
using VacancyManagementApp.Core.Entities;
using VacancyManagementApp.Infrastructure.DAL;

var builder = WebApplication.CreateBuilder(args);

//Adding Services, Repositories and DBConnection
builder.Services.AddServices();

builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.Lockout.MaxFailedAccessAttempts = 5;

    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

//Call SeedRoles method for creating Roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await services.SeedRoles();  // SeedRoles method
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    // Default route
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Account route
    endpoints.MapAreaControllerRoute(
     name: "Account",
     areaName: "Account",
     pattern: "Account/{controller=Account}/{action=Login}/{id?}");

    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

    endpoints.MapAreaControllerRoute(
        name: "User",
        areaName: "User",
        pattern: "User/{controller=Dashboard}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
