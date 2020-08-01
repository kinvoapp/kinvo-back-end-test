using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquota.Infra.Data.Context
{
    public class AliquotaContext: DbContext
    {
        public AliquotaContext(DbContextOptions<AliquotaContext> options) : base(options)
        {

        }

        public DbSet<AplicacaoFinanceira> Aplicacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entity.ClrType).ToTable(entity.ClrType.Name);

            }


        }


    }
}
