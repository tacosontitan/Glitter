namespace Glitter;

/// <summary>
/// Represents a service locator.
/// </summary>
public interface IServiceLocator
{
    /// <summary>
    /// Locates implementations for a specified service type.
    /// </summary>
    /// <typeparam name="TService">Specifies the type of the service.</typeparam>
    /// <returns>The implementations for the specified service type.</returns>
    IEnumerable<Type> LocateImplementationsOf<TService>();
}
