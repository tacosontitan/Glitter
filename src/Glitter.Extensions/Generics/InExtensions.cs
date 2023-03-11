using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glitter.Extensions.Generics;

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
    public static bool In<T>(this T value, params T[] values)
    {
        if (values?.Any() != true)
            throw new ArgumentException("At least one value is required to evaluate the in clause.", nameof(values));
        
        return values.Contains(value);
    }
}