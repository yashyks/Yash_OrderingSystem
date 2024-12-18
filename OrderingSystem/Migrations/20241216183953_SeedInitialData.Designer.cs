﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderingSystem.DAL;

#nullable disable

namespace OrderingSystem.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241216183953_SeedInitialData")]
    partial class SeedInitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("OrderingSystem.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 19,
                            Email = "test@yash.com",
                            Name = "Yash"
                        },
                        new
                        {
                            Id = 2,
                            Age = 21,
                            Email = "friend@yash.com",
                            Name = "Friend"
                        });
                });

            modelBuilder.Entity("OrderingSystem.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFulfilled")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            IsFulfilled = false
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            IsFulfilled = true
                        });
                });

            modelBuilder.Entity("OrderingSystem.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            OrderId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("OrderingSystem.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Laptop",
                            Price = 63000.00m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mobile",
                            Price = 28000.00m
                        },
                        new
                        {
                            Id = 3,
                            Name = "IPad",
                            Price = 45000.00m
                        });
                });

            modelBuilder.Entity("OrderingSystem.Models.Order", b =>
                {
                    b.HasOne("OrderingSystem.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("OrderingSystem.Models.OrderProduct", b =>
                {
                    b.HasOne("OrderingSystem.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderingSystem.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OrderingSystem.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OrderingSystem.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("OrderingSystem.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
