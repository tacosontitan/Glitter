namespace Glitter.Extensions;

/// <summary>
/// Defines a set of extension methods for determining whether a value is within a specified set.
/// </summary>
public static class WithinExtensions
{
    /// <summary>
    /// Determines whether the specified input value is within the specified bounds.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <param name="lowerBound">The lower bound.</param>
    /// <param name="upperBound">The upper bound.</param>
    /// <returns><see langword="true"/> if the input value is within the specified bounds; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="input"/>, <paramref name="lowerBound"/>, or <paramref name="upperBound"/> is <see langword="null"/>.
    /// </exception>
    public static bool Within<T>(this T input, T lowerBound, T upperBound) where T : IComparable
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        
        if (lowerBound is null)
            throw new ArgumentNullException(nameof(lowerBound));

        if (upperBound is null)
            throw new ArgumentNullException(nameof(upperBound));

        return input.CompareTo(lowerBound) >= 0 && input.CompareTo(upperBound) <= 0;
    }
}