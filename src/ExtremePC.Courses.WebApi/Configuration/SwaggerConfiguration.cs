using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ExtremePC.Courses.WebApi.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwaggerSerivce(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Courses API", Version = "v1" });

                var docFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, docFile);

                if (File.Exists(filePath))
                    config.IncludeXmlComments(filePath);
            });
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Courses API");
                c.RoutePrefix = "swagger";
            });

            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapGet(string.Empty, ctx =>
            {
                ctx.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
            app.UseRouter(routeBuilder.Build());
        }
    }
}
