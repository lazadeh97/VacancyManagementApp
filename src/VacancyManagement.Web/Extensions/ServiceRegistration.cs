using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;
using VacancyManagementApp.Infrastructure.DAL;

namespace VacancyManagement.Web.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.ConnectionString));



            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

            //services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            //services.AddScoped<IProductCategoryService, ProductCategoryService>();
            //services.AddScoped<IAppUserService, UserService>();
        }
    }
}
