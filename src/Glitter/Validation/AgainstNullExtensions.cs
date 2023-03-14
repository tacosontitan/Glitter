namespace Glitter.Validation;

/// <summary>
/// Defines extension methods for a <see cref="GuardedValue{T}"/> that protect against <see langword="null"/> values.
/// </summary>
public static class AgainstNullExtensions
{
    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> if the specified value is <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to guard.</typeparam>
    /// <param name="guardedValue">The value to guard.</param>
    /// <returns>The value to guard.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="guardedValue"/> is <see langword="null"/>.
    /// </exception>
    public static GuardedValue<T> AgainstNull<T>(this GuardedValue<T> guardedValue)
    {
        if (guardedValue.Argument is null)
            throw new ArgumentNullException(guardedValue.ArgumentName);

        return guardedValue;
    }
}