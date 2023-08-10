namespace Glitter.Validation;

/// <summary>
/// Defines methods for providing basic validation.
/// </summary>
public interface IValidatable
{
    /// <summary>
    /// Validates the implementing instance.
    /// </summary>
    void Validate();

    /// <summary>
    /// Attempts to validate the implementing instance.
    /// </summary>
    /// <returns><see langword="true"/> if the validation was successful; otherwise, <see langword="false"/>.</returns>
    bool TryValidate();
}
