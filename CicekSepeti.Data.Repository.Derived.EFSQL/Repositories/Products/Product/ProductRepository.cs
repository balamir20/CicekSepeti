using CicekSepeti.Data.Model.Infrastructure.Products.Product.Entity;
using CicekSepeti.Data.Repository.Infrastructure.Products.Product;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.Data.Repository.Derived.EFSQL.Repositories.Products.Product
{
    public class ProductRepository : BaseRepository<ProductEntity, int>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
