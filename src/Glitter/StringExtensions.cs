namespace Glitter;

/// <summary>
/// Defines a set of extension methods for <see cref="string"/> instances.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Determines whether the specified string is <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>
    /// <see langword="true"/>
    /// if <paramref name="value"/> is <see langword="null"/>, empty, or consists only of white-space characters;
    /// otherwise <see langword="false"/>.
    /// </returns>
    public static bool IsNullOrWhiteSpace(this string value) =>
        string.IsNullOrWhiteSpace(value);
    
    /// <summary>
    /// Determines whether the specified string is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>
    /// <see langword="true"/>
    /// if <paramref name="value"/> is <see langword="null"/> or empty;
    /// otherwise <see langword="false"/>.
    /// </returns>
    public static bool IsNullOrEmpty(this string value) =>
        string.IsNullOrEmpty(value);

    /// <summary>
    /// Creates a <see cref="Clamped{T}"/> instance for traversing the specified string.
    /// </summary>
    /// <param name="source">The string to create a <see cref="Clamped{T}"/> instance for.</param>
    /// <returns>A <see cref="Clamped{T}"/> instance for the specified string.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> is <see langword="null"/>.
    /// </exception>
    public static Clamped<int> CreateClamp(this string source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        
        if (source.Length == 0)
            throw new ArgumentException("The string cannot be empty.", nameof(source));

        return new Clamped<int>(
            value: 0,
            lowerBound: 0,
            upperBound: source.Length);
    }
}