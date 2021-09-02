using AliquotaImpostoRenda.Aplicacao;
using AliquotaImpostoRenda.Aplicacao.Interface;
using AliquotaImpostoRenda.Dados.Interface;
using AliquotaImpostoRenda.Dados.Repositorio;
using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AliquotaImpostoRenda.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<IExtratoRepositorio, ExtratoRepositorio>();
            builder.Services.AddSingleton<IClienteRepositorio, ClienteRepositorio>();
            builder.Services.AddSingleton<IClienteAplicacao, ClienteAplicacao>();
            builder.Services.AddSingleton<IExtratoAplicacao, ExtratoAplicacao>();

            builder.Services.AddMatBlazor();
            builder.Services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.TopRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 5000;
            });

            await builder.Build().RunAsync();
        }
    }
}
