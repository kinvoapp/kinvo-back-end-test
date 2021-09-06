using KinvoTeste.Data.Config;
using KinvoTeste.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;

namespace KinvoTeste.Data
{
    public class Context : DbContext
    {
        private const string dbName = "KinvoDatabase.db";
        public Context() : base()
        {
            if (!File.Exists(dbName))
            {
                Database.EnsureCreated();
            }
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={dbName}", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new ContaConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
