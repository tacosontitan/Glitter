using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Glitter.Text;

/// <summary>
/// Represents a highly flexible system for working with substrings.
/// </summary>
public sealed class SubstringReader
{
    private readonly string _source;
    private readonly Clamped<int> _currentIndex;
    private readonly SubstringReaderOptions _options;

    /// <summary>
    /// Creates a new <see cref="SubstringReader"/> with the specified source.
    /// </summary>
    /// <param name="source">The string to be used as the source.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> is <see langword="null"/>, empty, or whitespace.</exception>
    public SubstringReader(string source) :
        this(source, new SubstringReaderOptions())
    { }

    /// <summary>
    /// Creates a new <see cref="SubstringReader"/> with the specified source and options.
    /// </summary>
    /// <param name="source">The string to be used as the source.</param>
    /// <param name="options">The options to be used for the <see cref="SubstringReader"/>.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> is <see langword="null"/>, empty, or whitespace.</exception>
    public SubstringReader(string source, SubstringReaderOptions options)
    {
        if (string.IsNullOrWhiteSpace(source))
            throw new ArgumentException("The source string cannot be null, empty, or whitespace.", nameof(source));

        _source = source;
        _options = options;
        _currentIndex = new Clamped<int>(value: 0, lowerBound: 0, upperBound: source.Length);
    }

    /// <summary>
    /// Gets the current length of the <see cref="SubstringReader"/>.
    /// </summary>
    public int Length =>
        _source.Length - _currentIndex.Value;

    /// <summary>
    /// Gets the current index of the <see cref="SubstringReader"/>.
    /// </summary>
    public int CurrentIndex => _currentIndex.Value;

    /// <summary>
    /// Resets the current index to <c>0</c>.
    /// </summary>
    public void Reset() =>
        _currentIndex.Value = 0;

    /// <summary>
    /// Peeks ahead in the source string without advancing the current index.
    /// </summary>
    /// <returns><see langword="null"/> if the reader is at the end of the source string; otherwise, the substring that was peeked at.</returns>
    public string? Peek() =>
        _currentIndex.Value < _source.Length
            ? _source.Substring(_currentIndex.Value)
            : null;

    /// <summary>
    /// Peeks ahead in the source string without advancing the current index.
    /// </summary>
    /// <param name="length">The length of the substring to peek at.</param>
    /// <returns>The substring that was peeked at.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="length"/> is less than <c>0</c> or
    /// greater than the length of the source string when added to the current index of the reader.
    /// </exception>
    public string Peek(int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), length, "The specified length cannot be less than zero.");

        if (_currentIndex.Value + length > _source.Length)
            throw new ArgumentOutOfRangeException(nameof(length), length, "The specified length cannot exceed the length of the source string when added to the current index of the reader.");

        return _source.Substring(_currentIndex.Value, length);
    }

    /// <summary>
    /// Peeks ahead in the source string without advancing the current index and parses it out as a specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type to parse the substring as.</typeparam>
    /// <param name="length">The length of the substring to peek at.</param>
    /// <returns>The parsed substring.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="length"/> is less than <c>0</c> or
    /// greater than the length of the source string when added to the current index of the reader.
    /// </exception>
    public T? Peek<T>(int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), length, "The specified length cannot be less than zero.");

        if (_currentIndex.Value + length > _source.Length)
            throw new ArgumentOutOfRangeException(nameof(length), length, "The specified length cannot exceed the length of the source string when added to the current index of the reader.");

        string substring = _source.Substring(_currentIndex.Value, length);
        if (substring.Length < 1)
            return default;

        object result = Convert.ChangeType(value: substring, typeof(T));
        return (T?)result;
    }

    /// <summary>
    /// Attempts to peek ahead in the source string without advancing the current index.
    /// </summary>
    /// <param name="length">The length of the substring to peek at.</param>
    /// <param name="result">The substring that was peeked at.</param>
    /// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
    public bool TryPeek(int length, out string? result)
    {
        if (length < 0)
        {
            result = null;
            return false;
        }

        if (_currentIndex.Value + length > _source.Length)
        {
            result = null;
            return false;
        }

        result = _source.Substring(_currentIndex.Value, length);
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
        if (length < 0)
        {
            result = default;
            return false;
        }
        
        if (_currentIndex.Value + length > _source.Length)
        {
            result = default;
            return false;
        }

        try
        {
            string substring = _source.Substring(_currentIndex.Value, length);
            result = (T)Convert.ChangeType(substring, typeof(T));
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }

    /// <summary>
    /// Queries the next substring of a given length and parses it out as a specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type to parse the substring as.</typeparam>
    /// <param name="length">The length of the substring to query.</param>
    /// <param name="result">The parsed substring.</param>
    /// <param name="trim">Whether or not to trim the substring before parsing.</param>
    /// <returns>The current <see cref="SubstringReader"/> instance.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="length"/> is less than <c>0</c> or
    /// greater than the length of the source string when added to the current index of the reader.
    /// </exception>
    public SubstringReader Next<T>(int length, out T? result, bool trim = true)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), length, "The specified length cannot be less than zero.");
        
        if (_currentIndex.Value + length > _source.Length)
            throw new ArgumentOutOfRangeException(nameof(length), length, "The specified length cannot exceed the length of the source string when added to the current index of the reader.");

        string substring = _source.Substring(_currentIndex.Value, length);
        if (trim)
            substring = substring.Trim();

        result = (T)Convert.ChangeType(substring, typeof(T));
        _currentIndex.Value += length;
        return this;
    }

    /// <summary>
    /// Queries the next substring of length <c>1</c> and parses it out as a specified type.
    /// </summary>
    /// <param name="length">The length of the substring to query.</param>
    /// <returns>The current <see cref="SubstringReader"/> instance.</returns>
    public SubstringReader Next<T>(out T? result) =>
        Next(length: 1, out result);

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
        int index = _source.IndexOf(searchValue, _currentIndex.Value);
        if (index == -1)
        {
            result = default;
            return this;
        }

        string substring = _source.Substring(_currentIndex.Value, index - _currentIndex.Value);
        if (trim)
            substring = substring.Trim();

        result = (T)Convert.ChangeType(substring, typeof(T));
        _currentIndex.Value = index;
        return this;
    }

    /// <summary>
    /// Queries the remaining substring and parses it out as a specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type to parse the substring as.</typeparam>
    /// <param name="result">The parsed substring.</param>
    public void Remainder<T>(out T? result) =>
        Next(length: _source.Length - _currentIndex.Value, out result);
}