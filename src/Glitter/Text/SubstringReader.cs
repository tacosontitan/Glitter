namespace Glitter.Text;

/// <summary>
/// Represents a highly flexible system for working with substrings.
/// </summary>
public sealed class SubstringReader
{
    private readonly string _source;

    /// <summary>
    /// Initializes a new instance of the <see cref="SubstringReader"/>.
    /// </summary>
    /// <param name="value">The string to be used as the source.</param>
    public SubstringReader(string source)
    {
        _source = source;
        CurrentIndex = 0;
    }

    /// <summary>
    /// Gets the current length of the <see cref="SubstringReader"/>.
    /// </summary>
    public int Length =>
        _source.Length - CurrentIndex;

    /// <summary>
    /// Gets the current index of the <see cref="SubstringReader"/>.
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
    /// <returns>The substring that was peeked at.</returns>
    public string Peek() =>
        _source.Substring(CurrentIndex);

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
    /// <returns>The current <see cref="SubstringReader"/> instance.</returns>
    public SubstringReader Next<T>(int length, out T? result, bool trim = true)
    {
        string substring = _source.Substring(CurrentIndex, length);
        if (trim)
            substring = substring.Trim();

        result = (T)Convert.ChangeType(substring, typeof(T));
        CurrentIndex += length;
        return this;
    }

    /// <summary>
    /// Queries the next substring of length <c>1</c> and parses it out as a specified type.
    /// </summary>
    /// <param name="length">The length of the substring to query.</param>
    /// <returns>The current <see cref="SubstringReader"/> instance.</returns>
    public SubstringReader Next<T>(out T? result) =>
        Next(1, out result);

    /// <summary>
    /// Takes from the current index to the next occurrence of a specified search value and parses it out as a specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type to parse the substring as.</typeparam>
    /// <param name="searchValue">The character to search for.</param>
    /// <param name="result">The parsed substring.</param>
    /// <param name="trim">Whether or not to trim the substring prior to parsing.</param>
    /// <returns>The <see cref="SubstringReader"/> instance.</returns>
    /// <remarks>This method will trim the substring prior to parsing by default.</remarks>
    public SubstringReader TakeTo<T>(char searchValue, out T? result, bool trim = true) =>
        TakeTo(searchValue.ToString(), out result, trim);

    /// <summary>
    /// Takes from the current index to the next occurrence of a specified search value and parses it out as a specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type to parse the substring as.</typeparam>
    /// <param name="searchValue">The value to search for.</param>
    /// <param name="result">The parsed substring.</param>
    /// <param name="trim">Whether or not to trim the substring prior to parsing.</param>
    /// <returns>The <see cref="SubstringReader"/> instance.</returns>
    /// <remarks>This method will trim the substring prior to parsing by default.</remarks>
    public SubstringReader TakeTo<T>(string searchValue, out T? result, bool trim = true)
    {
        int index = _source.IndexOf(searchValue, CurrentIndex);
        if (index == -1)
        {
            result = default;
            return this;
        }

        string substring = _source.Substring(CurrentIndex, index - CurrentIndex);
        if (trim)
            substring = substring.Trim();

        result = (T)Convert.ChangeType(substring, typeof(T));
        CurrentIndex = index;
        return this;
    }

    /// <summary>
    /// Queries the remaining substring and parses it out as a specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type to parse the substring as.</typeparam>
    /// <param name="result">The parsed substring.</param>
    public void Remainder<T>(out T? result) =>
        Next(_source.Length - CurrentIndex, out result);
}
