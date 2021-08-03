using Aliquota.Infra.Contextos;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Aliquota.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            using (var scope = webHost.Services.CreateScope())
            {
                try
                {
                    var banco = scope.ServiceProvider.GetService<AliquotaContexto>();
                    banco.IniciarBancoDeDados();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetService<ILogger>();
                    logger?.LogError(ex, "Erro ao carregar os dados iniciais no banco");
                }
            }

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureKestrel((context, options) =>
            {
                options.ListenAnyIP(50001);
                options.AddServerHeader = false;
            })
            .UseStartup<Startup>();
    }
}