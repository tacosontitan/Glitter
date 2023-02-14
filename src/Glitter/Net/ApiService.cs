namespace Glitter.Net;

/// <summary>
/// Represents a service for interacting with an API.
/// </summary>
public abstract class ApiService
{
    /// <summary>
    /// Sends the specified <see cref="ApiRequest"/>.
    /// </summary>
    /// <param name="request">The <see cref="ApiRequest"/> to send.</param>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public abstract Task Send(ApiRequest request);
    /// <summary>
    /// Sends the specified <see cref="ApiRequest"/> with an expectation to receive data from the API.
    /// </summary>
    /// <param name="request">The <see cref="ApiRequest"/> to send.</param>
    /// <typeparam name="T">Specifies the type of data expected in the response.</typeparam>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public abstract Task<T> Send<T>(ApiRequest request);
}
