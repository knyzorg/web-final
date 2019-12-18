using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId=1, Email="amcdonald@gmail.com", FirstName="Allan", LastName="McDonald" },
                new Customer { CustomerId=2, Email="sandra@gmail.com", FirstName="Sandra", LastName="Stark" },
                new Customer { CustomerId=3, Email="ron@gmail.com", FirstName="Ron", LastName="Patterson" }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId=1, OrderCustId=1, DateCreated = DateTime.Now, Taxes=10, Total=2000, DateFulfilled=DateTime.Now }
            );

            
            
        }
    }
}
