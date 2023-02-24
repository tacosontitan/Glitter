namespace Glitter;

/// <summary>
/// Represents an exception that is thrown when a resource is not found.
/// </summary>
public sealed class NotFoundException : Exception
{
    /// <summary>
    /// Gets additional information about the exception.
    /// </summary>
    public string? AdditionalInformation { get; }
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    public NotFoundException() : this(null) { }
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    /// <param name="addtionalInformation">Additional information about the exception.</param>
    public NotFoundException(string? addtionalInformation) :
        base("The requested resource was not found.") =>
        AdditionalInformation = addtionalInformation;
}