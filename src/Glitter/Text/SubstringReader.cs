using Glitter.Serialization;

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
    /// Creates a new <see cref="SubstringReader"/> with the specified source and options.
    /// </summary>
    /// <param name="source">The string to be used as the source.</param>
    /// <param name="options">The options to be used for the <see cref="SubstringReader"/>.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> is <see langword="null"/>, empty, or whitespace.</exception>
    public SubstringReader(string source, SubstringReaderOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(source))
            throw new ArgumentException("The source string cannot be null, empty, or whitespace.", nameof(source));

        _source = source;
        _options = options ?? new SubstringReaderOptions();
        _currentIndex = new Clamped<int>(
            value: 0,
            lowerBound: 0,
            upperBound: source.Length);
    }

    /// <summary>
    /// Gets the current length of the <see cref="SubstringReader"/>.
    /// </summary>
    public int Length =>
        _source.Length - _currentIndex.Value;

    /// <summary>
    /// Gets the current index of the <see cref="SubstringReader"/>.
    /// </summary>
    public int Position =>
        _currentIndex.Value;

    /// <summary>
    /// Resets the current index to <c>0</c>.
    /// </summary>
    public void Reset() =>
        _currentIndex.Value = 0;

    /// <summary>
    /// Peeks forward to the end of the source string.
    /// </summary>
    /// <returns><see langword="null"/> if the current index beyond the end of the source string; otherwise, the substring from the current position of the reader to the end of the source string.</returns>
    public string? Peek() =>
        GetSubstring();

    /// <summary>
    /// Peeks forward to the end of the source string and attempts to convert the substring to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the substring to.</typeparam>
    /// <exception cref="FormatException">The resulting substring is not in the correct format for <typeparamref name="T"/>.</exception>
    /// <exception cref="OverflowException">The resulting substring exceeds the range of <typeparamref name="T"/>.</exception>
    public T? Peek<T>() where T : IConvertible
    {
        string substring = GetSubstring();
        return (T)Convert.ChangeType(substring, typeof(T), _options.FormatProvider);
    }
    
    /// <summary>
    /// Peeks forward in the specified source string by the specified length and attempts to deserialize the substring to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the substring to.</typeparam>
    /// <param name="serializationProvider">The serialization provider to use for deserialization.</param>
    public T? Peek<T>(ISerializationProvider serializationProvider)
    {
        if (serializationProvider is null)
            throw new ArgumentNullException(nameof(serializationProvider));
        
        string substring = GetSubstring();
        return serializationProvider.Deserialize<T>(substring, _options.FormatProvider);
    }

    /// <summary>
    /// Peeks forward in the specified source string by the specified length.
    /// </summary>
    /// <param name="length">The length to peek forward.</param>
    /// <returns>The substring from the current position of the reader to the end of the source string.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="length"/> is negative or exceeds the length of the source string when added to the current position of the reader.</exception>
    public string? Peek(int length) =>
        GetSubstring(length);

    /// <summary>
    /// Peeks forward in the specified source string by the specified length and attempts to convert the substring to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the substring to.</typeparam>
    /// <param name="length">The length to peek forward.</param>
    /// <returns>The substring from the current position of the reader to the end of the source string.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="length"/> is negative or exceeds the length of the source string when added to the current position of the reader.</exception>
    /// <exception cref="FormatException">The resulting substring is not in the correct format for <typeparamref name="T"/>.</exception>
    /// <exception cref="OverflowException">The resulting substring exceeds the range of <typeparamref name="T"/>.</exception>
    public T? Peek<T>(int length) where T : IConvertible
    {
        string substring = GetSubstring(length);
        return (T)Convert.ChangeType(substring, typeof(T), _options.FormatProvider);
    }

    /// <summary>
    /// Peeks forward in the specified source string by the specified length and attempts to deserialize the substring to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the substring to.</typeparam>
    /// <param name="length">The length to peek forward.</param>
    /// <param name="serializationProvider">The serialization provider to use for deserialization of this particular peek invocation.</param>
    /// <returns>The substring from the current position of the reader to the end of the source string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="serializationProvider"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="length"/> is negative or exceeds the length of the source string when added to the current position of the reader.</exception>
    public T? Peek<T>(int length, ISerializationProvider serializationProvider)
    {
        if (serializationProvider is null)
            throw new ArgumentNullException(nameof(serializationProvider));
        
        string substring = GetSubstring(length);
        return serializationProvider.Deserialize<T>(substring, _options.FormatProvider);
    }
    
    /// <summary>
    /// Attempts to peek forward to the end of the source string.
    /// </summary>
    /// <param name="result">The substring from the current position of the reader to the end of the source string.</param>
    /// <returns><see langword="true"/> if the current index is not beyond the end of the source string; otherwise, <see langword="false"/>.</returns>
    public bool TryPeek(out string? result)
    {
        try
        {
            result = Peek();
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }
    
    /// <summary>
    /// Attempts to peek forward to the end of the source string and convert the substring to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the substring to.</typeparam>
    /// <param name="result">The substring from the current position of the reader to the end of the source string.</param>
    /// <returns><see langword="true"/> if the current index is not beyond the end of the source string; otherwise, <see langword="false"/>.</returns>
    public bool TryPeek<T>(out T? result) where T : IConvertible
    {
        try
        {
            result = Peek<T>();
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }
    
    /// <summary>
    /// Attempts to peek forward to the end of the source string and deserialize the substring to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the substring to.</typeparam>
    /// <param name="serializationProvider">The serialization provider to use for deserialization.</param>
    /// <param name="result">The substring from the current position of the reader to the end of the source string.</param>
    /// <returns><see langword="true"/> if the current index is not beyond the end of the source string; otherwise, <see langword="false"/>.</returns>
    public bool TryPeek<T>(ISerializationProvider serializationProvider, out T? result)
    {
        try
        {
            result = Peek<T>(serializationProvider);
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }
    
    /// <summary>
    /// Attempts to peek forward in the specified source string by the specified length.
    /// </summary>
    /// <param name="length">The length to peek forward.</param>
    /// <param name="result">The substring from the current position of the reader to the end of the source string.</param>
    /// <returns><see langword="true"/> if the current index is not beyond the end of the source string; otherwise, <see langword="false"/>.</returns>
    public bool TryPeek(int length, out string? result)
    {
        try
        {
            result = Peek(length);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }
    
    /// <summary>
    /// Attempts to peek forward in the specified source string by the specified length and convert the substring to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the substring to.</typeparam>
    /// <param name="length">The length to peek forward.</param>
    /// <param name="result">The substring from the current position of the reader to the end of the source string.</param>
    /// <returns><see langword="true"/> if the current index is not beyond the end of the source string; otherwise, <see langword="false"/>.</returns>
    public bool TryPeek<T>(int length, out T? result) where T : IConvertible
    {
        try
        {
            result = Peek<T>(length);
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }
    
    /// <summary>
    /// Attempts to peek forward in the specified source string by the specified length and deserialize the substring to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the substring to.</typeparam>
    /// <param name="length">The length to peek forward.</param>
    /// <param name="serializationProvider">The serialization provider to use for deserialization.</param>
    /// <param name="result">The substring from the current position of the reader to the end of the source string.</param>
    /// <returns><see langword="true"/> if the current index is not beyond the end of the source string; otherwise, <see langword="false"/>.</returns>
    public bool TryPeek<T>(int length, ISerializationProvider serializationProvider, out T? result)
    {
        try
        {
            result = Peek<T>(length, serializationProvider);
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }
    
    /// <summary>
    /// Skips the next character in the source string.
    /// </summary>
    /// <returns>The current <see cref="SubstringReader"/> instance.</returns>
    public SubstringReader Skip() =>
        Seek(length: 1);
    
    /// <summary>
    /// Skips all characters in the source string until the specified character is found.
    /// </summary>
    /// <param name="searchValue">The character to search for.</param>
    /// <param name="skipSearchValue">Whether to skip the specified character if found.</param>
    /// <returns>The current <see cref="SubstringReader"/> instance.</returns>
    /// <remarks>If the specified character is not found, the reader will not advance.</remarks>
    public SubstringReader SkipTo(char searchValue, bool skipSearchValue = false)
    {
        int searchValueIndex = _source.IndexOf(searchValue, _currentIndex.Value);
        if (searchValueIndex == -1)
            return this;
        
        int offset = skipSearchValue ? 1 : 0;
        return Seek(length: searchValueIndex - _currentIndex.Value + offset);
    }
    
    /// <summary>
    /// Skips the specified number of characters in the source string.
    /// </summary>
    /// <param name="length">The number of characters to skip.</param>
    /// <returns>The current <see cref="SubstringReader"/> instance.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> cannot cause the reader to step outside of the source string.</exception>
    public SubstringReader Seek(int length)
    {
        if (_currentIndex.Value + length > _source.Length)
            throw new ArgumentOutOfRangeException(nameof(length), length, "The length cannot cause the reader to step outside of the source string.");
        
        if (_currentIndex.Value + length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), length, "The length cannot cause the reader to step outside of the source string.");

        _currentIndex.Value += length;
        return this;
    }

    /// <summary>
    /// Reads the specified number of characters from the source string and attempts to parse the substring to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to parse the substring to.</typeparam>
    /// <param name="length">The number of characters to read.</param>
    /// <param name="result">The substring from the current position of the reader to the end of the source string.</param>
    /// <returns>The current <see cref="SubstringReader"/> instance.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> cannot cause the reader to step outside of the source string.</exception>
    /// <exception cref="FormatException">The substring cannot be parsed to the specified type.</exception>
    /// <exception cref="OverflowException">The substring cannot be parsed to the specified type.</exception>
    public SubstringReader Read<T>(int length, out T? result) where T : IConvertible
    {
        string substring = GetSubstring(length);
        result = (T)Convert.ChangeType(substring, typeof(T), _options.FormatProvider);
        _currentIndex.Value += length;
        return this;
    }
    
    /// <summary>
    /// Reads the specified number of characters from the source string and attempts to deserialize the substring to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the substring to.</typeparam>
    /// <param name="length">The number of characters to read.</param>
    /// <param name="serializationProvider">The serialization provider to use for deserialization.</param>
    /// <param name="result">The substring from the current position of the reader to the end of the source string.</param>
    /// <returns>The current <see cref="SubstringReader"/> instance.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> cannot cause the reader to step outside of the source string.</exception>
    public SubstringReader Read<T>(int length, ISerializationProvider serializationProvider, out T? result)
    {
        string substring = GetSubstring(length);
        result = serializationProvider.Deserialize<T>(substring, _options.FormatProvider);
        _currentIndex.Value += length;
        return this;
    }

    private string GetSubstring() =>
        GetSubstring(length: _source.Length - _currentIndex.Value);
    
    private string GetSubstring(int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), length, "The length cannot be negative.");
        
        if (_currentIndex.Value + length > _source.Length)
            throw new ArgumentOutOfRangeException(nameof(length), length, "The length cannot exceed the length of the source string.");

        string substring = _source.Substring(_currentIndex.Value, length);
        return Trim(substring);
    }

    private string Trim(string source)
    {
        if (_options.TrimInstructions?.Any() != true)
            return source;
        
        string ApplyTrimInstruction(string input, TrimInstruction instruction) =>
            instruction.Orientation switch
            {
                TrimOrientation.Start => input.TrimStart(instruction.Values.ToArray()),
                TrimOrientation.End => input.TrimEnd(instruction.Values.ToArray()),
                TrimOrientation.Full => input.Trim(instruction.Values.ToArray()),
                _ => throw new ArgumentOutOfRangeException(nameof(instruction), instruction, "The trim orientation is not supported.")
            };

        return _options.TrimInstructions.Aggregate(source, ApplyTrimInstruction);
    }

    /*
     * Read
     * ReadTo
     * ReadToEnd
     */
}