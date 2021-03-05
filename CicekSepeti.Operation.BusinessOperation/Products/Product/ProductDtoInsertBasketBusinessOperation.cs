using CicekSepeti.Model.DtoModel.Baskets.Basket.Dto;
using CicekSepeti.Model.DtoModel.Products.Product.Dto;
using System;
using System.Collections.Generic;

namespace CicekSepeti.Operation.BusinessOperation.Products.Product
{
    public class ProductDtoInsertBasketBusinessOperation
    {
        private readonly List<ProductDto> _productDtos;
        public ProductDtoInsertBasketBusinessOperation(List<ProductDto> productDtos)
        {
            _productDtos = productDtos;
        }
        public BasketDto Create()
        {
            try
            {
                BasketDto basketDto = new BasketDto
                {
                    Products = _productDtos
                };
                return basketDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
