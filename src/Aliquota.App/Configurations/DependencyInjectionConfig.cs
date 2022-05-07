using Aliquota.App.Extensions;
using Aliquota.Data.Context;
using Aliquota.Data.Repository;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Notificacoes;
using Aliquota.Domain.Services;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AliquotaDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPosicaoRepository, PosicaoRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IPosicaoService, PosicaoService>();

            return services;
        }
    }
}
