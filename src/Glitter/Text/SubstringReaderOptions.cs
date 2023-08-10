using System.Globalization;

namespace Glitter.Text;

/// <summary>
/// Represents options for a <see cref="SubstringReader"/>.
/// </summary>
public class SubstringReaderOptions
{
    /// <summary>
    /// Creates new options for a <see cref="SubstringReader"/>.
    /// </summary>
    public SubstringReaderOptions()
    {
        FormatProvider = CultureInfo.InvariantCulture;
        TrimInstructions = null;
    }

    /// <summary>
    /// Gets or sets the format provider for the <see cref="SubstringReader"/>.
    /// </summary>
    public IFormatProvider? FormatProvider { get; set; }

    /// <summary>
    /// Gets or sets the trimming options for the <see cref="SubstringReader"/>.
    /// </summary>
    public IEnumerable<TrimInstruction>? TrimInstructions { get; set; }
}