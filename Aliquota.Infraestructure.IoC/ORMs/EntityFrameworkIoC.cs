using Aliquota.Infraestructure.DBConfiguration;
using Aliquota.Infraestructure.Interfaces.Repositories.Domain;
using Aliquota.Infraestructure.Interfaces.Repositories.Standard;
using Aliquota.Infraestructure.Repositories;
using Aliquota.Infraestructure.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aliquota.Infraestructure.IoC.ORMs
{
    public class EntityFrameworkIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            string conn = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conn));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAplicacaoFinanceiraRepository, AplicacaoFinanceiraRepository>();

            return services;
        }
    }
}
