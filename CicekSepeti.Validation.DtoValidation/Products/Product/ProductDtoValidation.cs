using CicekSepeti.Model.DtoModel.Products.Product.Dto;
using FluentValidation;

namespace CicekSepeti.Validation.DtoValidation.Products.Product
{
    public class ProductDtoValidation : ValidationBase<ProductDto>
    {
        public ProductDtoValidation()
        {
            RuleFor(product => product.ProductName).NotEmpty();
            RuleFor(product => product.ProductName).MaximumLength(128);
            RuleFor(product => product.ProductDescription).NotEmpty();
            RuleFor(product => product.ProductDescription).MaximumLength(128);
            RuleFor(product => product.Stock).NotEmpty();
            RuleFor(product => product.Price).NotEmpty();
        }
    }
}
