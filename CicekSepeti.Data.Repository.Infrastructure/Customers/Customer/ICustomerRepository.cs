using CicekSepeti.Core.Infrastructure.IRepository;
using CicekSepeti.Data.Model.Infrastructure.Customers.Customer.Entity;

namespace CicekSepeti.Data.Repository.Infrastructure.Customers.Customer
{
    public interface ICustomerRepository : IRepository<CustomerEntity, int>
    {
    }
}
