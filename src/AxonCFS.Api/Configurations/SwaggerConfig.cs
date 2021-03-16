using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AxonCFS.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services, string contentRootPath)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AxonCFS API", Version = "v1" });
                var pattern = "AxonCFS.*.xml";

                var rootDir = new DirectoryInfo(contentRootPath);
                var fileInfos = rootDir.GetFiles(pattern, SearchOption.AllDirectories);
                foreach (var fileInfo in fileInfos)
                {
                    c.IncludeXmlComments(fileInfo.FullName);
                }
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AxonCFS API v1"));
        }
    }
}