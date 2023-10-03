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

namespace Glitter.Generics;

/// <summary>
/// Defines a collection of extension methods for supporting clean in clauses on the fly.
/// </summary>
public static class InExtensions
{
    /// <summary>
    /// Determines whether the specified value is in a collection of specified values.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="values">The values to check against.</param>
    /// <returns><see langword="true"/> if the specified value is in the specified values; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="values"/> is <see langword="null"/> or empty.
    /// </exception>
    [SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Validation logic should not be nested.")]
    public static bool In<T>(this T value, IEnumerable<T> values)
    {
        if (values?.Any() != true)
            throw new ArgumentException("At least one value is required to evaluate the in clause.", nameof(values));

        return values.Contains(value);
    }

    /// <summary>
    /// Determines whether the specified value is in a collection of specified values.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="values">The values to check against.</param>
    /// <returns><see langword="true"/> if the specified value is in the specified values; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="values"/> is <see langword="null"/> or empty.
    /// </exception>
    [SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Validation logic should not be nested.")]
    public static bool In<T>(this T value, params T[] values)
    {
        if (values?.Any() != true)
            throw new ArgumentException("At least one value is required to evaluate the in clause.", nameof(values));

        return values.Contains(value);
    }

    /// <summary>
    /// Determines whether the specified value is in a collection of specified values.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="comparer">The comparer to use.</param>
    /// <param name="values">The values to check against.</param>
    /// <returns><see langword="true"/> if the specified value is in the specified values; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="comparer"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="values"/> is <see langword="null"/> or empty.
    /// </exception>
    [SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Validation logic should not be nested.")]
    public static bool In<T>(this T value, IEqualityComparer<T> comparer, IEnumerable<T> values)
    {
        if (comparer is null)
            throw new ArgumentNullException(nameof(comparer));

        if (values?.Any() != true)
            throw new ArgumentException("At least one value is required to evaluate the in clause.", nameof(values));

        return values.Contains(value, comparer);
    }

        /// <summary>
    /// Determines whether the specified value is in a collection of specified values.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="comparer">The comparer to use.</param>
    /// <param name="values">The values to check against.</param>
    /// <returns><see langword="true"/> if the specified value is in the specified values; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="comparer"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="values"/> is <see langword="null"/> or empty.
    /// </exception>
    [SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Validation logic should not be nested.")]
    public static bool In<T>(this T value, IEqualityComparer<T> comparer, params T[] values)
    {
        if (comparer is null)
            throw new ArgumentNullException(nameof(comparer));

        if (values?.Any() != true)
            throw new ArgumentException("At least one value is required to evaluate the in clause.", nameof(values));

        return values.Contains(value, comparer);
    }
}