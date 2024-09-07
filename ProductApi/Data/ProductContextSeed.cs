using AutoBogus;
using MongoDB.Driver;
using ProductApi.Enetities;

namespace ProductApi.Data;

internal class ProductContextSeed
{
    internal static void SeedTestData(IMongoCollection<Product> productsCollection)
    {
        bool existProduct = productsCollection.Find(p => true).Any();
        if (!existProduct)
        {
            productsCollection.InsertManyAsync(GetPreconfiguredProducts());
        }
    }

    private static IEnumerable<Product> GetPreconfiguredProducts(string category = "Food")
    {
        var autoFaker = new AutoFaker<Product>()
             .RuleFor(p => p.Id, f => 0) // Skip the Id or set to a default value, if needed
             .RuleFor(p => p.Category, f => category);

        return autoFaker.Generate(10);
    }

}