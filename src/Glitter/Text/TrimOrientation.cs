namespace Glitter.Text;

/// <summary>
/// Represents the orientation that should be used during trimming.
/// </summary>
public enum TrimOrientation
{
    /// <summary>
    /// Indicates that trimming should be applied to both sides of the target.
    /// </summary>
    Full = 0,
    
    /// <summary>
    /// Indicates that trimming should be applied to the start of the target.
    /// </summary>
    Start = 1,
    
    /// <summary>
    /// Indicates that trimming should be applied to the end of the target.
    /// </summary>
    End = 2
}
