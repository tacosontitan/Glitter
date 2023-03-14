namespace Glitter.Validation;

/// <summary>
/// Defines extension methods for a <see cref="GuardedValue{T}"/> that protect against values that are equal to a specified value.
/// </summary>
public static class AgainstEqualToExtensions
{
    /// <summary>
    /// Throws an <see cref="ArgumentException"/> if the specified value is equal to a specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value to guard.</typeparam>
    /// <param name="guardedValue">The value to guard.</param>
    /// <param name="value">The value to compare to.</param>
    /// <param name="message">The message to use in the exception.</param>
    /// <returns>The value to guard.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="guardedValue"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="guardedValue"/> is equal to <paramref name="value"/>.
    /// </exception>
    public static GuardedValue<T> AgainstEqualTo<T>(
        this GuardedValue<T> guardedValue,
        T value,
        string? message = null)
    {
        if (guardedValue is null)
            throw new ArgumentNullException(nameof(guardedValue));

        if (guardedValue.Argument is null)
            throw new ArgumentNullException(nameof(guardedValue.Argument));

        if (guardedValue.Argument.Equals(value))
            throw new ArgumentException(message ?? $"The specified value cannot be equal to {value}.", guardedValue.ArgumentName);

        return guardedValue;
    }
}