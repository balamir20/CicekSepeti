using CicekSepeti.Core.Infrastructure.IRepository;
using CicekSepeti.Data.Model.Infrastructure.Baskets.Basket.Entity;

namespace CicekSepeti.Data.Repository.Infrastructure.Baskets.Basket
{
    public interface IBasketRepository : IRepository<BasketEntity, int>
    {
    }
}
