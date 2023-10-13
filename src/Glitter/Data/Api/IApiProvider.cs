namespace Glitter.Data.Api;

/// <summary>
/// Represents a provider for an API.
/// </summary>
public interface IApiProvider
    : IDataProvider
{
    /// <summary>
    /// Gets the specified resource.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>The response from the API.</returns>
    Task<TResponse> Get<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Posts the specified resource.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Post<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;
    
    /// <summary>
    /// Posts the specified resource.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>The response from the API.</returns>
    Task<TResponse> Post<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Patches the specified resource.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Patch<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;
    
    /// <summary>
    /// Patches the specified resource.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>The response from the API.</returns>
    Task<TResponse> Patch<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates or creates the specified resource.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Put<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;
    
    /// <summary>
    /// Updates or creates the specified resource.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>The response from the API.</returns>
    Task<TResponse> Put<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes the specified resource.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Delete<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;
    
    /// <summary>
    /// Deletes the specified resource.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>The response from the API.</returns>
    Task<TResponse> Delete<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}
