namespace Glitter.Validation;

/// <summary>
/// Defines methods for creating guards.
/// </summary>
public static class CreateGuard
{
    /// <summary>
    /// Creates a guard for the specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value to guard.</typeparam>
    /// <param name="value">The value to guard.</param>
    /// <param name="name">The name of the value to guard.</param>
    /// <returns>A guard for the specified value.</returns>
    public static GuardedValue<T> For<T>(T value, string? name = null) =>
        new GuardedValue<T>(value, name);
}