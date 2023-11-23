﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using R54_M9_Evidence_08_Mid.Models;

#nullable disable

namespace R54_M9_Evidence_08_Mid.Migrations
{
    [DbContext(typeof(DressDbContext))]
    [Migration("20231006122328_Initial Create")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("R54_M9_Evidence_08_Mid.Models.Dress", b =>
                {
                    b.Property<int>("DressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DressId"));

                    b.Property<string>("DressName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("OnSale")
                        .HasColumnType("bit");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("DressId");

                    b.ToTable("Dresses");

                    b.HasData(
                        new
                        {
                            DressId = 1,
                            DressName = "Dress 1",
                            OnSale = true,
                            Picture = "1.jpg",
                            Price = 1569.00m,
                            Size = 1
                        },
                        new
                        {
                            DressId = 2,
                            DressName = "Dress 2",
                            OnSale = true,
                            Picture = "2.jpg",
                            Price = 1674.00m,
                            Size = 3
                        },
                        new
                        {
                            DressId = 3,
                            DressName = "Dress 3",
                            OnSale = true,
                            Picture = "3.jpg",
                            Price = 1792.00m,
                            Size = 4
                        },
                        new
                        {
                            DressId = 4,
                            DressName = "Dress 4",
                            OnSale = true,
                            Picture = "4.jpg",
                            Price = 1166.00m,
                            Size = 1
                        },
                        new
                        {
                            DressId = 5,
                            DressName = "Dress 5",
                            OnSale = true,
                            Picture = "5.jpg",
                            Price = 1755.00m,
                            Size = 2
                        });
                });

            modelBuilder.Entity("R54_M9_Evidence_08_Mid.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<int>("DressId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("SaleId");

                    b.HasIndex("DressId");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            SaleId = 1,
                            Date = new DateTime(2023, 2, 28, 18, 23, 27, 996, DateTimeKind.Local).AddTicks(5328),
                            DressId = 1,
                            Quantity = 260
                        },
                        new
                        {
                            SaleId = 2,
                            Date = new DateTime(2023, 3, 16, 18, 23, 27, 996, DateTimeKind.Local).AddTicks(5371),
                            DressId = 2,
                            Quantity = 127
                        },
                        new
                        {
                            SaleId = 3,
                            Date = new DateTime(2022, 7, 1, 18, 23, 27, 996, DateTimeKind.Local).AddTicks(5387),
                            DressId = 3,
                            Quantity = 237
                        },
                        new
                        {
                            SaleId = 4,
                            Date = new DateTime(2022, 7, 29, 18, 23, 27, 996, DateTimeKind.Local).AddTicks(5401),
                            DressId = 4,
                            Quantity = 153
                        },
                        new
                        {
                            SaleId = 5,
                            Date = new DateTime(2022, 7, 12, 18, 23, 27, 996, DateTimeKind.Local).AddTicks(5415),
                            DressId = 5,
                            Quantity = 256
                        },
                        new
                        {
                            SaleId = 6,
                            Date = new DateTime(2022, 7, 4, 18, 23, 27, 996, DateTimeKind.Local).AddTicks(5432),
                            DressId = 1,
                            Quantity = 123
                        },
                        new
                        {
                            SaleId = 7,
                            Date = new DateTime(2022, 9, 25, 18, 23, 27, 996, DateTimeKind.Local).AddTicks(5446),
                            DressId = 2,
                            Quantity = 152
                        },
                        new
                        {
                            SaleId = 8,
                            Date = new DateTime(2023, 2, 22, 18, 23, 27, 996, DateTimeKind.Local).AddTicks(5461),
                            DressId = 3,
                            Quantity = 134
                        });
                });

            modelBuilder.Entity("R54_M9_Evidence_08_Mid.Models.Sale", b =>
                {
                    b.HasOne("R54_M9_Evidence_08_Mid.Models.Dress", "Dress")
                        .WithMany("Sales")
                        .HasForeignKey("DressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dress");
                });

            modelBuilder.Entity("R54_M9_Evidence_08_Mid.Models.Dress", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
