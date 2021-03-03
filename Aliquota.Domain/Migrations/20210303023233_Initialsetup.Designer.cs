﻿// <auto-generated />
using System;
using Aliquota.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aliquota.Domain.Migrations
{
    [DbContext(typeof(AplicacaoDbContext))]
    [Migration("20210303023233_Initialsetup")]
    partial class Initialsetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aliquota.Domain.Aplicacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataResgate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Juros")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Lucro")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QuantiaFinal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QuantiaInicial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorFinalDeduzidoINSS")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Aplicacao");
                });
#pragma warning restore 612, 618
        }
    }
}
