using AxonCFS.Application.Services;
using AxonCFS.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AxonCFS.Infra.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEventService, EventService>();
        }
    }
}