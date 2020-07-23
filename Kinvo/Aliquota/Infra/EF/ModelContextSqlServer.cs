

#region

using System;
using Aliquota.Domain;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Aliquota.Infra.EF
{
    public class ModelContextSqlServer : DbContext
    {
        public DbSet<Produto>Produtos { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        #region Metodos

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
                var conn1 = $"Server=localhost\\SQLEXPRESS;Initial Catalog=db_test;Persist Security Info=True;User ID=sa;Password=123456;MultipleActiveResultSets=True";

                options.UseSqlServer(conn1).UseLazyLoadingProxies(false);
        }

        #region  Métodos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ModelContextSqlServer).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        }

        #endregion

        #endregion
    }
}
