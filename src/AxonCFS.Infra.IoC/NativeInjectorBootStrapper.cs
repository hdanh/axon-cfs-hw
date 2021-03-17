using AxonCFS.Application.Services;
using AxonCFS.Application.Services.Interfaces;
using AxonCFS.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace AxonCFS.Infra.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();

            services.AddScoped<IEventService, EventService>();
        }
    }
}