using Application.Exceptions;
using Application.Models.Basket;
using Application.Models.Product;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("/api/basket")]
    [ApiController]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IProductRepository _productRepository;

        public BasketController(IBasketRepository basketRepository, IMapper mapper,
            IProductRepository productRepository,
            IUserContextService userContextService)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _productRepository = productRepository;
        }

        [SwaggerOperation(Summary = "Retrieves a basket")]
        [HttpGet(Name = "GetBasket")]
        public async Task<ActionResult> GetBasket()
        {
            var result = await _basketRepository.GetBasket(_userContextService.GetUserId);

            if (result is null)
                throw new NotFoundException("basket not found");

            var basket = BasketMap(result);

            return Ok(basket);
        }

        [SwaggerOperation(Summary = "Adds new items to database")]
        [HttpPost]
        public async Task<ActionResult> AddItemToBasket(int productId, int quantity)
        {
            var basket = await _basketRepository.GetBasket(_userContextService.GetUserId);

            if (basket is null)
                basket = await CreateBasket();

            var product = await _productRepository.GetProductById(productId);

            if (product is null)
                throw new NotFoundException("product not found");

            basket.AddItem(product, quantity);

            var result = await _basketRepository.SaveChangesInBasket() > 0;

            if (!result)
                throw new BadRequestException("Problem saving item to database");

            return CreatedAtRoute("GetBasket", BasketMap(basket));
        }

        [SwaggerOperation(Summary = "Delete items from database")]
        [HttpDelete]
        public async Task<ActionResult> RemoveItemFromBasket(int productId, int quantity)
        {
            var basket = await _basketRepository.GetBasket(_userContextService.GetUserId);

            if (basket is null)
                throw new NotFoundException("Can not delete, basket not found");

            basket.RemoveItem(productId, quantity);

            var result = await _basketRepository.SaveChangesInBasket() > 0;

            if (!result)
                throw new BadRequestException("Problem removing item from database");

            return Ok();
        }

        private async Task<Basket> CreateBasket()
        {
            var cookieOptions = new CookieOptions
            {
                IsEssential = true,
                Expires = DateTime.Now.AddDays(14)
            };

            Response.Cookies.Append("buyerId", _userContextService.GetUserId.ToString(), cookieOptions);

            var basket = new Basket
            {
                BuyerId = _userContextService.GetUserId
            };

            await _basketRepository.AddBasket(basket);

            return basket;
        }

        private BasketDto BasketMap(Basket result)
        {
            return new BasketDto
            {
                Id = result.Id,
                BuyerId = result.BuyerId,
                Items = result.Items.Select(item => new BasketItemDto
                {
                    Id = item.Id,
                    Quantity = item.Quantity,

                    ProductId = item.Product.Id,
                    Name = item.Product.Name,
                    Description = item.Product.Description,
                    Condition = item.Product.Condition,
                    Brand = item.Product.Brand,
                    ProductQuantity = item.Product.Quantity,
                    Category = item.Product.Category.Name

                }).ToList()
            };
        }

    }
}
