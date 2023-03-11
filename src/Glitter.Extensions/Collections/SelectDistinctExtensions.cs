using System;
using System.Collections.Generic;
using System.Linq;

namespace Glitter.Extensions.Collections;

/// <summary>
/// Defines a collection of extension methods.
/// </summary>
public static class SelectDistinctExtensions
{
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
    [SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Validation logic should not be nested.")]
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