namespace Glitter.Patterns.Structural;

/// <summary>
/// Represents an adapter from one type to another.
/// </summary>
/// <typeparam name="TIn">The type of the input value.</typeparam>
/// <typeparam name="TOut">The type of the output value.</typeparam>
public interface IAdapter<in TIn, out TOut>
{
    /// <summary>
    /// Converts the specified input value to the specified output type.
    /// </summary>
    /// <param name="input">The input value to convert.</param>
    /// <returns>The converted value.</returns>
    TOut Convert(TIn input);
}