namespace Glitter.Validation;

/// <summary>
/// Represents the result of a validation.
/// </summary>
public class ValidationResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult"/> class.
    /// </summary>
    /// <param name="exceptions">The validation exceptions.</param>
    public ValidationResult(IEnumerable<Exception>? exceptions) =>
        Exceptions = exceptions;

    /// <summary>
    /// Gets the validation exceptions.
    /// </summary>
    public IEnumerable<Exception>? Exceptions { get; }

    /// <summary>
    /// Gets a value indicating whether the validation was successful.
    /// </summary>
    public bool Successful =>
        Exceptions?.Any() != true;
}

/// <summary>
/// Represents the result of a validation.
/// </summary>
/// <typeparam name="T">The type of the validated value.</typeparam>
public class ValidationResult<T>
    : ValidationResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult{T}"/> class.
    /// </summary>
    /// <param name="value">The validated value.</param>
    /// <param name="exceptions">The validation exceptions.</param>
    public ValidationResult(T? value, IEnumerable<Exception>? exceptions)
        : base(exceptions) =>
        Value = value;

    /// <summary>
    /// Gets the validated value.
    /// </summary>
    public T? Value { get; }
}
