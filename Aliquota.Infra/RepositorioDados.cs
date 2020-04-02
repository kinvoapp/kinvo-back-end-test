using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Infra
{
    public partial class RepositorioDados : DbContext
    {
 
        private RepositorioDados(DbContextOptions<RepositorioDados> options) : base(options)
        {

            //this.Database. //Database.SetInitializer<RepositorioDados>(RepositorioDadosInicializador());
            //Database.UseTransaction(dbTransaction);
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StrincConectionConfig);
            }
        }

        public static string StrincConectionConfig {  private get; set; } = @"Data Source=.\Sql2019DEV;Initial Catalog=KinvoTest;Integrated Security=False;User ID=sa;Password=sa;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";


        public static RepositorioDados Factory()
        {
            return new RepositorioDados(new DbContextOptions<RepositorioDados>());
        }


    }
}
