namespace CicekSepeti.Model.DtoModel.Products.Product.Dto
{
    public class ProductDto : BaseCSDto, ICSDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
