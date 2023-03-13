namespace Glitter.Serialization;

/// <summary>
/// Defines methods for serializing and deserializing objects.
/// </summary>
public interface ISerializationProvider
{
    /// <summary>
    /// Serializes the specified input.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <param name="input">The input to serialize.</param>
    string Serialize<T>(T input);
    /// <summary>
    /// Deserializes the specified serialized data.
    /// </summary>
    /// <typeparam name="T">The type of the output.</typeparam>
    /// <param name="serializedData">The serialized data.</param>
    /// <returns>The deserialized object.</returns>
    T Deserialize<T>(string serializedData);
}