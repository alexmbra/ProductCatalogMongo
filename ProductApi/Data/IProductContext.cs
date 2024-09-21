using MongoDB.Driver;
using ProductApi.Enetities;

namespace ProductApi.Data;

public interface IProductContext
{
    IMongoCollection<Product> Products { get; }
}
