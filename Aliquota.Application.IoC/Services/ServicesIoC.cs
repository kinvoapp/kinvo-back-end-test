using Aliquota.Application.Interfaces.Services;
using Aliquota.Application.Interfaces.Services.Standard;
using Aliquota.Application.Services;
using Aliquota.Application.Services.Standard;
using Microsoft.Extensions.DependencyInjection;

namespace Aliquota.Application.IoC.Services
{
    public static class ServicesIoC
    {
        public static void ApplicationServicesIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddScoped<IAplicacaoFinanceiraService, AplicacaoFinanceiraService>();
        }
    }
}
