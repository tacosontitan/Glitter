namespace Glitter.Serialization;

public static class GenericExtensions
{
    public static string? Serialize<T>(this T source, ISerializationProvider serializationProvider)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        
        if (serializationProvider is null)
            throw new ArgumentNullException(nameof(serializationProvider));

        return serializationProvider.Serialize(source);
    }
}