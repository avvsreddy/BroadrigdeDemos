using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFDbFirstDemo.Models;

public partial class BrodridgeProductsDb2025Context : DbContext
{
    public BrodridgeProductsDb2025Context()
    {
    }

    public BrodridgeProductsDb2025Context(DbContextOptions<BrodridgeProductsDb2025Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BrodridgeProductsDB2025;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.Property(e => e.PersonId)
                .HasDefaultValueSql("(NEXT VALUE FOR [PersonSequence])")
                .HasColumnName("PersonID");
            entity.Property(e => e.Name).HasDefaultValue("");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryID");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Brand).HasDefaultValue("");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);

            entity.HasMany(d => d.SuppliersPeople).WithMany(p => p.ProductsProducts)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductSupplier",
                    r => r.HasOne<Supplier>().WithMany().HasForeignKey("SuppliersPersonId"),
                    l => l.HasOne<Product>().WithMany().HasForeignKey("ProductsProductId"),
                    j =>
                    {
                        j.HasKey("ProductsProductId", "SuppliersPersonId");
                        j.ToTable("ProductSupplier");
                        j.HasIndex(new[] { "SuppliersPersonId" }, "IX_ProductSupplier_SuppliersPersonID");
                        j.IndexerProperty<int>("ProductsProductId").HasColumnName("ProductsProductID");
                        j.IndexerProperty<int>("SuppliersPersonId").HasColumnName("SuppliersPersonID");
                    });
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.Property(e => e.PersonId)
                .HasDefaultValueSql("(NEXT VALUE FOR [PersonSequence])")
                .HasColumnName("PersonID");
            entity.Property(e => e.Gst).HasColumnName("GST");
            entity.Property(e => e.Name).HasDefaultValue("");
        });
        modelBuilder.HasSequence("PersonSequence");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
