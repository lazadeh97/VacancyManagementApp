using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;
using VacancyManagement.Business.Services.Implementations;
using VacancyManagement.Business.Services.Interfaces;
using VacancyManagement.Core.Entities;
using VacancyManagement.Core.Interfaces;
using VacancyManagement.Infrastructure.Repositories;
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
            services.AddScoped<ITestQuestionRepository, TestQuestionRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<IGenericRepository<ApplicantCV>, GenericRepository<ApplicantCV>>();


            services.AddScoped<IAppRoleRepository, AppRoleRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();

            //Services
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppRoleService, AppRoleService>();
            services.AddScoped<IAppRoleService, AppRoleService>();


        }
    }
}
