﻿// <auto-generated />
using System;
using Aliquota.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aliquota.Domain.Migrations
{
    [DbContext(typeof(AliquotaDomainContext))]
    [Migration("20211012143211_OtherEntities")]
    partial class OtherEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Aliquota.Domain.Models.Client", b =>
                {
                    b.Property<int>("clientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("clientName");

                    b.HasKey("clientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Aliquota.Domain.Models.IR_Record", b =>
                {
                    b.Property<int>("recordId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("clientId");

                    b.Property<int?>("productId");

                    b.Property<double>("recordAmount");

                    b.Property<DateTime>("recordDate");

                    b.Property<int>("recordStatus");

                    b.HasKey("recordId");

                    b.HasIndex("clientId");

                    b.HasIndex("productId");

                    b.ToTable("IR_Record");
                });

            modelBuilder.Entity("Aliquota.Domain.Models.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("clientId");

                    b.Property<DateTime>("dateApplication");

                    b.Property<DateTime>("dateRescue");

                    b.Property<double>("productGain");

                    b.Property<double>("productInvestment");

                    b.Property<double>("productTax");

                    b.HasKey("productId");

                    b.HasIndex("clientId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Aliquota.Domain.Models.IR_Record", b =>
                {
                    b.HasOne("Aliquota.Domain.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("clientId");

                    b.HasOne("Aliquota.Domain.Models.Product")
                        .WithMany("Records")
                        .HasForeignKey("productId");
                });

            modelBuilder.Entity("Aliquota.Domain.Models.Product", b =>
                {
                    b.HasOne("Aliquota.Domain.Models.Client", "Client")
                        .WithMany("Products")
                        .HasForeignKey("clientId");
                });
#pragma warning restore 612, 618
        }
    }
}
