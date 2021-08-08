using Aliquota.Domain.Infraestrutura.DBConfig;
using Aliquota.Domain.Repositorios.ProdutoFinanceiroRp;
using Aliquota.Domain.Repositorios.TipoProdutoFinanceiroRp;
using Aliquota.Domain.Servicos.CalculoIR;
using Aliquota.Domain.Servicos.CalculoIR.Calculos;
using Aliquota.Domain.Servicos.ProdutoFinanceiroSv;
using Aliquota.Domain.Servicos.ProdutoFinanceiroSv.ValidacaoResgate;
using Aliquota.Domain.Servicos.TipoProdutoFinanceiroSv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aliquota.Domain.Infraestrutura.DIConfig
{
    public static class AliquotaDomainDIConfig
    {
        public static IServiceCollection RegistraDependencias(this IServiceCollection services, string connectionUrl)
        {
            services.AddDbContext<AliquotaContexto>
                (options => options.UseSqlServer(connectionUrl));
            services.AddScoped<IProdutoFinanceiroRepositorio, ProdutoFinanceiroRepositorio>();
            services.AddScoped<IProdutoFinanceiroServico, ProdutoFinanceiroServico>();
            services.AddScoped<ITipoProdutoFinanceiroRepositorio, TipoProdutoFinanceiroRepositorio>();
            services.AddScoped<ITipoProdutoFinanceiroServico, TipoProdutoFinanceiroServico>();
            services.AddScoped<ICalculadorIR, CalculadorIR>();
            services.AddScoped<ICalculoIR, CalculoAcimaDeDoisAnos>();
            services.AddScoped<ICalculoIR, CalculoAteUmAno>();
            services.AddScoped<ICalculoIR, CalculoDeUmADoisAnos>();
            services.AddScoped<IValidadorDataResgate, ValidacaoDataResgate>();
            return services;
        }
    }
}
