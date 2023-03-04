namespace Glitter.Net;

/// <summary>
/// Represents an <see cref="ApiRequest"/> utilizing <see cref="HttpMethod.Delete"/>.
/// </summary>
public class ApiDeleteRequest : ApiRequest
{
    /// <summary>
    /// Creates a new <see cref="ApiDeleteRequest"/> instance.
    /// </summary>
    /// <param name="uri">A <see cref="string"/> representing the <see cref="System.Uri"/> of the endpoint.</param>
    public ApiDeleteRequest(string uriString) :
        base(HttpMethod.Delete, uriString)
    { }
    /// <summary>
    /// Creates a new <see cref="ApiDeleteRequest"/> instance.
    /// </summary>
    /// <param name="uri">The <see cref="System.Uri"/> of the endpoint.</param>
    public ApiDeleteRequest(Uri uri) :
        base(HttpMethod.Delete, uri)
    { }
}