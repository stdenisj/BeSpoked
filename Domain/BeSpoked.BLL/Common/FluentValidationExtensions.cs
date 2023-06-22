using FluentValidation;

namespace BeSpoked.Common;

public static class FluentValidationExtensions
{
    public static List<ModelValidationError> GetModelValidationErrors<T>(this AbstractValidator<T> validator, T model)
    {
        var result = validator.Validate(model);
        if(result.IsValid)
            return new List<ModelValidationError>();
        return result.Errors
            .Select(failure => new ModelValidationError(failure.PropertyName, failure.ErrorMessage))
            .ToList();
    }
}