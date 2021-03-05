using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CicekSepeti.Model.DtoModel.Customers.Customer.Dto
{
    public class CustomerUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Müşteri Adı")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        [MaxLength(64, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        public string CustomerName { get; set; }

        [DisplayName("Müşteri Soyadı")]
        [MaxLength(64, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        public string CustomerSurname { get; set; }
    }
}
