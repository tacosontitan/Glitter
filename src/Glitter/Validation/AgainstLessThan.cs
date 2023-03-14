namespace Glitter.Validation;

/// <summary>
/// Defines extension methods for a <see cref="GuardedValue{T}"/> that protect against values that are less than a specified value.
/// </summary>
public static class AgainstLessThanExtensions
{
    /// <summary>
    /// Throws an <see cref="ArgumentException"/> if the specified value is less than the specified minimum.
    /// </summary>
    /// <typeparam name="T">The type of the value to guard.</typeparam>
    /// <param name="guardedValue">The value to guard.</param>
    /// <param name="minimum">The minimum value.</param>
    /// <param name="message">The message to use in the exception.</param>
    /// <returns>The value to guard.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="guardedValue"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="guardedValue"/> is less than <paramref name="minimum"/>.
    /// </exception>
    public static GuardedValue<T> AgainstLessThan<T>(
        this GuardedValue<T> guardedValue,
        T minimum,
        string? message = null)
        where T : IComparable<T>
    {
        if (guardedValue is null)
            throw new ArgumentNullException(nameof(guardedValue));

        if (guardedValue.Argument.CompareTo(minimum) < 0)
            throw new ArgumentException(message ?? $"The specified value cannot be less than {minimum}.", guardedValue.ArgumentName);

        return guardedValue;
    }
}