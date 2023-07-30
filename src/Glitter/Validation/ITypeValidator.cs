namespace Glitter.Validation;

/// <summary>
/// Defines methods for providing type specific validation.
/// </summary>
/// <typeparam name="T">The type of the value to validate.</typeparam>
public interface ITypeValidator<T>
    : IValidator
{
    /// <summary>
    /// Validates the specified value.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    ValidationResult<T> Validate(T? value);
}
