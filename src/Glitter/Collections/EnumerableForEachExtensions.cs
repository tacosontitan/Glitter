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
public static class EnumerableForEachExtensions
{
    /// <summary>
    /// Executes the specified action on each element of the collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="action">The action to execute on each element.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null"/>.
    /// </exception>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (action is null)
            throw new ArgumentNullException(nameof(action));

        foreach (T? item in source)
            action(item);
    }

    /// <summary>
    /// Executes the specified action on each element of the collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="action">The action to execute on each element.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <param name="parallel">Whether to execute the action in parallel.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null"/>.
    /// </exception>
    public static async Task ForEach<T>(this IEnumerable<T> source, Action<T> action, bool parallel, CancellationToken cancellationToken) {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        
        if (action is null)
            throw new ArgumentNullException(nameof(action));
        
        if (parallel)
            _ = Parallel.ForEach(source, new ParallelOptions { CancellationToken = cancellationToken }, action);
        else
            await Task.Run(() => source.ForEach(action), cancellationToken).ConfigureAwait(false);
    }
    
    /// <summary>
    /// Executes the specified action on each element of the collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="action">The action to execute on each element.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="action"/> is <see langword="null"/>.
    /// </exception>
    /// <remarks>
    /// The action is passed the current element, the previous element, and the next element.
    /// </remarks>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T?, T?, T?> action)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (action is null)
            throw new ArgumentNullException(nameof(action));

        T? previous = default;
        T? current = default;
        T? next;

        using IEnumerator<T> enumerator = source.GetEnumerator();
        if (enumerator.MoveNext())
            current = enumerator.Current;

        while (true)
        {
            bool hasNext = enumerator.MoveNext();
            next = hasNext
                ? enumerator.Current
                : default;

            action(previous, current, next);
            previous = current;
            current = next;

            if (!hasNext)
                break;
        }
    }
}