using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Aliquota.Domain.Entities;
using Aliquota.Infra.Data.Context;
using Aliquota.MVC.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace Aliquota.MVC
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
            //string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //// Your DB filename    
            //string dbFileName = ".\\Database";
            //string absolutePath = Path.Combine(currentPath, dbFileName);


            //services.AddDbContext<AliquotaContext>(options =>
            //        options.UseSqlite(new ConnectionStringsWriter();




            services.AddDbContext<AliquotaContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("AliquotaContext")));


            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AplicacaoFinanceiraViewModel, AplicacaoFinanceira>();
                cfg.CreateMap<AplicacaoFinanceira, AplicacaoFinanceiraViewModel >();
            });
            services.AddSingleton(config.CreateMapper());
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
