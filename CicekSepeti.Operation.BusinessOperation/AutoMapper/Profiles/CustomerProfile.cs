using AutoMapper;
using CicekSepeti.Data.Model.Infrastructure.Customers.Customer.Entity;
using CicekSepeti.Model.DtoModel.Customers.Customer.Dto;

namespace CicekSepeti.Operation.BusinessOperation.AutoMapper.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerAddDto, CustomerEntity>();
            CreateMap<CustomerUpdateDto, CustomerEntity>();
        }
    }
}
