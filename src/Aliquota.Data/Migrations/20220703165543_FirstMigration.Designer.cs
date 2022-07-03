﻿// <auto-generated />
using System;
using Aliquota.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aliquota.Data.Migrations
{
    [DbContext(typeof(AliquotaDbContext))]
    [Migration("20220703165543_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Aliquota.Domain.Models.Posicao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAporte")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataResgate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorAportado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ValorResgatado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ValorTributado")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Posicoes");
                });

            modelBuilder.Entity("Aliquota.Domain.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Rentabilidade")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("Aliquota.Domain.Models.Posicao", b =>
                {
                    b.HasOne("Aliquota.Domain.Models.Produto", "Produto")
                        .WithMany("Posicoes")
                        .HasForeignKey("ProdutoId")
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Aliquota.Domain.Models.Produto", b =>
                {
                    b.Navigation("Posicoes");
                });
#pragma warning restore 612, 618
        }
    }
}
