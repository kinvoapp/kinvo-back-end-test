using Aliquota.Application.Interfaces;
using Aliquota.Application.Interfaces.Repositories;
using Aliquota.Persistance.Contexts;
using Aliquota.Persistance.Repositories;
using Aliquota.Persistance.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aliquota.Persistance
{
    public static class DependencyInjectionInfrasctructure
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IFinancialProductRepository, FinancialProductRepository>();
            services.AddTransient<IInvestmentRepository, InvestmentRepository>();
            services.AddTransient<IWithdrawRepository, WithdrawRepository>();
            #endregion
        }
    }
}
