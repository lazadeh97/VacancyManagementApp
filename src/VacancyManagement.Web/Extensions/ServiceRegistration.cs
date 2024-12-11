using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;
using VacancyManagementApp.Business.Services.Implementations;
using VacancyManagementApp.Business.Services.Interfaces;
using VacancyManagementApp.Core.Interfaces;
using VacancyManagementApp.Infrastructure.DAL;
using VacancyManagementApp.Infrastructure.Repositories;

namespace VacancyManagement.Web.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.ConnectionString));


            //Generics
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

            //Repositories
            services.AddScoped<IAppRoleRepository, AppRoleRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();

            //Services
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppUserService, AppUserService>();
        }
    }
}
