using Aliquota.Data.Context;
using Aliquota.Data.Repository;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Notificacoes;
using Aliquota.Domain.Services;

namespace Aliquota.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AliquotaDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPosicaoRepository, PosicaoRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IPosicaoService, PosicaoService>();

            return services;
        }
    }
}
