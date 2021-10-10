﻿// <auto-generated />
using System;
using FrameworksAndDrivers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FrameworksAndDrivers.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20211010203922_thirdMigration")]
    partial class thirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aliquota.BusinessLogic.Models.FinanceProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("FinanceProducts");
                });

            modelBuilder.Entity("Aliquota.BusinessLogic.Models.FinanceProductMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CurrentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("FinanceProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FinanceProductId");

                    b.HasIndex("UserId");

                    b.ToTable("FinanceProductMoves");
                });

            modelBuilder.Entity("Aliquota.BusinessLogic.Models.FinanceProductWallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FinanceProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FinanceProductId");

                    b.HasIndex("UserId");

                    b.ToTable("FinanceProductWallets");
                });

            modelBuilder.Entity("Aliquota.BusinessLogic.Models.ProductTradeMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FinanceProductWalletId")
                        .HasColumnType("int");

                    b.Property<int?>("FistFinanceProductMoveId")
                        .HasColumnType("int");

                    b.Property<int?>("SecondFinanceProductMoveId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FinanceProductWalletId");

                    b.HasIndex("FistFinanceProductMoveId");

                    b.HasIndex("SecondFinanceProductMoveId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductTradeMoves");
                });

            modelBuilder.Entity("Aliquota.BusinessLogic.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Aliquota.BusinessLogic.Models.FinanceProductMove", b =>
                {
                    b.HasOne("Aliquota.BusinessLogic.Models.FinanceProduct", "FinanceProduct")
                        .WithMany("FinanceProductMoves")
                        .HasForeignKey("FinanceProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aliquota.BusinessLogic.Models.User", "User")
                        .WithMany("FinanceProductMoves")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinanceProduct");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Aliquota.BusinessLogic.Models.FinanceProductWallet", b =>
                {
                    b.HasOne("Aliquota.BusinessLogic.Models.FinanceProduct", "FinanceProduct")
                        .WithMany("FinanceProductWallets")
                        .HasForeignKey("FinanceProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aliquota.BusinessLogic.Models.User", "User")
                        .WithMany("FinanceProductWallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinanceProduct");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Aliquota.BusinessLogic.Models.ProductTradeMove", b =>
                {
                    b.HasOne("Aliquota.BusinessLogic.Models.FinanceProductWallet", null)
                        .WithMany("ProductTradeMoves")
                        .HasForeignKey("FinanceProductWalletId");

                    b.HasOne("Aliquota.BusinessLogic.Models.FinanceProductMove", "FistFinanceProductMove")
                        .WithMany()
                        .HasForeignKey("FistFinanceProductMoveId");

                    b.HasOne("Aliquota.BusinessLogic.Models.FinanceProductMove", "SecondFinanceProductMove")
                        .WithMany()
                        .HasForeignKey("SecondFinanceProductMoveId");

                    b.HasOne("Aliquota.BusinessLogic.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("FistFinanceProductMove");

                    b.Navigation("SecondFinanceProductMove");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Aliquota.BusinessLogic.Models.FinanceProduct", b =>
                {
                    b.Navigation("FinanceProductMoves");

                    b.Navigation("FinanceProductWallets");
                });

            modelBuilder.Entity("Aliquota.BusinessLogic.Models.FinanceProductWallet", b =>
                {
                    b.Navigation("ProductTradeMoves");
                });

            modelBuilder.Entity("Aliquota.BusinessLogic.Models.User", b =>
                {
                    b.Navigation("FinanceProductMoves");

                    b.Navigation("FinanceProductWallets");
                });
#pragma warning restore 612, 618
        }
    }
}
