namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product, int productId);
        Task DeleteProduct(int productId);
        Task<Product> GetProductById(int productId);
        Task<IEnumerable<Product>> GetProductsByCategory(string category);
        Task<IEnumerable<Product>> GetAllProducts(string query);
    }
}
