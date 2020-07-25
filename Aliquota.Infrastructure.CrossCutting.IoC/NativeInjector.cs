using Aliquota.Application.Interface;
using Aliquota.Application.Service;
using Aliquota.Domain.Interface;
using Aliquota.Domain.Interface.Repository;
using Aliquota.Domain.Service;
using Aliquota.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aliquota.Infrastructure.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(this ServiceCollection collection)
        {
            collection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            collection.AddScoped<IClienteRepository, ClienteRepository>();
            collection.AddScoped<IAplicacaoFinanceiraRepository, AplicacaoFinanceiraRepository>();
            collection.AddScoped<IProdutoFinanceiroRepository, ProdutoFinanceiroRepository>();

            collection.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            collection.AddScoped<IAplicacaoFinanceiraService, AplicacaoFinanceiraService>();


            collection.AddScoped<IAppServiceBase, AppServiceBase>();
            collection.AddScoped<IResgateAppService, ResgateAppService>();
            collection.AddScoped<IAplicacaoFinanceiraAppService, AplicacaoFinanceiraAppService>();
        }
    }
}
