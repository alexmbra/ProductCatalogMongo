using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProductApi.Validation;

namespace ProductApi.Enetities;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private set; }
    [BsonElement("Name")]
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string Category { get; private set; } = string.Empty;

    public Product(string name, string description, decimal price, string category)
    {
        Validate(name, description, price, category);

        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }

    public void Update(string name, string description, decimal price, string category)
    {
        Validate(name, description, price, category);

        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }

    private static void Validate(string name, string description, decimal price, string category)
    {
        ProductValidator.Validate(name, description, price, category);
    }
}
