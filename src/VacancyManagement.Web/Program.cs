using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using VacancyManagement.Business.Profiles;
using VacancyManagement.Business.Validators;
using VacancyManagement.Web.Extensions;
using VacancyManagementApp.Core.Entities;
using VacancyManagementApp.Infrastructure.DAL;

var builder = WebApplication.CreateBuilder(args);

//Adding Services, Repositories and DBConnection
builder.Services.AddServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
//builder.Services.AddAutoMapper(typeof(CustomMapper));
// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

//Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<RegisterDtoValidator>();

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
       pattern: "{controller=Vacancies}/{action=Index}/{id?}");

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

    // CV-lər üçün route
    endpoints.MapControllerRoute(
        name: "cv",
        pattern: "CV/ViewApplicantCVs/{applicantId?}",
        defaults: new { controller = "CV", action = "ViewApplicantCVs" });
});

app.MapRazorPages();

app.Run();
