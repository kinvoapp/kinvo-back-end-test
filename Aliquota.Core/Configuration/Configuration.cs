using Aliquota.Core.Service;
using Aliquota.Core.Interface;
using Aliquota.Domain.Repository;
using Aliquota.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using Aliquota.Domain.Repository.Context;
using MVPlayer.Core.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aliquota.Core.Configuration
{
    /// General configurations Class
    public static class Configuration
    {
        /// <summary>
        /// Create LoggerFactory
        /// </summary>
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        /// General configurations Register
        public static void RegisterConfigurations(IServiceCollection services) => ConfigurationsService(services);

        /// General configurations
        public static void ConfigurationsService(IServiceCollection services)
        {
            #region Database Configuration
            string connectionString = EnvConstants.DATABASE_CONNECTION_STRING;

            #if(DEBUG)
            services.AddDbContext<AliquotContext>(options => options
                .UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseNpgsql(connectionString));
            #else
                services.AddDbContext<AliquotContext>(options => options.UseNpgsql(connectionString));
            #endif

            #endregion
        }
    }
}
