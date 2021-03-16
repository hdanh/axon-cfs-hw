using System;
using AxonCFS.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AxonCFS.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(BindingModelToDomainMappingProfile));
        }
    }
}