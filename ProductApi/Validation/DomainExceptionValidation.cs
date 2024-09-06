namespace ProductApi.Validation;

internal class DomainExceptionValidation : Exception
{
    public DomainExceptionValidation(string error) : base(error)
    {
    }

    public static void When(bool hasError, string errorMessage)
    {
        if (hasError)
        {
            throw new DomainExceptionValidation(errorMessage);
        }
    }
}