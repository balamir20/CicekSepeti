using AutoMapper;
using CicekSepeti.Data.Model.Infrastructure.Baskets.Basket.Entity;
using CicekSepeti.Model.DtoModel.Baskets.Basket.Dto;

namespace CicekSepeti.Operation.BusinessOperation.AutoMapper.Profiles
{
    public class BasketProfile :Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketDto, BasketEntity>();
        }
    }
}
