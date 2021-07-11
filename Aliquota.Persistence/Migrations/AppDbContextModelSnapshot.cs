﻿// <auto-generated />
using System;
using Aliquota.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aliquota.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Aliquota.Domain.Entities.FinancialProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("EvaluatorsJson")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FinancialProduct");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Investment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("ApplicationDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FinancialProductId")
                        .HasColumnType("TEXT");

                    b.Property<double>("InitialValue")
                        .HasColumnType("REAL");

                    b.Property<Guid>("PortfolioId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("RedemptionDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FinancialProductId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Investment");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Investment", b =>
                {
                    b.HasOne("Aliquota.Domain.Entities.FinancialProduct", "FinancialProduct")
                        .WithMany()
                        .HasForeignKey("FinancialProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aliquota.Domain.Entities.Portfolio", "Portfolio")
                        .WithMany("Investments")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinancialProduct");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Portfolio", b =>
                {
                    b.HasOne("Aliquota.Domain.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Aliquota.Domain.Entities.Portfolio", b =>
                {
                    b.Navigation("Investments");
                });
#pragma warning restore 612, 618
        }
    }
}
