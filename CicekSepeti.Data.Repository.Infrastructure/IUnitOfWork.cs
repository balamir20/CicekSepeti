using CicekSepeti.Data.Repository.Infrastructure.Baskets.Basket;
using CicekSepeti.Data.Repository.Infrastructure.Customers.Customer;
using CicekSepeti.Data.Repository.Infrastructure.Products.Product;
using System;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repository.Infrastructure
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICustomerRepository Customer { get; }
        IProductRepository Product { get; }
        IBasketRepository Basket { get; }
        Task<int> SaveAsync();
        void Commit();
    }
}
