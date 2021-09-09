using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.WebApp.DbConfiguration
{
    public class DataService : IDataService
    {
        private readonly AliquotaContext context;

        public DataService(AliquotaContext context) => this.context = context;

        public void InicializeDb() => this.context.Database.Migrate();
    }
}
