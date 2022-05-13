using FluentValidation.AspNetCore;
using Kinvo.Aliquota.Domain;
using Kinvo.Aliquota.Domain.Database.Interfaces.Clients;
using Kinvo.Aliquota.Domain.Database.Interfaces.DateIncomeApplications;
using Kinvo.Aliquota.Domain.Database.Interfaces.DateWithdrawals;
using Kinvo.Aliquota.Domain.Database.Interfaces.IncomeApplications;
using Kinvo.Aliquota.Domain.Database.Interfaces.Products;
using Kinvo.Aliquota.Domain.Repositories.Clients;
using Kinvo.Aliquota.Domain.Repositories.DateIncomeApplications;
using Kinvo.Aliquota.Domain.Repositories.DateWithdrawals;
using Kinvo.Aliquota.Domain.Repositories.IncomeApplications;
using Kinvo.Aliquota.Domain.Repositories.Products;
using Kinvo.Aliquota.Service.Interfaces.Clients;
using Kinvo.Aliquota.Service.Interfaces.DateIncomeApplications;
using Kinvo.Aliquota.Service.Interfaces.DateWithdrawals;
using Kinvo.Aliquota.Service.Interfaces.IncomeApplications;
using Kinvo.Aliquota.Service.Interfaces.Products;
using Kinvo.Aliquota.Validators.Clients;
using Kinvo.Aliquota.Validators.DateIncomeApplications;
using Kinvo.Aliquota.Validators.DateWithdrawals;
using Kinvo.Aliquota.Validators.IncomeApplications;
using Kinvo.Aliquota.Validators.Interfaces.Clients;
using Kinvo.Aliquota.Validators.Interfaces.DateIncomeApplications;
using Kinvo.Aliquota.Validators.Interfaces.DateWithdrawals;
using Kinvo.Aliquota.Validators.Interfaces.IncomeApplications;
using Kinvo.Aliquota.Validators.Interfaces.Products;
using Kinvo.Aliquota.Validators.Products;
using Kinvo.Aliqutota.Service.Clients;
using Kinvo.Aliqutota.Service.DateIncomeApplications;
using Kinvo.Aliqutota.Service.DateWithdrawals;
using Kinvo.Aliqutota.Service.IncomeApplications;
using Kinvo.Aliqutota.Service.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste
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
            var connection = Configuration["SqlConnection:SqlConnectionString"];
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "teste", Version = "v1" });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IClientValidator, ClientValidator>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductValidator, ProductValidator>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IIncomeApplicationService, IncomeApplicationService>();
            services.AddTransient<IIncomeApplicationValidator, IncomeApplicationValidator>();
            services.AddTransient<IIncomeApplicationRepository, IncomeApplicationRepository>();
            services.AddTransient<IDateWithdrawalService, DateWithdrawalService>();
            services.AddTransient<IDateWithdrawalValidator, DateWithdrawalValidator>();
            services.AddTransient<IDateWithdrawalRepository, DateWithdrawalRepository>();
            services.AddTransient<IDateIncomeApplicationService, DateIncomeApplicationService>();
            services.AddTransient<IDateIncomeApplicationValidator, DateIncomeApplicationValidator>();
            services.AddTransient<IDateIncomeApplicationRepository, DateIncomeApplicationRepository>();
            services.AddTransient<AppDbContext, AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "teste v1"));
            }

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
