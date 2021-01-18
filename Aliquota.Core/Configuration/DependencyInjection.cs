using Aliquota.Core.Service;
using Aliquota.Core.Interface;
using Aliquota.Domain.Repository;
using Aliquota.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Aliquota.Core.Configuration
{
    /// Dependency Injection Class
    public static class DependencyInjection
    {
        /// Dependency Injection Register
        public static void RegisterDependencyInjection(IServiceCollection services) => ConfigureServiceRepository(services);

        /// Dependency Injection Configure
        public static void ConfigureServiceRepository(IServiceCollection services)
        {
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
