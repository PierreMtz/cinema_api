using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Appli_Cinéma.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services
                .AddSwaggerGen(setupAction =>
                {
                    setupAction.SwaggerDoc("Cinema.APIOpenAPISpecification", new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "City.API",
                        Version = "0.1"
                    });
                    var xmlCommentsfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsfile);

                    setupAction.IncludeXmlComments(xmlCommentsFullPath);
                });
            return services;
        }

        public static IApplicationBuilder UseSwaggerAsHome(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/Cinema.APIOpenAPISpecification/swagger.json", "Best API ever");
                setupAction.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
