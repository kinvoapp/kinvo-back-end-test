using Aliquota.BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FrameworksAndDrivers
{
    public class DataBaseContext : DbContext
    {
        public virtual DbSet<FinanceProduct> FinanceProducts { get; set; }
        public virtual DbSet<FinanceProductMove> FinanceProductMoves { get; set; }
        public virtual DbSet<FinanceProductWallet> FinanceProductWallets { get; set; }
        public virtual DbSet<ProductTradeMove> ProductTradeMoves { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DEMO;Integrated Security=True;");
        }
    }
}