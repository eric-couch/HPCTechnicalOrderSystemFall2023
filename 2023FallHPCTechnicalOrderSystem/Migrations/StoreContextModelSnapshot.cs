﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2023FallHPCTechnicalOrderSystem.Data;

#nullable disable

namespace _2023FallHPCTechnicalOrderSystem.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_2023FallHPCTechnicalOrderSystem.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            Admin = false,
                            FirstName = "Eric",
                            LastName = "Couch",
                            Phone = "555-555-5555"
                        });
                });

            modelBuilder.Entity("_2023FallHPCTechnicalOrderSystem.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OrderFulfilled")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            OrderFulfilled = new DateTime(2023, 9, 28, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPlaced = new DateTime(2023, 9, 28, 11, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 1,
                            OrderFulfilled = new DateTime(2023, 9, 28, 20, 20, 0, 0, DateTimeKind.Unspecified),
                            OrderPlaced = new DateTime(2023, 9, 28, 20, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("_2023FallHPCTechnicalOrderSystem.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 2,
                            ProductId = 4,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("_2023FallHPCTechnicalOrderSystem.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Meat Lover's Pizza",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Veggie Lover's Pizza",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cheese Pizza",
                            Price = 7.99m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Pepperoni Pizza",
                            Price = 8.99m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Deluxe Pizza",
                            Price = 12.99m
                        });
                });

            modelBuilder.Entity("_2023FallHPCTechnicalOrderSystem.Models.Order", b =>
                {
                    b.HasOne("_2023FallHPCTechnicalOrderSystem.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("_2023FallHPCTechnicalOrderSystem.Models.OrderDetail", b =>
                {
                    b.HasOne("_2023FallHPCTechnicalOrderSystem.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_2023FallHPCTechnicalOrderSystem.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("_2023FallHPCTechnicalOrderSystem.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("_2023FallHPCTechnicalOrderSystem.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
