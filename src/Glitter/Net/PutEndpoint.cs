namespace Glitter.Net;

/// <summary>
/// Represents an <see cref="ApiEndpoint"/> utilizing <see cref="HttpMethod.Put"/>.
/// </summary>
public class PutEndpoint : ApiEndpoint
{
    /// <summary>
    /// Creates a new <see cref="PutEndpoint"/> instance.
    /// </summary>
    /// <param name="uri">A <see cref="string"/> representing the <see cref="System.Uri"/> of the endpoint.</param>
    public PutEndpoint(string uriString) :
        base(HttpMethod.Put, uriString)
    { }
    /// <summary>
    /// Creates a new <see cref="PutEndpoint"/> instance.
    /// </summary>
    /// <param name="uri">The <see cref="System.Uri"/> of the endpoint.</param>
    public PutEndpoint(Uri uri) :
        base(HttpMethod.Put, uri)
    { }
}