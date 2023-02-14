namespace Glitter.Net;

/// <summary>
/// Represents an <see cref="ApiEndpoint"/> utilizing <see cref="HttpMethod.Get"/>.
/// </summary>
public class GetEndpoint : ApiEndpoint
{
    /// <summary>
    /// Creates a new <see cref="ApiEndpoint"/> instance.
    /// </summary>
    /// <param name="uri">A <see cref="string"/> representing the <see cref="System.Uri"/> of the endpoint.</param>
    public GetEndpoint(string uriString) :
        base(HttpMethod.Get, uriString)
    { }
    /// <summary>
    /// Creates a new <see cref="ApiEndpoint"/> instance.
    /// </summary>
    /// <param name="uri">The <see cref="System.Uri"/> of the endpoint.</param>
    public GetEndpoint(Uri uri) :
        base(HttpMethod.Get, uri)
    { }
}