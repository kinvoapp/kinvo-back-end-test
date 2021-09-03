﻿// <auto-generated />
using System;
using Aliquota.Domain.Repository.Implementacao.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aliquota.Domain.Repository.Implementacao.Migrations
{
    [DbContext(typeof(AliquotaDbContext))]
    partial class AliquotaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aliquota.Domain.Entities.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_cliente")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeCliente")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nom_cliente");

                    b.HasKey("Id");

                    b.ToTable("tb_cliente");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_produto")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataInvestimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("din_investimento");

                    b.Property<DateTime?>("DataResgate")
                        .HasColumnType("datetime2")
                        .HasColumnName("din_resgate");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdSituacaoProduto")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoProduto")
                        .HasColumnType("int");

                    b.Property<decimal?>("LucroAcumulado")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("val_lucroacumulado");

                    b.Property<decimal?>("ValorAtual")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("val_atual");

                    b.Property<decimal?>("ValorImposto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("val_imposto");

                    b.Property<decimal?>("ValorInvestido")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("val_investido");

                    b.Property<decimal?>("ValorResgatado")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("val_resgatado");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdSituacaoProduto");

                    b.HasIndex("IdTipoProduto");

                    b.ToTable("tb_produto");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Entidades.SituacaoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_situacaoproduto")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Situacao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nom_situacao");

                    b.HasKey("Id");

                    b.ToTable("tb_situacaoproduto");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Entidades.TipoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_tipoproduto")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeTipoProduto")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nom_tipoproduto");

                    b.Property<decimal>("Rentabilidade")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("val_rentabilidade");

                    b.HasKey("Id");

                    b.ToTable("tb_tipoproduto");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Entidades.Produto", b =>
                {
                    b.HasOne("Aliquota.Domain.Entities.Entidades.Cliente", "Cliente")
                        .WithMany("ProdutoLista")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aliquota.Domain.Entities.Entidades.SituacaoProduto", "SituacaoProduto")
                        .WithMany("ProdutoLista")
                        .HasForeignKey("IdSituacaoProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aliquota.Domain.Entities.Entidades.TipoProduto", "TipoProduto")
                        .WithMany("ProdutoLista")
                        .HasForeignKey("IdTipoProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("SituacaoProduto");

                    b.Navigation("TipoProduto");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Entidades.Cliente", b =>
                {
                    b.Navigation("ProdutoLista");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Entidades.SituacaoProduto", b =>
                {
                    b.Navigation("ProdutoLista");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Entidades.TipoProduto", b =>
                {
                    b.Navigation("ProdutoLista");
                });
#pragma warning restore 612, 618
        }
    }
}
