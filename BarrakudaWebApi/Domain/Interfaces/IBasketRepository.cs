namespace Domain.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasket(int? buyerId);
        Task AddBasket(Basket basket);
        Task<int> SaveChangesInBasket();
    }
}
