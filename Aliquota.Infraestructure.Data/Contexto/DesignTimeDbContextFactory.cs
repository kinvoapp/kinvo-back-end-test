using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Aliquota.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Contexto>();
            builder.UseSqlServer("Server=localhost;Database=Aliquota;User Id=sa;Password=root;",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(Contexto).GetTypeInfo().Assembly.GetName().Name));

            return new Contexto(builder.Options);
        }
    }
}
