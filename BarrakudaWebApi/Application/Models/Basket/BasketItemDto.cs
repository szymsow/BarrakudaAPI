namespace Application.Models.Basket
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string Brand { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Price { get; set; }

        public string Category { get; set; }

    }
}