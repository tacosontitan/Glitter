namespace Glitter.Validation;

/// <summary>
/// Defines extension methods for a <see cref="GuardedValue{T}"/> that protect against values not being <see langword="null"/>.
/// </summary>
public static class AgainstNotNullExtensions
{
    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> if the specified value is not <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to guard.</typeparam>
    /// <param name="guardedValue">The value to guard.</param>
    /// <param name="message">The message to use in the exception.</param>
    /// <returns>The value to guard.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="guardedValue"/> is <see langword="null"/>.
    /// </exception>
    public static GuardedValue<T> AgainstNotNull<T>(
        this GuardedValue<T> guardedValue,
        string? message = "The specified value must be null.")
    {
        if (guardedValue is null)
            throw new ArgumentNullException(nameof(guardedValue));

        if (guardedValue.Argument is not null)
            throw new ArgumentException(message, guardedValue.ArgumentName);

        return guardedValue;
    }
}