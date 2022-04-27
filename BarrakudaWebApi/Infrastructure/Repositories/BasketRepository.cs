using Microsoft.AspNetCore.Http;

namespace Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BarrakudaDbContext _dbContext;

        public BasketRepository(BarrakudaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Basket> GetBasket(int? buyerId)
        {
            var basket = await _dbContext.Baskets
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(x => x.BuyerId == buyerId);

            return basket;
        }
        public async Task AddBasket(Basket basket)
            => await _dbContext.Baskets.AddAsync(basket);

        public async Task<int> SaveChangesInBasket()
            => await _dbContext.SaveChangesAsync();

    }
}
