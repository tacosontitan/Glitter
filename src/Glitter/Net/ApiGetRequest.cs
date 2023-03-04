namespace Glitter.Net;

/// <summary>
/// Represents an <see cref="ApiRequest"/> utilizing <see cref="HttpMethod.Get"/>.
/// </summary>
public class GetRequest : ApiRequest
{
    /// <summary>
    /// Creates a new <see cref="GetRequest"/> instance.
    /// </summary>
    /// <param name="uri">A <see cref="string"/> representing the <see cref="System.Uri"/> of the endpoint.</param>
    public GetRequest(string uriString) :
        base(HttpMethod.Get, uriString)
    { }
    /// <summary>
    /// Creates a new <see cref="GetRequest"/> instance.
    /// </summary>
    /// <param name="uri">The <see cref="System.Uri"/> of the endpoint.</param>
    public GetRequest(Uri uri) :
        base(HttpMethod.Get, uri)
    { }
}