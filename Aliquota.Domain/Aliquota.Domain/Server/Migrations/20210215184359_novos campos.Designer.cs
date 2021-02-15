﻿// <auto-generated />
using System;
using Aliquota.Domain.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aliquota.Domain.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210215184359_novos campos")]
    partial class novoscampos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aliquota.Domain.Shared.Models.Aplicacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRetirada")
                        .HasColumnType("datetime2");

                    b.Property<double>("Juros")
                        .HasColumnType("float");

                    b.Property<int>("PeriodoPrevistoAplicadoEmMeses")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorInvestido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorSacado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Aplicacaos");
                });
#pragma warning restore 612, 618
        }
    }
}
