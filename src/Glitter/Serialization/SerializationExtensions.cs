namespace Glitter.Serialization;

/// <summary>
/// Defines a set of extension methods for serializing and deserializing objects using a specific serialization provider.
/// </summary>
public static class SerializationExtensions
{
    /// <summary>
    /// Serializes the specified input using the specified serialization provider.
    /// </summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TProvider">The type of the serialization provider.</typeparam>
    /// <param name="input">The input to serialize.</param>
    /// <returns>The serialized data.</returns>
    /// <remarks>This method does not capture exceptions thrown by the serialization provider.</remarks>
    public static string Serialize<TInput, TProvider>(this TInput input) where TProvider : ISerializationProvider, new()
    {
        var provider = new TProvider();
        return provider.Serialize(input);
    }
    /// <summary>
    /// Deserializes the specified serialized data using the specified serialization provider.
    /// </summary>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    /// <typeparam name="TProvider">The type of the serialization provider.</typeparam>
    /// <param name="input">The serialized data.</param>
    /// <returns>The deserialized object.</returns>
    /// <remarks>This method does not capture exceptions thrown by the serialization provider.</remarks>
    public static TOutput Deserialize<TOutput, TProvider>(this string input) where TProvider : ISerializationProvider, new()
    {
        var provider = new TProvider();
        return provider.Deserialize<TOutput>(input);
    }
}