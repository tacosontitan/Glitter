namespace Glitter.Net;

/// <summary>
/// Represents an <see cref="ApiRequest"/> utilizing <see cref="HttpMethod.Patch"/>.
/// </summary>
public class ApiPatchRequest : ApiRequest
{
    /// <summary>
    /// Creates a new <see cref="ApiPatchRequest"/> instance.
    /// </summary>
    /// <param name="uri">A <see cref="string"/> representing the <see cref="System.Uri"/> of the endpoint.</param>
    public ApiPatchRequest(string uriString) :
        base(new HttpMethod("PATCH"), uriString)
    { }
    /// <summary>
    /// Creates a new <see cref="ApiPatchRequest"/> instance.
    /// </summary>
    /// <param name="uri">The <see cref="System.Uri"/> of the endpoint.</param>
    public ApiPatchRequest(Uri uri) :
        base(new HttpMethod("PATCH"), uri)
    { }
}