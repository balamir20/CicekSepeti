using CicekSepeti.Data.Repository.Derived.EFSQL.Repositories.Baskets.Basket;
using CicekSepeti.Data.Repository.Derived.EFSQL.Repositories.Customers.Customer;
using CicekSepeti.Data.Repository.Derived.EFSQL.Repositories.Products.Product;
using CicekSepeti.Data.Repository.Infrastructure;
using CicekSepeti.Data.Repository.Infrastructure.Baskets.Basket;
using CicekSepeti.Data.Repository.Infrastructure.Customers.Customer;
using CicekSepeti.Data.Repository.Infrastructure.Products.Product;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repository.Derived.EFSQL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private CustomerRepository _customerRepository;
        private BasketRepository _basketRepository;
        private ProductRepository _productRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public ICustomerRepository Customer => _customerRepository ?? new CustomerRepository(_context);
        public IBasketRepository Basket => _basketRepository ?? new BasketRepository(_context);
        public IProductRepository Product => _productRepository ?? new ProductRepository(_context);
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
