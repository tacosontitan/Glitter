namespace Glitter;

/// <summary>
/// Represents an exception that is thrown when a resource is not found.
/// </summary>
public sealed class NotFoundException
    : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    public NotFoundException()
        : this(additionalInformation: null)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    /// <param name="additionalInformation">Additional information about the exception.</param>
    public NotFoundException(string? additionalInformation) :
        base(message: "The requested resource was not found.") =>
        AdditionalInformation = additionalInformation;

    /// <summary>
    /// Gets additional information about the exception.
    /// </summary>
    public string? AdditionalInformation { get; }
}
