using Aliquota.Repository.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Services.Interfaces;
using Aliquota.Domain.Services;
using Aliquota.Repository.Repositories;
using Aliquota.Domain.Repository;

namespace Aliquota.API.IoC
{
    public static class DependencyResolution
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.DatabaseDependencies();
            services.ServiceDependencies();
            services.RepositoryDependencies();
        }

        private static void DatabaseDependencies(this IServiceCollection services)
        {
            services.AddDbContext<InvestimentoDbContext>(options =>
             options.UseInMemoryDatabase("InMemoryDatabase"));
        }
        private static void ServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
        }
        private static void RepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAplicacaoRepository, AplicacaoRepository>();
        }
    }
}
