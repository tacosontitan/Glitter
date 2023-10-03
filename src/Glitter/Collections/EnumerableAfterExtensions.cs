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
public static class EnumerableAfterExtensions
{
    /// <summary>
    /// Returns a collection of elements from the specified collection that occur after the specified search value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A collection of elements from the specified collection that occur after the specified search value.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
    /// </exception>
    [SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Validation logic should not be nested.")]
    public static IEnumerable<T> After<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));

        return source
            .SkipWhile(element => !predicate(element))
            .Skip(1);
    }
    
    /// <summary>
    /// Returns a collection of elements from the specified collection that occur after the specified search value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="searchValue">The value to search for.</param>
    /// <returns>A collection of elements from the specified collection that occur after the specified search value.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="searchValue"/> is <see langword="null"/>.
    /// </exception>
    [SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Validation logic should not be nested.")]
    public static IEnumerable<T> After<T>(this IEnumerable<T> source, T searchValue)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (searchValue is null)
            throw new ArgumentNullException(nameof(searchValue));

        return source
            .SkipWhile(element => !searchValue.Equals(element))
            .Skip(1);
    }
}