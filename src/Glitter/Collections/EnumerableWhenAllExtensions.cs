using System.Data;

namespace Glitter.Collections;

/// <summary>
/// Provides extension methods for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class EnumerableWhenAllExtensions
{
    /// <summary>
    /// Performs the specified action on each element of the <see cref="IEnumerable{T}"/> in parallel.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="action">The action to perform on each element.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static Task WhenAll<T>(
        this IEnumerable<T> source,
        Func<T, CancellationToken, Task> action,
        CancellationToken cancellationToken = default)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        
        if (action is null)
            throw new ArgumentNullException(nameof(action));

        IEnumerable<T> enumerable = source as T[] ?? source.ToArray();
        if (!enumerable.Any())
            return Task.CompletedTask;
        
        IEnumerable<Task> tasks = enumerable.Select(item => action(item, cancellationToken));
        return Task.WhenAll(tasks);
    }
    
    /// <summary>
    /// Performs the specified action on each element of the <see cref="IEnumerable{T}"/> in parallel.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <typeparam name="TOut">The type of the result of <paramref name="action"/>.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="action">The action to perform on each element.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static async Task<IEnumerable<TOut>> WhenAll<T, TOut>(
        this IEnumerable<T> source,
        Func<T, CancellationToken, Task<TOut>> action,
        CancellationToken cancellationToken = default)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        
        if (action is null)
            throw new ArgumentNullException(nameof(action));

        IEnumerable<T> enumerable = source as T[] ?? source.ToArray();
        if (!enumerable.Any())
            return Enumerable.Empty<TOut>();
        
        IEnumerable<Task<TOut>> tasks = enumerable.Select(item => action(item, cancellationToken));
        IEnumerable<TOut> results = await Task.WhenAll(tasks).ConfigureAwait(false);
        return results;
    }
}
