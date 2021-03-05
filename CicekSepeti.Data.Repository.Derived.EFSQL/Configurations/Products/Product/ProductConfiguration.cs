using CicekSepeti.Data.Model.Infrastructure.Products.Product.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CicekSepeti.Data.Repository.Derived.EFSQL.Configurations.Products.Product
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.ProductName).IsRequired();
            builder.Property(m => m.ProductName).HasMaxLength(128);
            builder.Property(m => m.ProductDescription).IsRequired();
            builder.Property(m => m.ProductDescription).HasMaxLength(256);
            builder.Property(m => m.Stock).IsRequired();
            builder.Property(m => m.Price).IsRequired();
            builder.Property(m => m.Price).HasColumnType("decimal(10,5)");
            builder.ToTable("Product", "Product");
        }
    }
}
