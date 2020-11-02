using Income.Tax.Willian.Santos.Kinvo.Domain.CommandHandlers;
using Income.Tax.Willian.Santos.Kinvo.Domain.Entities;
using Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Queries;
using Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Repositories;
using Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Services;
using Income.Tax.Willian.Santos.Kinvo.Domain.Services;
using Income.Tax.Willian.Santos.Kinvo.Infra.Data.DataContext;
using Income.Tax.Willian.Santos.Kinvo.Infra.Data.Queries;
using Income.Tax.Willian.Santos.Kinvo.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Income.Tax.Willian.Santos.Kinvo.Infra.IoC
{
    public class InjectionOfContainer
    {
        public static void ConfigureInjection(IServiceCollection services)
        {

            // Contexto dos dados
            services.AddScoped<ApplicationITDataContext, ApplicationITDataContext>();

            // Handler
            services.AddScoped<ApplicationITCommandHandler>();

            //Services
            services.AddScoped<ICalculateAliquotITService, CalculateAliquotITService>();

            //Repositoties
            services.AddScoped<IApplicationITRepository, ApplicationITRepository>();
            services.AddScoped<ApplicationITRepository<ApplicationIT>>();

            //Queries
            services.AddScoped<IApplicationITQuery, ApplicationITQuery>();


        }
    }
}
