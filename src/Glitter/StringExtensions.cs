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
    [Obsolete(message: "This extension will be removed in the next major release. Use string.IsNullOrWhiteSpace instead.")]
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
    [Obsolete(message: "This extension will be removed in the next major release. Use string.IsNullOrEmpty instead.")]
    public static bool IsNullOrEmpty(this string value) =>
        string.IsNullOrEmpty(value);
}