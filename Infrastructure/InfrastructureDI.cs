using Domain.ActivityRateDomain;
using Domain.UserDomain;
using Infrastructure.Repositories.ActivityRate;
using Infrastructure.Repositories.FoodRepo;
using Infrastructure.Repositories.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IActivityRateRepository,ActivityRateRepository>();
            services.AddScoped<IFoodRepository,FoodRepository>();
            return services;
        }
    }
}
