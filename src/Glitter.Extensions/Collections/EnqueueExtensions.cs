using System;
using System.Collections.Generic;

namespace Glitter.Extensions.Collections;

/// <summary>
/// Defines a collection of extension methods.
/// </summary>
public static class EnqueueExtensions
{
    /// <summary>
    /// Enqueues a collection of elements to the queue.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the queue.</typeparam>
    /// <param name="source">The queue to enqueue to.</param>
    /// <param name="items">The elements to enqueue.</param>
    /// <returns>The queue.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="items"/> is <see langword="null"/>.
    /// </exception>
    public static Queue<T> Enqueue<T>(this Queue<T> source, IEnumerable<T> items)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (items is null)
            throw new ArgumentNullException(nameof(items));

        foreach (T item in items)
            source.Enqueue(item);

        return source;
    }
    /// <summary>
    ///  Enqueues a collection of elements to the queue.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the queue.</typeparam>
    /// <param name="source">The queue to enqueue to.</param>
    /// <param name="items">The elements to enqueue.</param>
    /// <returns>The queue.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="items"/> is <see langword="null"/>.
    /// </exception>
    public static Queue<T> Enqueue<T>(this Queue<T> source, params T[] items)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (items is null)
            throw new ArgumentNullException(nameof(items));

        foreach (T item in items)
            source.Enqueue(item);

        return source;
    }
}