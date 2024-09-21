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
        var products = new List<Product>();

        try
        {
            var autoFaker = new AutoFaker<Product>()
                .RuleFor(p => p.Id, f => Guid.NewGuid().ToString("N").Substring(0, 24)) // Skip the Id or set to a default value, if needed
                .RuleFor(p => p.Category, f => category);

            products = autoFaker.Generate(10);

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return products;
    }

}