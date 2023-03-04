namespace Glitter.Net;

/// <summary>
/// Represents an <see cref="ApiRequest"/> utilizing <see cref="HttpMethod.Put"/>.
/// </summary>
public class ApiPutRequest : ApiRequest
{
    /// <summary>
    /// Creates a new <see cref="ApiPutRequest"/> instance.
    /// </summary>
    /// <param name="uri">A <see cref="string"/> representing the <see cref="System.Uri"/> of the endpoint.</param>
    public ApiPutRequest(string uriString) :
        base(HttpMethod.Put, uriString)
    { }
    /// <summary>
    /// Creates a new <see cref="ApiPutRequest"/> instance.
    /// </summary>
    /// <param name="uri">The <see cref="System.Uri"/> of the endpoint.</param>
    public ApiPutRequest(Uri uri) :
        base(HttpMethod.Put, uri)
    { }
}