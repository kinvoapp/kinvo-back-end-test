using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Contexto
{
    public class AplicacaoContext : DbContext
    {
        public AplicacaoContext(DbContextOptions<AplicacaoContext> options) : base(options) {}
        public DbSet<AplicacaoModel> Aplicacao { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AplicacaoModel>().HasKey(m => m.AplicacaoId);
            base.OnModelCreating(builder);
        }
    }
}
