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
    Task<TResponse> ExecuteGet<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Posts the specified resource.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ExecutePost<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;
    
    /// <summary>
    /// Posts the specified resource.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>The response from the API.</returns>
    Task<TResponse> ExecutePost<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Patches the specified resource.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ExecutePatch<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;
    
    /// <summary>
    /// Patches the specified resource.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>The response from the API.</returns>
    Task<TResponse> ExecutePatch<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates or creates the specified resource.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ExecutePut<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;
    
    /// <summary>
    /// Updates or creates the specified resource.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>The response from the API.</returns>
    Task<TResponse> ExecutePut<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes the specified resource.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ExecuteDelete<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;
    
    /// <summary>
    /// Deletes the specified resource.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to send to the API.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the request.</param>
    /// <returns>The response from the API.</returns>
    Task<TResponse> ExecuteDelete<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}
