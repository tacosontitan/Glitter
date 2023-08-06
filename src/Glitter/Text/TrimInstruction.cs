namespace Glitter.Text;

/// <summary>
/// Represents instructions to be utilized when trimming strings.
/// </summary>
public class TrimInstruction
{
    /// <summary>
    /// Creates new trim instructions.
    /// </summary>
    /// <param name="orientation">The orientation of the trim.</param>
    /// <param name="values">The characters to trim.</param>
    public TrimInstruction(TrimOrientation orientation, params char[] values)
    {
        Orientation = orientation;
        Values = values;
    }

    public TrimOrientation Orientation { get; set; }
    
    /// <summary>
    /// Gets or sets the characters to trim.
    /// </summary>
    public IReadOnlyCollection<char>? Values { get; set; }
    
    /// <summary>
    /// Gets preconfigured instructions for trimming whitespace from the beginning and end of a string.
    /// </summary>
    public static TrimInstruction WhiteSpace =>
        new TrimInstruction(TrimOrientation.Full, values: new[] { ' ', '\t', '\r', '\n' });
}
