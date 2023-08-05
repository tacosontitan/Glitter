namespace Glitter.Text;

/// <summary>
/// Represents options for configuring how trimming is performed.
/// </summary>
public class TrimOptions
{
    /// <summary>
    /// Creates new trim options.
    /// </summary>
    public TrimOptions()
    {
        LeftCharacters = null;
        RightCharacters = null;
    }
    
    /// <summary>
    /// Creates new trim options.
    /// </summary>
    /// <param name="characters">The characters to trim from the left and right.</param>
    public TrimOptions(params char[] characters)
    {
        LeftCharacters = characters;
        RightCharacters = characters;
    }

    /// <summary>
    /// Creates new trim options.
    /// </summary>
    /// <param name="leftCharacters">The characters to trim from the left.</param>
    /// <param name="rightCharacters">The characters to trim from the right.</param>
    public TrimOptions(IEnumerable<char>? leftCharacters, IEnumerable<char>? rightCharacters)
    {
        LeftCharacters = leftCharacters;
        RightCharacters = rightCharacters;
    }
    
    /// <summary>
    /// Gets preconfigured options for trimming whitespace from the beginning and end of a string.
    /// </summary>
    public static TrimOptions WhiteSpace =>
        new TrimOptions(characters: new[] { ' ', '\t', '\r', '\n' });
    
    /// <summary>
    /// Gets or sets the characters to trim from the left.
    /// </summary>
    public IEnumerable<char>? LeftCharacters { get; set; }
    
    /// <summary>
    /// Gets or sets the characters to trim from the right.
    /// </summary>
    public IEnumerable<char>? RightCharacters { get; set; }
}
