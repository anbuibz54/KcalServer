using Microsoft.Extensions.DependencyInjection;
using Services.ActivityRate;
using Services.Claims;
using Services.Mapper;
using Services.User;
using Services.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceDI
    {
        public static IServiceCollection AddServices(this IServiceCollection services) {
            services.AddAutoMapper(typeof(IMapperMarkerAssembly));
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IActivityRateService, ActivityService>();
            services.AddScoped<IWeatherForeCast,WeatherForeCastService>();
            services.AddSingleton<IClaimService,ClaimService>();
            return services;
        }
    }
}
