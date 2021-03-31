using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Data;
using Aliquota.Domain.Data.Interfaces;
using Aliquota.Domain.Negocio;
using Aliquota.Domain.Negocio.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Aliquota.WebApp
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
            services.AddDbContext<AliquotaContext>(options => options.UseLazyLoadingProxies().UseSqlite(Configuration.GetConnectionString("SQLiteConnection")));

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IAplicacaoService, AplicacaoService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAplicacaoRepository, AplicacaoRepository>();
            services.AddScoped<IProdutoFinanceiroRepository, ProdutoFinanceiroRepository>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
