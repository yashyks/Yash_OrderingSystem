using System;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Models;

namespace OrderingSystem.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderProducts)
                .WithOne(op => op.Order)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderProducts)
                .WithOne(op => op.Product)
                .HasForeignKey(op => op.ProductId);

            // Configure unique composite keys for OrderProduct
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });


            // Seed data for Customers
            modelBuilder.Entity<Customer>().HasData(
                    new Customer { Id = 1, Name = "Yash", Email = "test@yash.com", Age = 19 },
                    new Customer { Id = 2, Name = "Friend", Email = "friend@yash.com" , Age = 21}
                );

                // Seed data for Products
                modelBuilder.Entity<Product>().HasData(
                    new Product { Id = 1, Name = "Laptop", Price = 63000.00m },
                    new Product { Id = 2, Name = "Mobile", Price = 28000.00m },
                    new Product { Id = 3, Name = "IPad", Price = 45000.00m }
                );
            // Seed data for Orders (Associating customers with orders)
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, CustomerId = 1, IsFulfilled = false }, // Order 1 for Customer 1
                new Order { Id = 2, CustomerId = 2, IsFulfilled = true }   // Order 2 for Customer 2
            );

            // Seed data for OrderProducts (Associating products with orders)
            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct { OrderId = 1, ProductId = 1 }, // Order 1 gets Laptop
                new OrderProduct { OrderId = 1, ProductId = 2 }, // Order 1 gets Mobile
                new OrderProduct { OrderId = 2, ProductId = 3 }  // Order 2 gets iPad
            );

        }
    }
}
