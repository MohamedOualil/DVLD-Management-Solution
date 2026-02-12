using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using DVLD.Infrastructure.Repositorys;
using DVLD.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLD.Infrastructure.DependencyInjection
{
    public static class DbConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IApplicationTypesRepository, ApplicationTypesRepositorys>();
            services.AddScoped<IApplicationsRepository,ApplicationsRepository>();
            services.AddScoped<ILicenseClassesRepository, LicenseClassesRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();

            return services;


        }
    }
}
