namespace Glitter.Serialization;

/// <summary>
/// Defines methods for serializing and deserializing objects.
/// </summary>
public interface ISerializationProvider
{
    /// <summary>
    /// Serializes the specified value.
    /// </summary>
    /// <param name="value">The value to serialize.</param>
    /// <param name="formatProvider">An object providing culture-specific formatting information.</param>
    /// <returns>The result of the serialization operation.</returns>
    string Serialize<T>(T? value, IFormatProvider? formatProvider = null);
    
    /// <summary>
    /// Deserializes the specified value.
    /// </summary>
    /// <param name="value">The value to deserialize.</param>
    /// <param name="formatProvider">An object providing culture-specific formatting information.</param>
    /// <returns>The result of the deserialization operation.</returns>
    T? Deserialize<T>(string? value, IFormatProvider? formatProvider = null);
}
