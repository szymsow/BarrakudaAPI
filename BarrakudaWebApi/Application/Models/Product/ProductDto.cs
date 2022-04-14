namespace Application.Models.Product
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public string Category { get; set; }
    }
}
