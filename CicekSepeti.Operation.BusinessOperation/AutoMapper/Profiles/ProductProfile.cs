using AutoMapper;
using CicekSepeti.Data.Model.Infrastructure.Products.Product.Entity;
using CicekSepeti.Model.DtoModel.Products.Product.Dto;

namespace CicekSepeti.Operation.BusinessOperation.AutoMapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, ProductEntity>();
        }
    }
}
