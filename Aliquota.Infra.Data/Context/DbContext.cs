using Aliquota.Domain.Entities.Financial;
using Aliquota.Domain.Entities.Commercial;
using Aliquota.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using Aliquota.Domain.Enums;

namespace Aliquota.Infra.Data.Context
{
    public class PersistContext : DbContext
    {
        public PersistContext()
        { }

        public PersistContext(DbContextOptions<PersistContext> options)
              : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tax> Tax { get; set; }
        public DbSet<CustomerProduct> CustomerProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KinvoTestDB;");
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Telephone>().HasNoKey();
            modelBuilder.Ignore<Telephone>();

            modelBuilder.ApplyConfiguration(new CustomerMap());

            modelBuilder.Entity<Product>().HasData(

                new 
                {
                    Id = 1,
                    NmProduct = "Aplicação Financeira XPTO",
                    DtRegister = DateTime.Now,
                    Ticker = "APTEST4",
                    VlProfit = (decimal) 3000.00
                }

           ) ;

            modelBuilder.Entity<Tax>().HasData(
                new 
                {
                    Id = 1,
                    NmTax = "[IR] Até 1 ano de aplicação: 22,5% sobre o lucro",
                    VlPercentageDiscount = (decimal)22.5,
                    ProductId = 1,
                    QtMinDayDiscount = 0,
                    QtMaxDayDiscount = 365,
                    TaxAction = TaxAction.OnRescue
                },
                new 
                {
                    Id = 2,
                    NmTax = "[IR] De 1 a 2 anos de aplicação: 18,5% sobre o lucro",
                    VlPercentageDiscount = (decimal)18.5,
                    ProductId = 1,
                    QtMinDayDiscount = 366,
                    QtMaxDayDiscount = 1095,
                    TaxAction = TaxAction.OnRescue
                },
                new 
                {
                    Id = 3,
                    NmTax = "[IR] Acima 2 anos de aplicação: 15% sobre o lucro",
                    VlPercentageDiscount = (decimal)15,
                    ProductId = 1,
                    QtMinDayDiscount = 1096,
                    QtMaxDayDiscount = 999999,
                    TaxAction = TaxAction.OnRescue
                }


            );

        }

    }

    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsOne(c => c.Telephone, phone =>
            {
                phone.Property(c => c.NuTelephone)
                    .HasColumnType("varchar(150)");
            });
        }
    }

}
