namespace Glitter.Net;

/// <summary>
/// Defines a request for interacting with an API endpoint.
/// </summary>
public class ApiRequest
{
    /// <summary>
    /// The <see cref="ApiEndpoint"/> the request is for.
    /// </summary>
    public ApiEndpoint Endpoint { get; private set; }
    /// <summary>
    /// Any headers for the endpoint that are specific to the request.
    /// </summary>
    public Dictionary<string, object> Headers { get; private set; }
    /// <summary>
    /// The body for the request to the endpoint.
    /// </summary>
    public object? Body { get; private set; }
    /// <summary>
    /// Creates a new <see cref="ApiRequest"/> instance.
    /// </summary>
    /// <param name="endpoint">The <see cref="ApiEndpoint"/> the request is for.</param>
    public ApiRequest(ApiEndpoint endpoint)
    {
        Endpoint = endpoint;
        Headers = new Dictionary<string, object>();
    }
        /// <summary>
    /// Adds a header to the request with the specified key and value.
    /// </summary>
    /// <param name="key">The key for the header.</param>
    /// <param name="value">The value of the header.</param>
    /// <typeparam name="T">Specifies the type of the header's value.</typeparam>
    /// <returns>The current <see cref="ApiRequest"/> instance.</returns>
    /// <remarks>This method supports chaining.</remarks>
    /// <exception cref="ArgumentException"><paramref name="key"/> is <see langword="null"/>, whitespace, or has already been added to the request.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
    public ApiRequest AddHeader<T>(string key, T? value)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException($"The specified key `{key}` is not valid.");

        if (Headers.ContainsKey(key))
            throw new ArgumentException($"The specified key `{key}` has already been added.");

        if (value is null)
            throw new ArgumentNullException(nameof(value));

        Headers.Add(key, value);
        return this;
    }
}