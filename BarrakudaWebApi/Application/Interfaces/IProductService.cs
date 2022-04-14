namespace Application.Interfaces
{
    public interface IProductService
    {
        Task CreateProduct(CreateProductDto productDto);
        Task UpdateProduct(UpdateProductDto updateProductDto, int productId);
        Task DeleteProduct(int productId);
        Task<ProductDto> GetProductById(int productId);
        Task<IEnumerable<ProductDto>> GetAllProducts();
    }
}
