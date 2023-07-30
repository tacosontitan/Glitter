namespace Glitter.Validation;

/// <summary>
/// Defines methods for providing basic validation.
/// </summary>
public interface IValidator
{
    /// <summary>
    /// Validates the specified value.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    ValidationResult<object> Validate(object? value);
}
