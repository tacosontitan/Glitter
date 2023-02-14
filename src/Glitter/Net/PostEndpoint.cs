namespace Glitter.Net;

/// <summary>
/// Represents an <see cref="ApiEndpoint"/> utilizing <see cref="HttpMethod.Post"/>.
/// </summary>
public class PostEndpoint : ApiEndpoint
{
    /// <summary>
    /// Creates a new <see cref="PostEndpoint"/> instance.
    /// </summary>
    /// <param name="uri">A <see cref="string"/> representing the <see cref="System.Uri"/> of the endpoint.</param>
    public PostEndpoint(string uriString) :
        base(HttpMethod.Post, uriString)
    { }
    /// <summary>
    /// Creates a new <see cref="PostEndpoint"/> instance.
    /// </summary>
    /// <param name="uri">The <see cref="System.Uri"/> of the endpoint.</param>
    public PostEndpoint(Uri uri) :
        base(HttpMethod.Post, uri)
    { }
}