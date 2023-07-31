namespace Glitter.Validation;

/// <summary>
/// Defines methods for providing asynchronous validation.
/// </summary>
/// <typeparam name="T">The type of value to validate.</typeparam>
public interface IAsyncTypeValidator<T>
    : IAsyncValidator,
      ITypeValidator<T>
{
    /// <summary>
    /// Validates the specified value.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous validation operation.</returns>
    Task<ValidationResult<T?>> Validate(T? value, CancellationToken cancellationToken = default);
}
