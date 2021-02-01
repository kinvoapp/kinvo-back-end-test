using Microsoft.Extensions.DependencyInjection;
using System;
using Aliquota.Infra.CrossCutting.IoC;

namespace Aliquota.WEB.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            DependencyInjection.RegisterServices(services);
        }
    }
}
