using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using Aliquota.Application.AutoMapper;


namespace Aliquota.WEB.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
