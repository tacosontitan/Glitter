namespace Glitter.Net;

/// <summary>
/// Represents an <see cref="ApiEndpoint"/> utilizing <see cref="HttpMethod.Delete"/>.
/// </summary>
public class DeleteEndpoint : ApiEndpoint
{
    /// <summary>
    /// Creates a new <see cref="DeleteEndpoint"/> instance.
    /// </summary>
    /// <param name="uri">A <see cref="string"/> representing the <see cref="System.Uri"/> of the endpoint.</param>
    public DeleteEndpoint(string uriString) :
        base(HttpMethod.Delete, uriString)
    { }
    /// <summary>
    /// Creates a new <see cref="DeleteEndpoint"/> instance.
    /// </summary>
    /// <param name="uri">The <see cref="System.Uri"/> of the endpoint.</param>
    public DeleteEndpoint(Uri uri) :
        base(HttpMethod.Delete, uri)
    { }
}