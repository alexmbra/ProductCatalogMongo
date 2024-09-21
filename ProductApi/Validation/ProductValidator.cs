namespace ProductApi.Validation;

public class ProductValidator
{
    public static void Validate(string name, string description, decimal price, string category)
    {
        // Validate each parameter directly
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(description);
        ArgumentNullException.ThrowIfNull(category);

        if (string.IsNullOrEmpty(name))
            throw new ArgumentException(ErrorMessages.NameMustNotBeEmpty);
        if (string.IsNullOrEmpty(description))
            throw new ArgumentException(ErrorMessages.DescriptionMustNotBeEmpty);
        if (price <= 0)
            throw new ArgumentException(ErrorMessages.PriceMustBeGreaterThanZero);
        if (string.IsNullOrEmpty(category))
            throw new ArgumentException(ErrorMessages.CategoryMustNotBeEmpty);
    }
}

