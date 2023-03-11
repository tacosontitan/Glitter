using System;
using System.Collections.Generic;

namespace Glitter.Extensions.Collections;

/// <summary>
/// Defines a collection of extension methods.
/// </summary>
public static class ForEachExtensions
{
    /// <summary>
    /// Executes the specified action on each element of the collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="action">The action to execute on each element.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null"/>.
    /// </exception>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (action is null)
            throw new ArgumentNullException(nameof(action));

        foreach (T? item in source)
            action(item);
    }
    /// <summary>
    /// Executes the specified action on each element of the collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="action">The action to execute on each element.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null"/>.
    /// </exception>
    /// <remarks>
    /// The action is passed the current element, the previous element, and the next element.
    /// </remarks>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T?, T?, T?> action)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (action is null)
            throw new ArgumentNullException(nameof(action));

        T? previous = default;
        T? current = default;
        T? next = default;

        using IEnumerator<T> enumerator = source.GetEnumerator();
        if (enumerator.MoveNext())
            current = enumerator.Current;

        while (true)
        {
            bool hasNext = enumerator.MoveNext();
            next = hasNext
                ? enumerator.Current
                : default;

            action(previous, current, next);
            previous = current;
            current = next;

            if (!hasNext)
                break;
        }
    }
}