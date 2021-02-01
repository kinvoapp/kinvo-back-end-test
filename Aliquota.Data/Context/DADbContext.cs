using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Data.Context
{
    public class DADbContext : DbContext
    {
        public DADbContext(DbContextOptions<DADbContext> options) : base(options) { }

        public DbSet<Aplicacao> Aplicacoes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DADbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
