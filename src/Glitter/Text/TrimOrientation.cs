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
    /// Indicates that trimming should be applied to the left side of the target.
    /// </summary>
    Left = 1,
    
    /// <summary>
    /// Indicates that trimming should be applied to the right side of the target.
    /// </summary>
    Right = 2
}
