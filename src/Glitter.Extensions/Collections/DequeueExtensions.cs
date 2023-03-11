using System;
using System.Collections.Generic;
using System.Linq;

namespace Glitter.Extensions.Collections;

/// <summary>
/// Defines a collection of extension methods.
/// </summary>
public static class DequeueExtensions
{
    /// <summary>
    /// Dequeues a specified number of elements from the queue.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the queue.</typeparam>
    /// <param name="source">The queue to dequeue from.</param>
    /// <param name="count">The number of elements to dequeue.</param>
    /// <returns>A collection of elements from the queue.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// <paramref name="source"/> is empty.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="count"/> is negative.
    /// </exception>
    public static IEnumerable<T> Dequeue<T>(this Queue<T> source, int count)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "The number of elements to dequeue cannot be negative.");

        if (count > source.Count)
            throw new ArgumentOutOfRangeException(nameof(count), "The number of elements to dequeue cannot be greater than the number of elements in the queue.");

        if (!source.Any())
            throw new InvalidOperationException("The queue is empty.");

        for (int i = 0; i < count; i++)
            yield return source.Dequeue();

        yield break;
    }
}