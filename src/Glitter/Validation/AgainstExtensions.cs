namespace Glitter.Validation;

/// <summary>
/// Represents a guard for a value.
/// </summary>
/// <typeparam name="T">The type of the value to guard.</typeparam>
public static class AgainstExtensions
{
    /// <summary>
    /// Throws an <see cref="ArgumentException"/> if the specified predicate returns <see langword="true"/>.
    /// </summary>
    /// <param name="guard">The guard.</param>
    /// <param name="predicate">The predicate to test the value against.</param>
    /// <param name="message">The message to use in the exception.</param>
    /// <returns>The guard.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="guard"/> is <see langword="null"/>.
    /// <para>- or -</para>
    /// <paramref name="predicate"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// The specified value is invalid.
    /// </exception>
    public static GuardedValue<T> Against<T>(this GuardedValue<T> guardedValue, Func<T, bool> predicate, string? message = null)
    {
        if (guardedValue is null)
            throw new ArgumentNullException(nameof(guardedValue));

        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));

        if (predicate(guardedValue.Argument))
            throw new ArgumentException(message ?? "The specified value is invalid.", guardedValue.ArgumentName);
            
        return guardedValue;
    }
}