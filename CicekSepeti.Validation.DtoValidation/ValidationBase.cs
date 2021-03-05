using FluentValidation;

namespace CicekSepeti.Validation.DtoValidation
{
    public abstract class ValidationBase<T> : AbstractValidator<T> where T : class
    {
    }
}
