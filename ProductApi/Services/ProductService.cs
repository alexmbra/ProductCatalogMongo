using MongoDB.Driver;
using ProductApi.Data;
using ProductApi.Enetities;

namespace ProductApi.Services;

public class ProductService : IProductService
{
    private readonly ProductContext _dbContext;

    public ProductService(ProductContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task AddProductAsync(Product product)
    {
        await _dbContext.Products.InsertOneAsync(product);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter
            .Eq(p => p.Id, id);

        var result = await _dbContext
             .Products
             .DeleteOneAsync(filter);

        return result.IsAcknowledged
            && result.DeletedCount > 0;
    }

    public Task<Product> GetProductAsync(int id)
    {
        return _dbContext.Products.Find(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByCategoryAsync(string category)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter
            .Eq(p => p.Category, category);

        return await _dbContext.Products
            .Find(filter)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter
            .Eq(p => p.Name, name);

        return await _dbContext.Products
            .Find(filter)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _dbContext.Products.Find(p => true)
            .ToListAsync();
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var updateResult = await _dbContext
            .Products
            .ReplaceOneAsync(g => g.Id == product.Id, product);

        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;

    }
}
