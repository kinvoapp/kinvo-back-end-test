using Aliquota.Infraestructure.DBConfiguration;
using Microsoft.Extensions.Configuration;

namespace Aliquota.Infraestructure.IoC
{
    internal class ResolveConfiguration
    {
        public static IConfiguration GetConnectionSettings(IConfiguration configuration)
        {
            return configuration ?? DatabaseConnection.ConnectionConfiguration;
        }
    }
}
