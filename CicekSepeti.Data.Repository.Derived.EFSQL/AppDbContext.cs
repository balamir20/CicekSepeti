using CicekSepeti.Data.Model.Infrastructure.Baskets.Basket.Entity;
using CicekSepeti.Data.Model.Infrastructure.Customers.Customer.Entity;
using CicekSepeti.Data.Model.Infrastructure.Logs.Log.Entity;
using CicekSepeti.Data.Model.Infrastructure.Products.Product.Entity;
using CicekSepeti.Data.Repository.Derived.EFSQL.Configurations.Baskets.Basket;
using CicekSepeti.Data.Repository.Derived.EFSQL.Configurations.Customers.Customer;
using CicekSepeti.Data.Repository.Derived.EFSQL.Configurations.Logs.Log;
using CicekSepeti.Data.Repository.Derived.EFSQL.Configurations.Products.Product;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.Data.Repository.Derived.EFSQL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<BasketEntity> Baskets { get; set; }
        public DbSet<LogEntity> Logs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new BasketConfiguration());
            modelBuilder.ApplyConfiguration(new LogConfiguration());
        }
    }
}
