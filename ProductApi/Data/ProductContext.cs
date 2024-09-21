using MongoDB.Driver;
using ProductApi.Enetities;

namespace ProductApi.Data;

public class ProductContext : IProductContext
{
    public ProductContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("MongoDBSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("MongoDBSettings:DatabaseName"));
        Products = database.GetCollection<Product>(configuration.GetValue<string>("MongoDBSettings:CollectionName"));

        ProductContextSeed.SeedTestData(Products);

    }

    public IMongoCollection<Product> Products { get; }
}
