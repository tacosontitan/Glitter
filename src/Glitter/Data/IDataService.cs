namespace Glitter.Data;

/// <summary>
/// Represents a service for working with data oriented requests.
/// </summary>
public interface IDataService
{
    /// <summary>
    /// Executes the specified request.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to execute.</param>
    /// <param name="cancellationToken">A cancellation token to support cancellation of the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Execute<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;
    
    /// <summary>
    /// Executes the specified request.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to execute.</param>
    /// <param name="cancellationToken">A cancellation token to support cancellation of the request.</param>
    /// <returns>The result of the request.</returns>
    Task<TResponse> Execute<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}
