using System;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Investimento> Investimentos {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AliquotaDomain;Trusted_Connection=True;");
        }

    }
}