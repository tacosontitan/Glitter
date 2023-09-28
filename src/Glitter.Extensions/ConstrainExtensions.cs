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

namespace Glitter.Extensions;

/// <summary>
/// Defines a set of extension methods for constraining values.
/// </summary>
public static class ConstrainExtensions
{
    /// <summary>
    /// Constrains the specified input value to be within the specified bounds.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <param name="lowerBound">The lower bound.</param>
    /// <param name="upperBound">The upper bound.</param>
    /// <returns>The constrained value.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="input"/>, <paramref name="lowerBound"/>, or <paramref name="upperBound"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="lowerBound"/> is greater than <paramref name="upperBound"/>.
    /// </exception>
    public static T Constrain<T>(this T input, T lowerBound, T upperBound) where T : IComparable
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        if (lowerBound is null)
            throw new ArgumentNullException(nameof(lowerBound));

        if (upperBound is null)
            throw new ArgumentNullException(nameof(upperBound));

        if (lowerBound.CompareTo(upperBound) > 0)
            throw new ArgumentException("The lower bound must be less than or equal to the upper bound.", nameof(lowerBound));

        if (input.CompareTo(lowerBound) < 0)
            input = lowerBound;
        else if (input.CompareTo(upperBound) > 0)
            input = upperBound;

        return input;
    }
}