using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Data
{
    class AliquotaContext :DbContext
    {
        public DbSet<Aplicacao> Aplicacoes { get; set; }
        public DbSet<Resgate> Resgates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite("Data Source=AliquotaDB.db");
    }
}
