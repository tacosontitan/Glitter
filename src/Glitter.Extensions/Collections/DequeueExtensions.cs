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
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="count"/> is negative.
    /// </exception>
    public static IEnumerable<T> Dequeue<T>(this Queue<T> source, int count)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "The number of elements to dequeue cannot be negative.");

        for (int i = 0; i < count; i++)
            yield return source.Dequeue();

        yield break;
    }
}