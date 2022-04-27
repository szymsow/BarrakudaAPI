namespace Application.Models.Basket
{
    public class BasketDto
    {
        public int Id { get; set; }
        public int? BuyerId { get; set; }

        public ICollection<BasketItemDto> Items { get; set; } 
    }
}
