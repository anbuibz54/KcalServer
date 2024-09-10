using Microsoft.Extensions.DependencyInjection;
using Services.Mapper;
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
            services.AddTransient<IUserService, UserService>();
            services.AddAutoMapper(typeof(IMapperMarkerAssembly));
            return services;
        }
    }
}
