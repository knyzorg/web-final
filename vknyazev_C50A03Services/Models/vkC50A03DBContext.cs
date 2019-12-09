using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using vknyazev_C50A03Services.Models;

namespace vknyazev_C50A03Services.Models
{
    public partial class vkC50A03DBContext : DbContext
    {
        public vkC50A03DBContext()
        {
        }

        public vkC50A03DBContext(DbContextOptions<vkC50A03DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.BuyPrice).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.Description)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.SellPrice).HasColumnType("numeric(8, 2)");

                entity.HasOne(d => d.ProdCat)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProdCatId)
                    .HasConstraintName("FK_Product_ProductCategory");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.ProdCat)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<vknyazev_C50A03Services.Models.Order> Order { get; set; }

        public DbSet<vknyazev_C50A03Services.Models.Cart> Cart { get; set; }
    }
}
