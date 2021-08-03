using Aliquota.Domain.Infra.Contextos.Base;
using Aliquota.Domain.Infra.Repositorios;
using Aliquota.Domain.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstalarDependencias
    {
        public static void AdicionarBancoDeDados<TipoContexto, ChavePrimaria>(this IServiceCollection servicos, IConfiguration configuracao)
            where TipoContexto : ContextoBase
        {
            //servicos.AddDbContext<TipoContexto>();
            servicos.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<TipoContexto>(opcao =>
                {
                    opcao.UseInMemoryDatabase(databaseName: "MeuBanco");
                });
            servicos.AddScoped<IRepositorioBase<ChavePrimaria>, RepositorioBase<TipoContexto, ChavePrimaria>>();
        }

        public static void AdicionarBancoDeDados<TipoContexto>(this IServiceCollection servicos, IConfiguration configuracao)
            where TipoContexto : ContextoBase
        {
            //servicos.AddDbContext<TipoContexto>();
            servicos.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<TipoContexto>(opcao =>
                {
                    opcao.UseInMemoryDatabase(databaseName: "MeuBanco");
                });
            servicos.AddScoped<IRepositorioBase, RepositorioBase<TipoContexto>>();
        }
    }
}