namespace Glitter.Validation;

/// <summary>
/// Defines extension methods for a <see cref="GuardedValue{T}"/> that protect against <see langword="null"/> or empty values.
/// </summary>
public static class AgainstNullOrWhiteSpaceExtensions
{
    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> if the specified value is <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to guard.</typeparam>
    /// <param name="guardedValue">The value to guard.</param>
    /// <param name="message">The message to use in the exception.</param>
    /// <returns>The value to guard.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="guardedValue"/> is <see langword="null"/>, empty, or whitespace.
    /// </exception>
    public static GuardedValue<T> AgainstNullOrWhiteSpace<T>(
        this GuardedValue<T> guardedValue,
        string? message = "The specified value cannot be null or empty.")
    {
        if (guardedValue is null)
            throw new ArgumentNullException(nameof(guardedValue));

        if (guardedValue.Argument is not string argumentString)
            throw new InvalidOperationException("The specified type is not a string.");

        if (string.IsNullOrWhiteSpace(argumentString))
            throw new ArgumentNullException(message, guardedValue.ArgumentName ?? string.Empty);

        return guardedValue;
    }
}