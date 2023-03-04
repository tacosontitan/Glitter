namespace Glitter.Net;

/// <summary>
/// Represents an <see cref="ApiRequest"/> utilizing <see cref="HttpMethod.Post"/>.
/// </summary>
public class ApiPostRequest : ApiRequest
{
    /// <summary>
    /// Creates a new <see cref="ApiPostRequest"/> instance.
    /// </summary>
    /// <param name="uri">A <see cref="string"/> representing the <see cref="System.Uri"/> of the endpoint.</param>
    public ApiPostRequest(string uriString) :
        base(HttpMethod.Post, uriString)
    { }
    /// <summary>
    /// Creates a new <see cref="ApiPostRequest"/> instance.
    /// </summary>
    /// <param name="uri">The <see cref="System.Uri"/> of the endpoint.</param>
    public ApiPostRequest(Uri uri) :
        base(HttpMethod.Post, uri)
    { }
}