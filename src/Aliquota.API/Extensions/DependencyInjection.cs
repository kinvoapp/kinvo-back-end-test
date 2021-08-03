using Aliquota.Application.Interfaces;
using Aliquota.Application.Services;
using Aliquota.Data;
using Aliquota.Data.Repositories;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.API.Extensions
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAdicionarProdutoFinanceiroService, ProdutoFinanceiroService>();
            services.AddScoped<IObterTodosProdutosFinanceirosService, ProdutoFinanceiroService>();
            services.AddScoped<IImpostoDeRendaService, ImpostoDeRendaService> ();

            services.AddScoped<ICalculoDoImpostoDeRendaService, CalculoDoImpostoDeRendaService>();
            services.AddScoped<IProdutoFinanceiroRepository, ProdutoFinanceiroRepository>();

            services.AddScoped<AliquotaContext>();
        }
    }
}
