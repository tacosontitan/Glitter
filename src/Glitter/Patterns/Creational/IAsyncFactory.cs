namespace Glitter.Patterns.Creational;

/// <summary>
/// Represents a factory for creating instances of <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of object to create.</typeparam>
public interface IAsyncFactory<T>
{
    /// <summary>
    /// Creates a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <returns>A new instance of <typeparamref name="T"/>.</returns>
    Task<T> Create(CancellationToken cancellationToken);
}
