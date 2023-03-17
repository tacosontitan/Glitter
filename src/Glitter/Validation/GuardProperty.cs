namespace Glitter.Validation;

/// <summary>
/// Defines extension methods for a <see cref="GuardedValue{T}"/> that protect properties of a specified type.
/// </summary>
public static class GuardPropertyExtensions
{
    /// <summary>
    /// Protects the specified property of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to protect.</typeparam>
    /// <typeparam name="TProperty">The type of the property to protect.</typeparam>
    /// <param name="parent">The <see cref="GuardedValue{T}"/> to protect the property of.</param>
    /// <param name="propertyName">The name of the property to protect.</param>
    /// <param name="propertySelector">A function that selects the property to protect.</param>
    /// <param name="propertyGuard">A function that protects the property.</param>
    /// <returns>The <see cref="GuardedValue{T}"/> that was passed in.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="parent"/>, <paramref name="propertySelector"/>, or <paramref name="propertyGuard"/> is <see langword="null"/>.
    /// </exception>
    public static GuardedValue<T> GuardProperty<T, TProperty>(
        this GuardedValue<T> parent,
        string propertyName,
        Func<T, TProperty> propertySelector,
        Action<GuardedValue<TProperty>> propertyGuard)
    {
        if (parent is null)
            throw new ArgumentNullException(nameof(parent));

        if (propertySelector is null)
            throw new ArgumentNullException(nameof(propertySelector));
        
        if (propertyGuard is null)
            throw new ArgumentNullException(nameof(propertyGuard));
        
        var guardedProperty = new GuardedValue<TProperty>(propertySelector(parent.Argument), propertyName);
        propertyGuard(guardedProperty);
        return parent;
    }
}