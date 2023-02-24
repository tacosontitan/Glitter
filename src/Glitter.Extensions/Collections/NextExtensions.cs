namespace Glitter.Extensions.Collections;

public static class NextExtensions
{
    /// <summary>
    /// Returns the next element in the collection after the specified search value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="collection">The collection to iterate over.</param>
    /// <param name="searchValue">The value to search for.</param>
    /// <param name="wrapAround">Whether to wrap around to the first element if the search value is at the end of the collection.</param>
    /// <returns>The next element in the collection after the specified search value, or <see langword="null"/> if the search value is not found.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="collection"/> or <paramref name="searchValue"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="IndexOutOfRangeException">
    /// The search value is at the end of the collection and <paramref name="wrapAround"/> is <see langword="false"/>.
    /// </exception>
    public static T? Next<T>(this IEnumerable<T> collection, T searchValue, bool wrapAround = false)
    {
        if (collection is null)
            throw new ArgumentNullException(nameof(collection));

        if (searchValue is null)
            throw new ArgumentNullException(nameof(searchValue));

        int index = collection.IndexOf(searchValue);
        if (index == -1)
            return default;

        if (index == collection.Count() - 1)
            return wrapAround
                ? collection.ElementAtOrDefault(0)
                : throw new IndexOutOfRangeException("The search value is at the end of the collection and wrap around is disabled.");

        return collection.ElementAtOrDefault(index + 1);
    }
}