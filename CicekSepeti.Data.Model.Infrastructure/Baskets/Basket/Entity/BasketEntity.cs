using CicekSepeti.Data.Model.Infrastructure.Customers.Customer.Entity;
using CicekSepeti.Data.Model.Infrastructure.Products.Product.Entity;
using System;
using System.Collections.Generic;

namespace CicekSepeti.Data.Model.Infrastructure.Baskets.Basket.Entity
{
    public class BasketEntity : BaseCSEntity, ICSEntity
    {
        public BasketEntity()
        {
            Products = new List<ProductEntity>();
        }
        public List<ProductEntity> Products { get; set; }
        public CustomerEntity Customer { get; set; }
        public int CustomerId { get; set; }

        private Guid _basketId = Guid.NewGuid();
        public Guid BasketId
        {
            get { return _basketId; }
            set { _basketId = value; }
        }
    }
}
