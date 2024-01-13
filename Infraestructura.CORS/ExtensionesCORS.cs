using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infraestructura.CORS
{
    public static class ExtensionesCORS
    {
        public static IServiceCollection AddCorsApp(this IServiceCollection services, IConfiguration configuration)
        {
            return
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                         .AllowAnyHeader()
                         .AllowAnyMethod().
                         SetIsOriginAllowed(origin => true)
                         .AllowCredentials();
            }));

        }
        public static IApplicationBuilder UserCoreApp(this IApplicationBuilder app)
        {
            return app.UseCors("CorsPolicy");
        }

    }
}
