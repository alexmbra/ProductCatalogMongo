using ProductApi.Enetities;

namespace ProductApi.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductAsync(int id);
    Task<IEnumerable<Product>> GetProductByNameAsync(string name);
    Task<IEnumerable<Product>> GetProductByCategoryAsync(string category);
    Task AddProductAsync(Product product);
    Task<bool> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(int id);
}
