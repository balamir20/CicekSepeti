namespace CicekSepeti.Model.DtoModel.Customers.Customer.Dto
{
    public class CustomerDto : BaseCSDto, ICSDto
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Email { get; set; }
    }
}
