using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Infra.Context
{
    public class appcontext : DbContext
    {
        public appcontext(DbContextOptions<appcontext> options) : base(options) { }

        public DbSet<productfinancial> productfinancials { get; set; }

        public DbSet<client> clients { get; set; }

        public DbSet<application> applications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Password=sql@2020#;Persist Security Info=True;User ID=sa;Initial Catalog=kinvoapp;Data Source=DESKTOP-OTKFBNT");
            }
        }
    }
}
