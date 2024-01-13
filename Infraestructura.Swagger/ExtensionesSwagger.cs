using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infraestructura.Swagger
{
    public static class ExtensionesSwagger
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            return
            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc(SwaggerConfiguration.DocNameV1, new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = SwaggerConfiguration.DocInfoTitle,
                    Version = SwaggerConfiguration.DocInfoVersion,
                    Description = SwaggerConfiguration.DocInfoDescription,
                    Contact = new OpenApiContact
                    {
                        Name = SwaggerConfiguration.ContactName

                    }

                });
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //options.IncludeXmlComments(xmlPath);


                options.AddSecurityDefinition(
                      "Bearer", new OpenApiSecurityScheme
                      {
                          Description = " TOKEN VALIDATION",
                          Name = "AUTHORIZATION",
                          In = ParameterLocation.Header,
                          Type = SecuritySchemeType.ApiKey,
                          Scheme = "Bearer"

                      });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "OAuth",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });


            });
        }
        public static IApplicationBuilder UserSwaggerLink(this IApplicationBuilder app)
        {
            app.UseSwagger();

            return app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}" + SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);

            });
        }
    }
}
