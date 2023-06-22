namespace BeSpoked.Common;

/// <summary>
/// Represents a validation error when validating a model.
/// </summary>
public class ModelValidationError
{
    /// <summary>
    /// Gets or sets the name of the field that is in error.
    /// </summary>
    public string Field { get; }

    /// <summary>
    /// Human friendly error message
    /// </summary>
    public string ErrorMessage { get; }
        
    public ModelValidationError(string field, string errorMessage)
    {
        Field = field;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Easy to read version
    /// </summary>
    public override string ToString()
    {
        return $"{nameof(Field)}: {Field}, {nameof(ErrorMessage)}: {ErrorMessage}";
    }
}