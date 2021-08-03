using Aliquota.Infra.Contextos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Aliquota.Host
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AdicionarServicos(Configuration);
            services.AdicionarBancoDeDados<AliquotaContexto>(Configuration);
            AdicionarServicoSwagger(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseHsts();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigurarAplicacaoSwagger(app);
        }

        private static void AdicionarServicoSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Avaliação Kinvo",
                    Version = "beta",
                    Description = "Documentação da API para Desafio Kinvo",
                    Contact = new OpenApiContact
                    {
                        Name = "Alexandre Dórea",
                        Email = "alexandre.dorea@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/alexandredorea/")
                    },
                });
            });
        }

        private static void ConfigurarAplicacaoSwagger(IApplicationBuilder app)
        {
            app.UseSwagger(x =>
            {
                x.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(x =>
            {
                x.RoutePrefix = string.Empty;
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Interface padrão swagger");
            });
        }
    }
}