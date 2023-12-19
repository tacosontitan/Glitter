namespace Glitter.Serialization;

/// <summary>
/// Defines extension methods for serialization for generic types.
/// </summary>
public static class GenericExtensions
{
    /// <summary>
    /// Serializes the specified object.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="source">The object to serialize.</param>
    /// <param name="serializationProvider">The <see cref="ISerializationProvider"/> to use.</param>
    /// <returns>The serialized object.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> -or-
    /// <paramref name="serializationProvider"/> is <see langword="null"/>.
    /// </exception>
    public static string? Serialize<T>(this T source, ISerializationProvider serializationProvider)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (serializationProvider is null)
            throw new ArgumentNullException(nameof(serializationProvider));

        return serializationProvider.Serialize(source);
    }
}