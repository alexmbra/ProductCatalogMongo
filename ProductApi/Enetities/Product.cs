using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductApi.Enetities;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int Id { get; private set; }
    [BsonElement("Name")]
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string Category { get; private set; } = string.Empty;

    public Product(int id, string name, string description, decimal price, string category)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }

    public void Update(string name, string description, decimal price, string category)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }

}
