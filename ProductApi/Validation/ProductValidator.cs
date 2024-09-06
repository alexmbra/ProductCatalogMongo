using ProductApi.Enetities;

namespace ProductApi.Validation;

public class ProductValidator
{
    public static void Validate(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        Validator<Product>.Validate(product, product =>
        {
            Validator<Product>.ValidateProperty(product.Id, product.Id > 0, ErrorMessages.IdMustBeGreaterThanZero);
            Validator<Product>.ValidateProperty(product.Name, string.IsNullOrEmpty(product.Name), ErrorMessages.NameMustNotBeEmpty);
            Validator<Product>.ValidateProperty(product.Description, string.IsNullOrEmpty(product.Description), ErrorMessages.DescriptionMustNotBeEmpty);
            Validator<Product>.ValidateProperty(product.Price, product.Price > 0, ErrorMessages.PriceMustBeGreaterThanZero);
            Validator<Product>.ValidateProperty(product.Category, !string.IsNullOrEmpty(product.Category), ErrorMessages.CategoryMustNotBeEmpty);
        });
    }
}
