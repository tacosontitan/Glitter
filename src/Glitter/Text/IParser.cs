namespace Glitter.Text;

/// <summary>
/// Defines methods for parsing a string.
/// </summary>
public interface IParser
{
    /// <summary>
    /// Parses the specified value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <param name="formatProvider">An object providing culture-specific formatting information.</param>
    /// <returns>The result of the parse operation.</returns>
    object? Parse(string value, IFormatProvider? formatProvider);
    
    /// <summary>
    /// Attempts to parse the specified value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <param name="formatProvider">An object providing culture-specific formatting information.</param>
    /// <param name="result">The result of the parse operation.</param>
    /// <returns><see langword="true"/> if the parse was successful; otherwise, <see langword="false"/>.</returns>
    bool TryParse(string? value, IFormatProvider? formatProvider, out object result);
}

/// <summary>
/// Defines methods for parsing a string into a given type.
/// </summary>
/// <typeparam name="T">Specifies the type to parse into.</typeparam>
public interface IParser<T>
{
    /// <summary>
    /// Parses the specified value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <param name="formatProvider">An object providing culture-specific formatting information.</param>
    /// <returns>The result of the parse operation.</returns>
    T? Parse(string value, IFormatProvider? formatProvider);

    /// <summary>
    /// Attempts to parse the specified value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <param name="formatProvider">An object providing culture-specific formatting information.</param>
    /// <param name="result">The result of the parse operation.</param>
    /// <returns><see langword="true"/> if the parse was successful; otherwise, <see langword="false"/>.</returns>
    bool TryParse(string? value, IFormatProvider? formatProvider, out T? result);
}
