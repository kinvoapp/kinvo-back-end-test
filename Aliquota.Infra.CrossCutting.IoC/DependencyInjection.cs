using Aliquota.Application.Interfaces;
using Aliquota.Application.Services;
using Aliquota.Data.Context;
using Aliquota.Data.Repository;
using Aliquota.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Aliquota.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<DADbContext>();

            services.AddScoped<IAplicacaoService, AplicacaoService>();

            services.AddScoped<IAplicacaoRepository, AplicacaoRepository>();
        }
    }
}
