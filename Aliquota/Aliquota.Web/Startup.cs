using Aliquota.CrossCutting.IoC;
using Aliquota.Domain.Business.Implementacao.Business;
using Aliquota.Domain.Repository.Implementacao.Base;
using Aliquota.Domain.Repository.Implementacao.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Aliquota.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AliquotaDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AliquotaDbContext")));
            services.AddScoped<BaseDeDados>();
            services.AddScoped<ClienteBusiness>();
            services.AddScoped<TipoProdutoBusiness>();
            services.AddScoped<SituacaoProdutoBusiness>();
            services.AddScoped<ProdutoBusiness>();
        }
        public void ConfigureContainer(IUnityContainer container)
        {
            ProdutoIoC.Registar(container, GetLifeTimeWeb);

            TipoProdutoIoC.Registar(container, GetLifeTimeWeb);

            SituacaoProdutoIoC.Registar(container, GetLifeTimeWeb);

            ClienteIoC.Registar(container, GetLifeTimeWeb);

        }
        private ITypeLifetimeManager GetLifeTimeWeb()
        {
            return new TransientLifetimeManager();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BaseDeDados baseDeDados)
        {
            var ptBr = new CultureInfo("pt-BR");
            var localizacao = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ptBr),
                SupportedCultures = new List<CultureInfo> { ptBr },
                SupportedUICultures = new List<CultureInfo> { ptBr }

            };
            app.UseRequestLocalization(localizacao);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                baseDeDados.Gerar();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
