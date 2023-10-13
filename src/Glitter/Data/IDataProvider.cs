namespace Glitter.Data;

/// <summary>
/// Represents a data provider.
/// </summary>
public interface IDataProvider
{    
    /// <summary>
    /// Executes the specified request.
    /// </summary>
    /// <param name="request">The request to execute.</param>
    /// <param name="cancellationToken">A cancellation token to support cancellation of the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Execute(IRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Executes the specified request.
    /// </summary>
    /// <param name="request">The request to execute.</param>
    /// <param name="cancellationToken">A cancellation token to support cancellation of the request.</param>
    /// <returns>The result of the request.</returns>
    Task<TOut> Execute<TOut>(IRequest<TOut> request, CancellationToken cancellationToken = default);
}
