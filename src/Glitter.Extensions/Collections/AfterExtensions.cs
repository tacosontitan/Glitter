using System;
using System.Collections.Generic;
using System.Linq;

namespace Glitter.Extensions.Collections;

/// <summary>
/// Defines a collection of extension methods.
/// </summary>
public static class AfterExtensions
{
    /// <summary>
    /// Returns a collection of elements from the specified collection that occur after the specified search value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A collection of elements from the specified collection that occur after the specified search value.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
    /// </exception>
    [SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Validation logic should not be nested.")]
    public static IEnumerable<T> After<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));

        return source
            .SkipWhile(element => !predicate(element))
            .Skip(1);
    }
    /// <summary>
    /// Returns a collection of elements from the specified collection that occur after the specified search value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="searchValue">The value to search for.</param>
    /// <returns>A collection of elements from the specified collection that occur after the specified search value.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="searchValue"/> is <see langword="null"/>.
    /// </exception>
    [SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Validation logic should not be nested.")]
    public static IEnumerable<T> After<T>(this IEnumerable<T> source, T searchValue)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (searchValue is null)
            throw new ArgumentNullException(nameof(searchValue));

        return source
            .SkipWhile(element => searchValue.Equals(element))
            .Skip(1);
    }
}