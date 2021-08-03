﻿// <auto-generated />
using System;
using Aliquota.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Aliquota.Data.Migrations
{
    [DbContext(typeof(AliquotaContext))]
    partial class AliquotaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Aliquota.Domain.Models.ProdutoFinanceiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Aplicacao")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataResgate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Lucro")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("ProdutosFinanceiros");
                });
#pragma warning restore 612, 618
        }
    }
}
