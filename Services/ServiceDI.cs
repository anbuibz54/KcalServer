using Microsoft.Extensions.DependencyInjection;
using Services.User;
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
            services.AddSingleton<IUserService, UserService>();
            return services;
        }
    }
}
