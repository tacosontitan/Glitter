namespace Glitter;

/// <summary>
/// Defines extension methods for <see cref="IComparable"/> instances.
public static class ComparableExtensions
{
    /// <summary>
    /// Clamps the specified input value to be within the specified bounds.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <param name="lowerBound">The lower bound.</param>
    /// <param name="upperBound">The upper bound.</param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="lowerBound"/> is greater than <paramref name="upperBound"/>.
    /// </exception>
    public static void Clamp<T>(this ref T input, T lowerBound, T upperBound)
        where T : struct, IComparable<T>
    {
        if (lowerBound.CompareTo(upperBound) > 0)
            throw new ArgumentException("The lower bound must be less than or equal to the upper bound.", nameof(lowerBound));

        if (input.CompareTo(lowerBound) < 0)
            input = lowerBound;
        else if (input.CompareTo(upperBound) > 0)
            input = upperBound;
    }
    
    /// <summary>
    /// Clamps the specified input value to be within the specified bounds.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <param name="lowerBound">The lower bound.</param>
    /// <param name="upperBound">The upper bound.</param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="lowerBound"/> is greater than <paramref name="upperBound"/>.
    /// </exception>
    public static void Clamp<T>(this ref T? input, T lowerBound, T upperBound)
        where T : struct, IComparable<T>
    {
        if (input is null)
            return;
        
        if (lowerBound.CompareTo(upperBound) > 0)
            throw new ArgumentException("The lower bound must be less than or equal to the upper bound.", nameof(lowerBound));

        if (input.Value.CompareTo(lowerBound) < 0)
            input = lowerBound;
        else if (input.Value.CompareTo(upperBound) > 0)
            input = upperBound;
    }
}