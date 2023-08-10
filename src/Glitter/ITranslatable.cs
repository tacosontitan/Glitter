namespace Glitter;

/// <summary>
/// Defines methods for translating to and from a type.
/// </summary>
/// <typeparam name="TSelf">Specifies the consuming translatable type.</typeparam>
/// <typeparam name="T">Specifies the target translatable type.</typeparam>
/// <remarks>
/// This interface simplifies the implementation definition of <see cref="ITranslatableTo{TSelf, TTo}"/> and <see cref="ITranslatableFrom{TSelf, TFrom}"/>.
/// </remarks>
public interface ITranslatable<TSelf, T> :
    ITranslatableFrom<TSelf, T>,
    ITranslatableTo<TSelf, T>
    where TSelf : ITranslatable<TSelf, T>
{ }
