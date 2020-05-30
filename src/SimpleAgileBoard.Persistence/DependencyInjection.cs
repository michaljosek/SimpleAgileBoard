using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            // services.AddScoped(provider => provider.GetService<ApplicationDbContext>());

            // services.AddDefaultIdentity<ApplicationUser>()
            //     .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
