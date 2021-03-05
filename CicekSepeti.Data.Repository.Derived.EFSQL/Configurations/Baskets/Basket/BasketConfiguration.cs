using CicekSepeti.Data.Model.Infrastructure.Baskets.Basket.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CicekSepeti.Data.Repository.Derived.EFSQL.Configurations.Baskets.Basket
{
    public class BasketConfiguration : IEntityTypeConfiguration<BasketEntity>
    {
        public void Configure(EntityTypeBuilder<BasketEntity> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.HasOne(m => m.Customer).WithMany().HasForeignKey(m => m.CustomerId);
            builder.ToTable("Basket", "Basket");
        }
    }
}
