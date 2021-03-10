using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Web.Data
{
    class DataService : IDataService
    {
        private readonly ApplicationDbContext context;

        public DataService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void StartDB()
        {
            context.Database.Migrate();
        }
    }

    internal interface IDataService
    {
        public void StartDB();
    }
}