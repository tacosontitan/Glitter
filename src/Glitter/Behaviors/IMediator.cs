namespace Glitter.Behaviors;

/// <summary>
/// Represents a mediator.
/// </summary>
public interface IMediator
{
    /// <summary>
    /// Sends the specified request.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to send.</param>
    /// <param name="cancellationToken">A cancellation token to support cancellation of the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Send<TRequest>(IRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;
    
    /// <summary>
    /// Sends the specified request.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to send.</param>
    /// <param name="cancellationToken">A cancellation token to support cancellation of the request.</param>
    /// <returns>The result of the request.</returns>
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}
