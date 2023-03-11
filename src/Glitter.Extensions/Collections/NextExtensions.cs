using System;
using System.Collections.Generic;
using System.Linq;

namespace Glitter.Extensions.Collections;

/// <summary>
/// Defines a collection of extension methods.
/// </summary>
public static class NextExtensions
{
    /// <summary>
    /// Returns the next element in the collection after the specified search value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="searchValue">The value to search for.</param>
    /// <param name="wrapAround">Whether to wrap around to the first element if the search value is at the end of the collection.</param>
    /// <returns>The next element in the collection after the specified search value, or <see langword="null"/> if the search value is not found.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="searchValue"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="IndexOutOfRangeException">
    /// The search value is at the end of the collection and <paramref name="wrapAround"/> is <see langword="false"/>.
    /// </exception>
    public static T? Next<T>(this IEnumerable<T> source, T searchValue, bool wrapAround = false)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (searchValue is null)
            throw new ArgumentNullException(nameof(searchValue));

        int index = source.IndexOf(searchValue);
        return index == -1
            ? default
            : index == 0
                ? wrapAround
                    ? source.FirstOrDefault()
                    : throw new IndexOutOfRangeException("The search value is at the beginning of the collection and wrap around is disabled.")
                : source.ElementAtOrDefault(index - 1);
    }
    /// <summary>
    /// Returns the next element in the collection after the specified search value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="wrapAround">Whether to wrap around to the first element if the search value is at the end of the collection.</param>
    /// <returns>The next element in the collection after the specified search value, or <see langword="null"/> if the search value is not found.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="IndexOutOfRangeException">
    /// The search value is at the end of the collection and <paramref name="wrapAround"/> is <see langword="false"/>.
    /// </exception>
    public static T? Next<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool wrapAround = false)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));

        int index = source.IndexOf(predicate);
        return index == -1
            ? default
            : index == 0
                ? wrapAround
                    ? source.FirstOrDefault()
                    : throw new IndexOutOfRangeException("The search value is at the beginning of the collection and wrap around is disabled.")
                : source.ElementAtOrDefault(index - 1);
    }
}