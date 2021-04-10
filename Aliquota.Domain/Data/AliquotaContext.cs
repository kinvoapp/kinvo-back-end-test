using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Data
{
    class AliquotaContext : DbContext
    {
        public DbSet<Aplicacoes> Aplicacoes { get; set; }
        public DbSet<Resgates> Resgates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=" + AppContext.BaseDirectory + "AliquotaDB.db");
            base.OnConfiguring(options);
        }

        public void Start()
        {
            this.Database.EnsureCreated();
        }
    }
}
