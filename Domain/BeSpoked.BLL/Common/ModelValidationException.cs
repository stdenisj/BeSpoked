namespace BeSpoked.Common;

/// <summary>
/// Represents an exception that is thrown during model validation.
/// </summary>
public sealed class ModelValidationException : Exception
{
    private static string GenerateErrorSummary(IEnumerable<ModelValidationError> validationErrors) => string.Join("\n", validationErrors);
        
    /// <summary>
    /// Gets a collection of <see cref="ModelValidationError"/> objects representing the errors that occurred during validation.
    /// </summary>
    public ICollection<ModelValidationError> ValidationErrors { get; }

    /// <summary>
    /// Initializes a new <see cref="ModelValidationException"/> instance with multiple errors.
    /// </summary>
    /// <param name="validationErrors">The errors that occurred during validation</param>
    public ModelValidationException(ICollection<ModelValidationError> validationErrors): base(GenerateErrorSummary(validationErrors))
    {
        ValidationErrors = validationErrors;
        AddErrorSummary(ValidationErrors);
    }
    
    private void AddErrorSummary(IEnumerable<ModelValidationError> validationErrors) => Data.Add("validationErrorSummary", GenerateErrorSummary(validationErrors));
}