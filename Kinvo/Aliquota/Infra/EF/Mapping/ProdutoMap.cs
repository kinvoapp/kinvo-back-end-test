using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliquota.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Infra.EF.Mapping
{
    public class ProdutoMap: IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").IsRequired();
            builder.Property(t => t.Nome).HasColumnName("nome").IsRequired();
            builder.Property(t => t.Data).HasColumnName("data").IsRequired();
            builder.Property(t => t.PercentualRedimento).HasColumnName("percentualredimento").IsRequired();
            builder.Property(t => t.Saldo).HasColumnName("saldo").IsRequired();
             
        }
    }
}
