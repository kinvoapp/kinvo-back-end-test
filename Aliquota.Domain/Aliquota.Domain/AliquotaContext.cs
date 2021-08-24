using System;
using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using static Aliquota.Domain.Models.Aplicacao;

#nullable disable

namespace Aliquota.Domain
{
    public partial class AliquotaContext : DbContext
    {
        public AliquotaContext()
        {
        }

        public AliquotaContext(DbContextOptions<AliquotaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Aplicacao> Aplicacoes { get; set; }
        public virtual DbSet<Resgate> Resgates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Resgate>(entity =>
            {
                entity.ToTable("Resgate");

                entity.Property(e => e.ResgateId).HasColumnName("ResgateID");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.AplicacaoId).HasColumnName("AplicacaoID");

                entity.Property(e => e.ValorIr).HasColumnName("ValorIR");

                entity.HasIndex(e => e.AplicacaoId, "UQ__Resgate__55823511ED222B91")
                    .IsUnique();

                entity.HasOne(d => d.Aplicacao)
                    .WithOne(p => p.Resgate)
                    .HasForeignKey<Resgate>(d => d.AplicacaoId)
                    .HasConstraintName("FK__Resgate__Aplicac__4CA06362");
            });
            
            modelBuilder.Entity<Aplicacao>(entity =>
            {
                entity.ToTable("Aplicacao");

                entity.Property(e => e.AplicacaoId).HasColumnName("AplicacaoID");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Periodicidade)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasConversion(p => (char)p, p => (Periodicidades)p);

                entity.HasOne(d => d.Cliente)
                                    .WithMany(p => p.Aplicacoes)
                                    .HasForeignKey(d => d.ClienteId)
                                    .HasConstraintName("FK__Aplicacao__Clien__267ABA7A");

            });

            OnModelCreatingPartial(modelBuilder);
        }
     
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
