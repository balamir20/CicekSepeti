using CicekSepeti.Core.Infrastructure.IRepository;
using CicekSepeti.Data.Model.Infrastructure.Products.Product.Entity;

namespace CicekSepeti.Data.Repository.Infrastructure.Products.Product
{
    public interface IProductRepository : IRepository<ProductEntity, int>
    {
    }
}
