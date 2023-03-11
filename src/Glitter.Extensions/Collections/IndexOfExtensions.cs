namespace Glitter.Extensions.Collections;

/// <summary>
/// Defines a collection of extension methods.
/// </summary>
public static class IndexOfExtensions
{
    /// <summary>
    /// Gets the index of the specified search value in the collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="collection">The collection to iterate over.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>The index of the specified search value in the collection, or -1 if the search value is not found.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="collection"/> or <paramref name="predicate"/> is <see langword="null"/>.
    /// </exception>
    public static int IndexOf<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        if (collection is null)
            throw new ArgumentNullException(nameof(collection));

        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));

        int index = 0;
        foreach (T item in collection)
        {
            if (predicate(item))
                return index;

            index++;
        }

        return -1;
    }
    /// <summary>
    /// Gets the index of the specified search value in the collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="collection">The collection to iterate over.</param>
    /// <param name="searchValue">The value to search for.</param>
    /// <returns>The index of the specified search value in the collection, or -1 if the search value is not found.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="collection"/> or <paramref name="searchValue"/> is <see langword="null"/>.
    /// </exception>
    public static int IndexOf<T>(this IEnumerable<T> collection, T searchValue)
    {
        if (collection is null)
            throw new ArgumentNullException(nameof(collection));

        if (searchValue is null)
            throw new ArgumentNullException(nameof(searchValue));

        int index = 0;
        foreach (T item in collection)
        {
            if (searchValue.Equals(item))
                return index;

            index++;
        }

        return -1;
    }
}