using CicekSepeti.Data.Model.Infrastructure.Baskets.Basket.Entity;
using CicekSepeti.Data.Repository.Infrastructure.Baskets.Basket;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.Data.Repository.Derived.EFSQL.Repositories.Baskets.Basket
{
    public class BasketRepository : BaseRepository<BasketEntity, int>, IBasketRepository
    {
        public BasketRepository(DbContext context) : base(context)
        {
        }
    }
}
