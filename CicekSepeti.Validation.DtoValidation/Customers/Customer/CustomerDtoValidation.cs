using CicekSepeti.Model.DtoModel.Customers.Customer.Dto;
using FluentValidation;

namespace CicekSepeti.Validation.DtoValidation.Customers.Customer
{
    public class CustomerDtoValidation : ValidationBase<CustomerDto>
    {
        public CustomerDtoValidation()
        {
            RuleFor(customer => customer.CustomerName).NotEmpty();
            RuleFor(customer => customer.CustomerName).MaximumLength(64);
            RuleFor(customer => customer.CustomerSurname).NotEmpty();
            RuleFor(customer => customer.CustomerSurname).MaximumLength(64);
            RuleFor(customer => customer.Email).NotEmpty();
        }
    }
}
