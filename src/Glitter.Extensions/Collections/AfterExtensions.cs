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
    /// <param name="searchValue">The value to search for.</param>
    /// <returns>A collection of elements from the specified collection that occur after the specified search value.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="searchValue"/> is <see langword="null"/>.
    /// </exception>
    public static IEnumerable<T> After<T>(this IEnumerable<T> source, T searchValue)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (searchValue is null)
            throw new ArgumentNullException(nameof(searchValue));

        int index = source.IndexOf(searchValue);
        return index == -1
            ? Enumerable.Empty<T>()
            : source.Skip(index + 1);
    }
    /// <summary>
    /// Returns a collection of elements from the specified collection that occur after the specified search value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="searchValue">The value to search for.</param>
    /// <param name="count">The number of elements to return.</param>
    /// <returns>A collection of elements from the specified collection that occur after the specified search value.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="searchValue"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="count"/> is less than one.
    /// </exception>
    public static IEnumerable<T> After<T>(this IEnumerable<T> source, T searchValue, int count)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (searchValue is null)
            throw new ArgumentNullException(nameof(searchValue));

        if (count < 1)
            throw new ArgumentOutOfRangeException(nameof(count), count, "The requested element count cannot be less than one.");

        return source.After(searchValue)
                     .Take(count);
    }
}