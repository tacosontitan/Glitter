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
    public int CurrentIndex => _currentIndex.Value;

    /// <summary>
    /// Resets the current index to <c>0</c>.
    /// </summary>
    public void Reset() =>
        _currentIndex.Value = 0;
}