using CodeFirstEF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstEF.Context
{
    public class CustomerContext:DbContext
    {
        public CustomerContext() : base("CustomerContext")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orders_Items> OrdersItems { get; set; }
        public DbSet<Product> Products { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Customer>().Property(c => c.Firstname).HasMaxLength(64);
            modelBuilder.Entity<Customer>().Property(c => c.Middlename).HasMaxLength(64);
            modelBuilder.Entity<Customer>().Property(c => c.Lastname).HasMaxLength(64);
            modelBuilder.Entity<Customer>().Property(c => c.Gender).HasMaxLength(64);


            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>().HasKey(c => c.Id).HasMany(c => c.Items);
            modelBuilder.Entity<Order>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Order>().Property(c => c.No).HasMaxLength(10);
            modelBuilder.Entity<Order>().Property(c => c.OrderName).HasMaxLength(64);
            modelBuilder.Entity<Order>().Property(c => c.Amount).HasPrecision(18, 2);
            modelBuilder.Entity<Order>()
                .HasRequired(c => c.Customer).WithMany().HasForeignKey(d => d.CustomerId);

            modelBuilder.Entity<Orders_Items>().ToTable("Orders_Item");
            modelBuilder.Entity<Orders_Items>().HasKey(c => c.Id);
            modelBuilder.Entity<Orders_Items>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Orders_Items>().Property(c => c.ProductCode).HasMaxLength(10);
            modelBuilder.Entity<Orders_Items>().Property(c => c.ProductName).HasMaxLength(100);
            modelBuilder.Entity<Orders_Items>().Property(c => c.Quality).HasPrecision(18, 2);
            modelBuilder.Entity<Orders_Items>().Property(c => c.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Orders_Items>().Property(c => c.Amount).HasPrecision(18, 2);
            modelBuilder.Entity<Orders_Items>()
                .HasRequired(c => c.Order)
                .WithMany(x => x.Items)
                .HasForeignKey(d => d.OrderId);
            modelBuilder.Entity<Orders_Items>()
                .HasRequired(c => c.Product)
                .WithMany()
                .HasForeignKey(d => d.ProductId);


            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(c => c.Id);
            modelBuilder.Entity<Product>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Product>().Property(c => c.Code).HasMaxLength(10);
            modelBuilder.Entity<Product>().Property(c => c.Name).HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(c => c.StockOnHand).HasPrecision(18, 2);
            modelBuilder.Entity<Product>().Property(c => c.Price).HasPrecision(18, 2);


        }

        
    }
}       