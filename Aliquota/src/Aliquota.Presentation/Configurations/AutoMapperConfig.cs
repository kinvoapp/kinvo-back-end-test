using Aliquota.Application.AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aliquota.Presentation.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
