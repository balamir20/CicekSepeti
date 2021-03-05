namespace CicekSepeti.Data.Model.Infrastructure.Products.Product.Entity
{
    public class ProductEntity : BaseCSEntity, ICSEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
