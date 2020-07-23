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
    public class CleinteMap: IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").IsRequired();
            builder.Property(t => t.Nome).HasColumnName("nome").IsRequired();
            builder.Property(t => t.Tipo).HasColumnName("tipo").IsRequired(); 
             
        }
    }
}
