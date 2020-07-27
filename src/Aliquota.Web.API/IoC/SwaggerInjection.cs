using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Aliquota.API.IoC
{
    public static class SwaggerInjection
    {
        private const string APINAME = "Investimentos API";

        public static void UseSwagger(this IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = APINAME, Version = "v1" });
            });
        }

        public static void ConfigureSwaggerUI(this  IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", APINAME);
            });
        }
    }
}
