﻿// <auto-generated />
using System;
using Aliquota.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aliquota.Domain.Migrations
{
    [DbContext(typeof(AliquotaDBContext))]
    partial class AliquotaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aliquota.Domain.Entities.Aplicacao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cliente_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataRetirada")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InvestidorID")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoFinanceiro_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("InvestidorID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("Aplicacao");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.ProdutoFinanceiro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Custo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rendimento")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("ProdutoFinanceiro");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Aplicacao", b =>
                {
                    b.HasOne("Aliquota.Domain.Entities.Cliente", "Investidor")
                        .WithMany()
                        .HasForeignKey("InvestidorID");

                    b.HasOne("Aliquota.Domain.Entities.ProdutoFinanceiro", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID");
                });
#pragma warning restore 612, 618
        }
    }
}
