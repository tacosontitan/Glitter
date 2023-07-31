namespace Glitter.Validation;

/// <summary>
/// Defines methods for providing asynchronous validation.
/// </summary>
public interface IAsyncValidator
    : IValidator
{
    /// <summary>
    /// Validates the specified value.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous validation operation.</returns>
    Task<ValidationResult> Validate(object? value, CancellationToken cancellationToken = default);
}
