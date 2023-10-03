/*
   Copyright 2023 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace Glitter.Collections;

/// <summary>
/// Defines a collection of extension methods.
/// </summary>
public static class QueueExtensions
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

        var results = new T[count];
        for (int i = 0; i < count; i++)
            results[i] = source.Dequeue();

        return results;
    }
    
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