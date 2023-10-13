namespace Glitter;

/// <summary>
/// Represents a service factory.
/// </summary>
public interface IServiceFactory
{
    /// <summary>
    /// Gets the service of the specified type.
    /// </summary>
    /// <typeparam name="TService">Specifies the type of the service.</typeparam>
    /// <param name="parameters">The parameters to use when constructing the service.</param>
    /// <returns>The service of the specified type.</returns>
    TService GetService<TService>(params object[] parameters);
    
    /// <summary>
    /// Gets the service of the specified type.
    /// </summary>
    /// <typeparam name="TService">Specifies the type of the service.</typeparam>
    /// <param name="parameters">The parameters to use when constructing the service.</param>
    /// <returns>The service of the specified type.</returns>
    /// <exception cref="InvalidOperationException">The service of the specified type is not registered.</exception>
    TService GetRequiredService<TService>(params object[] parameters);
}
