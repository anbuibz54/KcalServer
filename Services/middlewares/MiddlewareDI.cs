using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.middlewares
{
    public static class MiddlewareDI
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app) {
            app.UseMiddleware<HandleExceptionMiddleware>();
            return app;
        }
    }
}
