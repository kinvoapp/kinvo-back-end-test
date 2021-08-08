﻿// <auto-generated />
using System;
using Aliquota.Domain.Infraestrutura.DBConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aliquota.Domain.Migrations
{
    [DbContext(typeof(AliquotaContexto))]
    [Migration("20210806054303_Infraestrutura")]
    partial class Infraestrutura
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aliquota.Domain.Models.ProdutoFinanceiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("DataAplicacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DataResgate")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<Guid>("TipoProdutoFinanceiroFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("ValorAplicado")
                        .HasColumnType("float");

                    b.Property<double>("ValorIR")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.HasKey("Id");

                    b.HasIndex("TipoProdutoFinanceiroFK");

                    b.ToTable("ProdutosFinanceiros");
                });

            modelBuilder.Entity("Aliquota.Domain.Models.TipoProdutoFinanceiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<double>("PorcentagemLucro")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("TiposProdutosFinanceiros");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae6bb3f8-29c2-4482-82ac-228c3a7f4c13"),
                            Nome = "CDB",
                            PorcentagemLucro = 7.0
                        },
                        new
                        {
                            Id = new Guid("c3802878-f908-4bdb-bfa6-5bb784cd8f57"),
                            Nome = "Poupança",
                            PorcentagemLucro = 3.0
                        });
                });

            modelBuilder.Entity("Aliquota.Domain.Models.ProdutoFinanceiro", b =>
                {
                    b.HasOne("Aliquota.Domain.Models.TipoProdutoFinanceiro", "TipoProdutoFinanceiro")
                        .WithMany()
                        .HasForeignKey("TipoProdutoFinanceiroFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoProdutoFinanceiro");
                });
#pragma warning restore 612, 618
        }
    }
}
