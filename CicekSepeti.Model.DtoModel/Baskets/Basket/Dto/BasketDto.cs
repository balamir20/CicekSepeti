using CicekSepeti.Model.DtoModel.Customers.Customer.Dto;
using CicekSepeti.Model.DtoModel.Products.Product.Dto;
using System;
using System.Collections.Generic;

namespace CicekSepeti.Model.DtoModel.Baskets.Basket.Dto
{
    public class BasketDto : BaseCSDto, ICSDto
    {
        public BasketDto()
        {
            Products = new List<ProductDto>();
        }
        public List<ProductDto> Products { get; set; }
        public CustomerDto Customer { get; set; }
        public int CustomerId { get; set; }

        private Guid _basketId = Guid.NewGuid();
        public Guid BasketId
        {
            get { return _basketId; }
            set { _basketId = value; }
        }
    }
}
