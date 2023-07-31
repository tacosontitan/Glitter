namespace Glitter.Text;

/// <summary>
/// Represents a highly flexible system for working with substrings.
/// </summary>
public sealed class SubstringQueue
{
    private readonly string _source;

    /// <summary>
    /// Initializes a new instance of the <see cref="SubstringQueue"/>.
    /// </summary>
    /// <param name="value">The string to be used as the source.</param>
    public SubstringQueue(string source)
    {
        _source = source;
        CurrentIndex = 0;
    }

    /// <summary>
    /// Gets the length of the source string.
    /// </summary>
    public int Length => _source.Length;

    /// <summary>
    /// Gets the current index of the <see cref="SubstringQueue"/>.
    /// </summary>
    public int CurrentIndex { get; private set; }

    /// <summary>
    /// Resets the current index to <c>0</c>.
    /// </summary>
    public void Reset() =>
        CurrentIndex = 0;
    
    /// <summary>
    /// Peeks ahead in the source string without advancing the current index.
    /// </summary>
    /// <param name="length">The length of the substring to peek at.</param>
    /// <returns>The substring that was peeked at.</returns>
    public string Peek(int length) =>
        _source.Substring(CurrentIndex, length);

    /// <summary>
    /// Peeks ahead in the source string without advancing the current index and parses it out as a specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type to parse the substring as.</typeparam>
    /// <param name="length">The length of the substring to peek at.</param>
    /// <returns>The parsed substring.</returns>
    public T Peek<T>(int length) =>
        (T)Convert.ChangeType(Peek(length), typeof(T));

    /// <summary>
    /// Attempts to peek ahead in the source string without advancing the current index.
    /// </summary>
    /// <param name="length">The length of the substring to peek at.</param>
    /// <param name="result">The substring that was peeked at.</param>
    /// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
    public bool TryPeek(int length, out string? result)
    {
        if (CurrentIndex + length > _source.Length)
        {
            result = null;
            return false;
        }

        result = _source.Substring(CurrentIndex, length);
        return true;
    }

    /// <summary>
    /// Attempts to peek ahead in the source string without advancing the current index and parses it out as a specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type to parse the substring as.</typeparam>
    /// <param name="length">The length of the substring to peek at.</param>
    /// <param name="result">The parsed substring.</param>
    /// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
    public bool TryPeek<T>(int length, out T? result)
    {
        if (CurrentIndex + length > _source.Length)
        {
            result = default;
            return false;
        }

        string substring = _source.Substring(CurrentIndex, length);
        result = (T)Convert.ChangeType(substring, typeof(T));
        return true;
    }

    /// <summary>
    /// Queries the next substring of a given length and parses it out as a specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type to parse the substring as.</typeparam>
    /// <param name="length">The length of the substring to query.</param>
    /// <param name="result">The parsed substring.</param>
    /// <returns>The <see cref="SubstringQueue"/> instance.</returns>
    public SubstringQueue Next<T>(int length, out T result)
    {
        string substring = _source.Substring(CurrentIndex, length);
        CurrentIndex += length;

        result = (T)Convert.ChangeType(substring, typeof(T));
        return this;
    }

    /// <summary>
    /// Queries the remaining substring and parses it out as a specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type to parse the substring as.</typeparam>
    /// <param name="result">The parsed substring.</param>
    public void Remainder<T>(out T result) =>
        Next(_source.Length - CurrentIndex, out result);
}
