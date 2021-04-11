using Aliquota.Domain;
using Aliquota.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Data
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<IR> IR { get; set; }
        public virtual DbSet<Aplicacao> Aplicacao { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:aliquota-domaindbserver.database.windows.net,1433;Initial Catalog=Aliquota.Domain_db;Persist Security Info=False;
                                        User ID=aliquota;Password=Henrique1299;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime d1 = DateTime.ParseExact(("22/12/2021"), "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime d2 = DateTime.ParseExact(("19/09/1999"), "d/M/yyyy", CultureInfo.InvariantCulture);
            Lucro l = new Lucro(d1, d2, 0.088, 1000);

            modelBuilder.Entity<IR>().HasData(
                 new IR
                 {
                     Id = 1,
                     valor = 1000,
                     dataResgate = d1,
                     dataAplicacao = d2,
                     ir = l.getLucro() * l.getAliquota(),
                     lucro = l.getLucro(),
                     aliquota = l.getAliquota()
                 });
            modelBuilder.Entity<Aplicacao>().HasData(
                 new Aplicacao
                 {
                     Id = 2,
                     valor = 2000,
                     dataAplicacao = d2
                 },
                 new Aplicacao
                 {
                     Id = 3,
                     valor = 3000,
                     dataAplicacao = d2
                 }
            ); ;
        }
    }
}
