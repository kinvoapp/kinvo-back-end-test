using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Aliquota.Data.Context;
using Microsoft.EntityFrameworkCore;
using Aliquota.MVC.ViewModels;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces.Repositories;
using Aliquota.Data.Repositories;
using Aliquota.Application.Interfaces;
using Aliquota.Application.Services;
using Aliquota.Domain.Interfaces.Services;
using Aliquota.Domain.Services;

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
            
            services.AddDbContext<AliquotaContext>(options => options.UseSqlite(Configuration.GetConnectionString("AliquotaContext")));
            
            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.CreateMap<AplicacaoRF, AplicacaoRFViewModel>();
                c.CreateMap<AplicacaoRFViewModel, AplicacaoRF >();
            });
            services.AddSingleton(config.CreateMapper());

            services.AddScoped<IAplicacaoRFRepository, AplicacaoRFRepository>();
            services.AddScoped<IAplicacaoRFAppService, AplicacaoRFAppService>();
            services.AddScoped<IAplicacaoRFService, AplicacaoRFService>();

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
