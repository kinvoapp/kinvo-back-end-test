using Aliquota.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Aliquota.Infra.Data.Context
{
    class AliquotaContextFactory : IDesignTimeDbContextFactory<AliquotaContext>
    {
        public AliquotaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AliquotaContext>();
            optionsBuilder.UseSqlite("Data Source=../Aliquota.Data/Database/aliquota.db");

            return new AliquotaContext(optionsBuilder.Options);
        }
    }
}
