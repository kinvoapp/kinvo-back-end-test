using Aliquota.Domain.Interfaces.Servicos;
using Aliquota.Domain.Servicos;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstalarDependencias
    {
        public static void AdicionarServicos(this IServiceCollection servicos, IConfiguration configuracao)
        {
            servicos.AddMediatR(Assembly.GetExecutingAssembly());
            servicos.TryAddScoped<IProdutoFinanceiroServico, ProdutoFinanceiroServico>();
            servicos.TryAddScoped<IAplicacaoFinanceiraServico, AplicacaoFinanceiraServico>();
        }
    }
}