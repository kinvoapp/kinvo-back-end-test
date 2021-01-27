using Aliquota.Application.Interfaces;
using Aliquota.Application.Services;
using Aliquota.Domain.Interfaces;
using Aliquota.Infra.Data.Context;
using Aliquota.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Infra.CrossCutting.IoC
{
    public static class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<AliquotaContext>();

            services.AddScoped<IContaAppService, ContaAppService>();

            services.AddScoped<IContaRepository, ContaRepository>();
        }
    }
}
