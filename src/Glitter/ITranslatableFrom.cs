namespace Glitter;

/// <summary>
/// Defines a method to translate from a specified type to the consuming type.
/// </summary>
/// <typeparam name="TSelf">Specifies the consuming type capable of recieving the target type.</typeparam>
/// <typeparam name="TFrom">Specifies the type to translate into the consumer type from.</typeparam>
public interface ITranslatableFrom<TSelf, TFrom> where TSelf : ITranslatableFrom<TSelf, TFrom>
{
    /// <summary>
    /// Translates from a type to another type.
    /// </summary>
    /// <param name="from">The type to translate from.</param>
    /// <returns>The type to translate to.</returns>
    TSelf Translate(TFrom from);
}