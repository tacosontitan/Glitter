namespace Glitter.Validation;

/// <summary>
/// Defines extension methods for a <see cref="GuardedValue{T}"/> that protect against values that are greater than a specified value.
/// </summary>
public static class AgainstGreaterThanExtensions
{
    /// <summary>
    /// Throws an <see cref="ArgumentException"/> if the specified value is greater than the specified maximum.
    /// </summary>
    /// <typeparam name="T">The type of the value to guard.</typeparam>
    /// <param name="guardedValue">The value to guard.</param>
    /// <param name="maximum">The minimum value.</param>
    /// <param name="message">The message to use in the exception.</param>
    /// <returns>The value to guard.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="guardedValue"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="guardedValue"/> is greater than <paramref name="minimum"/>.
    /// </exception>
    public static GuardedValue<T> AgainstGreaterThan<T>(
        this GuardedValue<T> guardedValue,
        T maximum,
        string? message = null)
        where T : IComparable<T>
    {
        if (guardedValue is null)
            throw new ArgumentNullException(nameof(guardedValue));

        if (guardedValue.Argument.CompareTo(maximum) < 0)
            throw new ArgumentException(message ?? $"The specified value cannot be greater than {maximum}.", guardedValue.ArgumentName);

        return guardedValue;
    }
}