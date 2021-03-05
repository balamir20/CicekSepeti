using CicekSepeti.Model.DtoModel.Baskets.Basket.Dto;
using CicekSepeti.Validation.DtoValidation.Customers.Customer;

namespace CicekSepeti.Validation.DtoValidation.Baskets.Basket
{
    public class BasketDtoValidation : ValidationBase<BasketDto>
    {
        public BasketDtoValidation()
        {
            RuleFor(basket => basket.Customer).SetValidator(new CustomerDtoValidation());
        }
    }
}
