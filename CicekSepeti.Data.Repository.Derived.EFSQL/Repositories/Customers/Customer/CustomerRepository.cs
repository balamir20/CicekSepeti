using CicekSepeti.Data.Model.Infrastructure.Customers.Customer.Entity;
using CicekSepeti.Data.Repository.Infrastructure.Customers.Customer;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.Data.Repository.Derived.EFSQL.Repositories.Customers.Customer
{
    public class CustomerRepository : BaseRepository<CustomerEntity, int>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }
    }
}
