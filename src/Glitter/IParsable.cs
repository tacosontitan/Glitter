namespace Glitter;

/// <summary>
/// Defines methods for parsing a string into a given type.
/// </summary>
/// <typeparam name="TSelf">Specifies the type to parse into.</typeparam>
public interface IParsable<TSelf>
    where TSelf : IParsable<TSelf>?
{
    /// <summary>
    /// Parses the specified value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <param name="formatProvider">An object providing culture-specific formatting information.</param>
    /// <returns>The result of the parse operation.</returns>
    TSelf Parse(string value, IFormatProvider? formatProvider);
    
    /// <summary>
    /// Attempts to parse the specified value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <param name="formatProvider">An object providing culture-specific formatting information.</param>
    /// <param name="result">The result of the parse operation.</param>
    /// <returns><see langword="true"/> if the parse was successful; otherwise, <see langword="false"/>.</returns>
    bool TryParse(string? value, IFormatProvider? formatProvider, out TSelf result);
}
