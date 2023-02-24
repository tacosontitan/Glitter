namespace Glitter.Extensions.Collections;

/// <summary>
/// Defines a collection of extension methods for the <see cref="IEnumerable{T}"/> interface.
/// </summary>
public static class IEnumerableExtensions
{
    /// <summary>
    /// Returns the previous element in the collection before the specified search value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="collection">The collection to iterate over.</param>
    /// <param name="searchValue">The value to search for.</param>
    /// <param name="wrapAround">Whether to wrap around to the last element if the search value is at the beginning of the collection.</param>
    /// <returns>The previous element in the collection before the specified search value, or <see langword="null"/> if the search value is not found.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="collection"/> or <paramref name="searchValue"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="IndexOutOfRangeException">
    /// The search value is at the beginning of the collection and <paramref name="wrapAround"/> is <see langword="false"/>.
    /// </exception>
    public static T? Previous<T>(this IEnumerable<T> collection, T searchValue, bool wrapAround = false)
    {
        if (collection is null)
            throw new ArgumentNullException(nameof(collection));

        if (searchValue is null)
            throw new ArgumentNullException(nameof(searchValue));

        int index = collection.IndexOf(searchValue);
        if (index == -1)
            return default;

        if (index == 0)
            return wrapAround
                ? collection.ElementAtOrDefault(collection.Count() - 1)
                : throw new IndexOutOfRangeException("The search value is at the beginning of the collection and wrap around is disabled.");

        return collection.ElementAtOrDefault(index - 1);
    }
    /// <summary>
    /// Returns a collection of distinct elements from the specified collection, using the specified selector function to determine equality.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <typeparam name="TResult">The type of the elements in the result collection.</typeparam>
    /// <param name="collection">The collection to iterate over.</param>
    /// <param name="selector">The selector function to determine equality.</param>
    /// <returns>A collection of distinct elements from the specified collection.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="collection"/> or <paramref name="selector"/> is <see langword="null"/>.
    /// </exception>
    public static IEnumerable<TResult> SelectDistinct<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> selector)
    {
        if (collection is null)
            throw new ArgumentNullException(nameof(collection));

        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        if (!collection.Any())
            return Enumerable.Empty<TResult>();

        IEnumerable<TResult> selection = collection.Select(selector);
        return selection is null
            ? Enumerable.Empty<TResult>()
            : selection.Distinct();
    }
}