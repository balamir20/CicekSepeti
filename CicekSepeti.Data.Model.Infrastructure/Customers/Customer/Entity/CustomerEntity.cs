namespace CicekSepeti.Data.Model.Infrastructure.Customers.Customer.Entity
{
    public class CustomerEntity : BaseCSEntity, ICSEntity
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Email { get; set; }
    }
}
