using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apitipocambio.provider;
//using apitipocambio.provider.filter;
//using apitipocambio.provider.transport.jwt;
using EntidadesAplicacion;
using Infraestructura.CORS;
using Infraestructura.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace apitipocambio
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             
            services.AddMemoryCache();
            //services.AddSingleton<IJwtHandler, JwtHandler>();
            //services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
            //services.AddTransient<TokenManagerMiddleware>();
            //services.AddTransient<ITokenManager, TokenManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //var jwtSection = Configuration.GetSection("jwtTokenConfig");
            //var jwtOptions = new JwtOptions();
            //jwtSection.Bind(jwtOptions);
            //services.AddAuthentication()
            //    .AddJwtBearer(cfg =>
            //    {
            //        cfg.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
            //            ValidIssuer = jwtOptions.Issuer,
            //            ValidateAudience = false,
            //            ValidateLifetime = true,
            //            ClockSkew = TimeSpan.Zero
            //        };
            //    });
            //services.Configure<JwtOptions>(jwtSection);


            services.ConfigureDI(Configuration.GetConnectionString("Connetion"));

            //services.AddControllers();
            #region Cors
            //CORS para aceptar verbos any
            services.AddCorsApp(Configuration);
            #endregion

            #region Swagger
            services.AddSwagger(Configuration);
            #endregion


            services.AddControllers();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting(); 
            app.UserCoreApp();
            app.UserSwaggerLink();
            app.UseHttpsRedirection();
            app.UseAuthentication(); //
            app.UseAuthorization(); //JWT,Bearer,
            //app.UseMiddleware<ErrorHandlerMiddleware>();
            //app.UseAuthentication();
            //app.UseMiddleware<TokenManagerMiddleware>();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
