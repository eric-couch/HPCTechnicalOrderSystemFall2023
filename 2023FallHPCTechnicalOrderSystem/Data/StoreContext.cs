using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2023FallHPCTechnicalOrderSystem.Models;

namespace _2023FallHPCTechnicalOrderSystem.Data;

public class StoreContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=2023FallHPCTechnicalOrderSystem;Trusted_Connection=True;MultipleActiveResultSets=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new Customer()
        {
            Id = 1,
            FirstName = "Eric",
            LastName = "Couch",
            Address = "123 Main St",
            Phone = "555-555-5555"
        });
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            Id = 1,
            Name = "Meat Lover's Pizza",
            Price = 9.99m
        });
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            Id = 2,
            Name = "Veggie Lover's Pizza",
            Price = 9.99m
        });
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            Id = 3,
            Name = "Cheese Pizza",
            Price = 7.99m
        });
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            Id = 4,
            Name = "Pepperoni Pizza",
            Price = 8.99m
        });
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            Id = 5,
            Name = "Deluxe Pizza",
            Price = 12.99m
        });
        modelBuilder.Entity<Order>().HasData(new Order()
        {
            Id = 1,
            CustomerId = 1,
            OrderPlaced = new DateTime(2023, 9, 28, 11, 30, 00),
            OrderFulfilled = new DateTime(2023, 9, 28, 12, 00, 00)
        });
        modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail()
        {
            Id = 1,
            OrderId = 1,
            ProductId = 1,
            Quantity = 1
        });
        modelBuilder.Entity<Order>().HasData(new Order()
        {
            Id = 2,
            CustomerId = 1,
            OrderPlaced = new DateTime(2023, 9, 28, 20, 00, 00),
            OrderFulfilled = new DateTime(2023, 9, 28, 20, 20, 00)
        });
        modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail()
        {
            Id = 2,
            OrderId = 2,
            ProductId = 4,
            Quantity = 2
        });
    }
}
