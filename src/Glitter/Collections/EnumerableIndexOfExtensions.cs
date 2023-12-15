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
public static class EnumerableIndexOfExtensions
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