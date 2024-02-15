using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetShopBackend.Models
{
    public partial class petshopContext : DbContext
    {
        public petshopContext()
        {
        }

        public petshopContext(DbContextOptions<petshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=petshop;uid=root;pwd=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerPassword)
                    .HasMaxLength(255)
                    .HasColumnName("customer_password");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.CustomerCustomerId, "customer_customer_id");

                entity.HasIndex(e => e.ProductsProductId, "products_product_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerCustomerId).HasColumnName("customer_customer_id");

                entity.Property(e => e.DispatchDate).HasColumnName("dispatch_date");

                entity.Property(e => e.OrderDate).HasColumnName("order_date");

                entity.Property(e => e.ProductsProductId).HasColumnName("products_product_id");

                entity.Property(e => e.TotalCost).HasColumnName("total_cost");

                entity.HasOne(d => d.CustomerCustomer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerCustomerId)
                    .HasConstraintName("orders_ibfk_1");

                entity.HasOne(d => d.ProductsProduct)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductsProductId)
                    .HasConstraintName("orders_ibfk_2");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Category)
                    .HasMaxLength(255)
                    .HasColumnName("category");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.ProductBreed)
                    .HasMaxLength(255)
                    .HasColumnName("product_breed");

                entity.Property(e => e.ProductCost).HasColumnName("product_cost");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .HasColumnName("product_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.CustomerCustomerId, "customer_customer_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CustomerCustomerId).HasColumnName("customer_customer_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .HasColumnName("user_type");

                entity.HasOne(d => d.CustomerCustomer)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CustomerCustomerId)
                    .HasConstraintName("users_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
