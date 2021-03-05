using CicekSepeti.Data.Model.Infrastructure.Customers.Customer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CicekSepeti.Data.Repository.Derived.EFSQL.Configurations.Customers.Customer
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.CustomerName).IsRequired();
            builder.Property(m => m.CustomerName).HasMaxLength(64);
            builder.Property(m => m.CustomerSurname).IsRequired();
            builder.Property(m => m.CustomerSurname).HasMaxLength(64);
            builder.Property(m => m.Email).IsRequired();
            builder.ToTable("Customer", "Customer");
        }
    }
}
