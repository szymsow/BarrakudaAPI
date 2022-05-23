using Application.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        private readonly IUserContextService _userContextService;
        private readonly IAuthorizationService _authorizationService;

        public ProductService(IProductRepository productRepository,
            IMapper mapper,
            ILogger<ProductService> logger,
            IUserContextService userContextService,
            IAuthorizationService authorizationService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
            _userContextService = userContextService;
            _authorizationService = authorizationService;
        }
        public async Task CreateProduct(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            product.CreatedById = _userContextService.GetUserId;
            await _productRepository.CreateProduct(product);
        }

        public async Task DeleteProduct(int productId)
        {
            var product = await _productRepository.GetProductById(productId);
            if (product is null)
            {
                throw new NotFoundException("product not found");
            }

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, product,
                new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("not authorized");
            }

            _logger.LogInformation($"Comment with id: {productId} DELETE action invoked");
            await _productRepository.DeleteProduct(productId);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts(string query)
        {
            var products = await _productRepository.GetAllProducts(query);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productsDto;
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _productRepository.GetProductById(productId);
            if (product is null)
            {
                throw new NotFoundException("product not found");
            }
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task UpdateProduct(UpdateProductDto updateProductDto, int productId)
        {          
            var product = await _productRepository.GetProductById(productId);
            if (product is null)
            {
                throw new NotFoundException("product not found");
            }

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, product,
                new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("not authorized");
            }

            product.Name = updateProductDto.Name;
            product.Description = updateProductDto.Description;
            product.Price = updateProductDto.Price;
            product.Quantity = updateProductDto.Quantity;

            await _productRepository.UpdateProduct(product, productId);
        }
    }
}
