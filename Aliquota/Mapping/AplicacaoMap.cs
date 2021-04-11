using Aliquota.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Mapping
{
    public class AplicacaoMap : EntityTypeConfiguration<Aplicacao>
    {
        public void Configure(EntityTypeBuilder<Aplicacao> builder)
        {
            ToTable("Aplicacao");
            HasKey(x => x.Id);
            Property(x => x.valor);
            Property(x => x.dataAplicacao).HasMaxLength(10);
        }
    }
}
