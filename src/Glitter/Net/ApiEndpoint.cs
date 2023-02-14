namespace Glitter.Net;

/// <summary>
/// Defines a request for interacting with an API endpoint.
/// </summary>
public class ApiEndpoint
{
    /// <summary>
    /// The <see cref="System.Uri"/> of the endpoint.
    /// </summary>
    public Uri Uri { get; private set; }
    /// <summary>
    /// The <see cref="HttpMethod"/> of the endpoint.
    /// </summary>
    public HttpMethod Method { get; private set; }
    /// <summary>
    /// Any query parameters for the endpoint.
    /// </summary>
    public Dictionary<string, object> QueryParameters { get; private set; }
    /// <summary>
    /// Any path parameters for the endpoint.
    /// </summary>
    public Dictionary<string, object> PathParameters { get; private set; }
    /// <summary>
    /// Creates a new <see cref="ApiEndpoint"/> instance.
    /// </summary>
    /// <param name="method">The <see cref="HttpMethod"/> of the endpoint.</param>
    /// <param name="uri">A <see cref="string"/> representing the <see cref="System.Uri"/> of the endpoint.</param>
    public ApiEndpoint(HttpMethod method, string uriString) :
        this(method, new Uri(uriString))
    { }
    /// <summary>
    /// Creates a new <see cref="ApiEndpoint"/> instance.
    /// </summary>
    /// <param name="method">The <see cref="HttpMethod"/> of the endpoint.</param>
    /// <param name="uri">The <see cref="System.Uri"/> of the endpoint.</param>
    public ApiEndpoint(HttpMethod method, Uri uri)
    {
        Uri = uri;
        Method = method;
        QueryParameters = new Dictionary<string, object>();
        PathParameters = new Dictionary<string, object>();
    }
    /// <summary>
    /// Adds a query parameter to the endpoint with the specified key and value.
    /// </summary>
    /// <param name="key">The key for the query parameter.</param>
    /// <param name="value">The value of the query parameter.</param>
    /// <typeparam name="T">Specifies the type of the query parameter's value.</typeparam>
    /// <returns>The current <see cref="ApiEndpoint"/> instance.</returns>
    /// <remarks>This method supports chaining.</remarks>
    /// <exception cref="ArgumentException"><paramref name="key"/> is <see langword="null"/>, whitespace, or has already been added to the endpoint.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
    public ApiEndpoint AddQueryParameter<T>(string key, T value)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException($"The specified key `{key}` is not valid.");

        if (QueryParameters.ContainsKey(key))
            throw new ArgumentException($"The specified key `{key}` has already been added.");

        if (value is null)
            throw new ArgumentNullException(nameof(value));

        QueryParameters.Add(key, value);
        return this;
    }
    /// <summary>
    /// Adds a path parameter to the endpoint with the specified key and value.
    /// </summary>
    /// <param name="key">The key for the path parameter.</param>
    /// <param name="value">The value of the path parameter.</param>
    /// <typeparam name="T">Specifies the type of the path parameter's value.</typeparam>
    /// <returns>The current <see cref="ApiEndpoint"/> instance.</returns>
    /// <remarks>This method supports chaining.</remarks>
    /// <exception cref="ArgumentException"><paramref name="key"/> is <see langword="null"/>, whitespace, or has already been added to the endpoint.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
    public ApiEndpoint AddPathParameter<T>(string key, T value)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException($"The specified key `{key}` is not valid.");

        if (PathParameters.ContainsKey(key))
            throw new ArgumentException($"The specified key `{key}` has already been added.");

        if (value is null)
            throw new ArgumentNullException(nameof(value));

        PathParameters.Add(key, value);
        return this;
    }
}