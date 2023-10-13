namespace Glitter.Data.Io;

/// <summary>
/// Represents a file.
/// </summary>
public interface IFile
{
    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    string Name { get; set; }
    
    /// <summary>
    /// Gets or sets the extension of the file.
    /// </summary>
    string Extension { get; set; }
    
    /// <summary>
    /// Gets or sets the content of the file.
    /// </summary>
    IEnumerable<byte> Content { get; set; }
}
