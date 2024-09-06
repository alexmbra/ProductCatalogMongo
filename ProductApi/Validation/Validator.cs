namespace ProductApi.Validation;

public class Validator<T>
{
    public static void Validate(T entity, Action<T> validationRules) => validationRules(entity);

    public static void ValidateProperty<TProperty>(TProperty value, bool condtion, string errorMessage) => DomainExceptionValidation.When(condtion, errorMessage);
}
