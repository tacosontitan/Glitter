namespace Glitter;

/// <summary>
/// Defines a method to translate to a specified type from the consuming type.
/// </summary>
/// <typeparam name="TSelf">Specifies the consuming type capable of translating to the target type.</typeparam>
/// <typeparam name="TFrom">Specifies the type to translate into from the consumer type.</typeparam>
public interface ITranslatableTo<TSelf, TTo> where TSelf : ITranslatableTo<TSelf, TTo>
{
    /// <summary>
    /// Translates from a type to another type.
    /// </summary>
    /// <param name="from">The type to translate from.</param>
    /// <returns>The type to translate to.</returns>
    TTo Translate(TSelf from);
}