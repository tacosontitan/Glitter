namespace Glitter.Net;

/// <summary>
/// Represents an <see cref="ApiEndpoint"/> utilizing <see cref="HttpMethod.Patch"/>.
/// </summary>
public class PatchEndpoint : ApiEndpoint
{
    /// <summary>
    /// Creates a new <see cref="PatchEndpoint"/> instance.
    /// </summary>
    /// <param name="uri">A <see cref="string"/> representing the <see cref="System.Uri"/> of the endpoint.</param>
    public PatchEndpoint(string uriString) :
        base(new HttpMethod("PATCH"), uriString)
    { }
    /// <summary>
    /// Creates a new <see cref="PatchEndpoint"/> instance.
    /// </summary>
    /// <param name="uri">The <see cref="System.Uri"/> of the endpoint.</param>
    public PatchEndpoint(Uri uri) :
        base(new HttpMethod("PATCH"), uri)
    { }
}