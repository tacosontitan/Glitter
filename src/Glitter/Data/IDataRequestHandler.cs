namespace Glitter.Data;

/// <summary>
/// Represents a handler for a data request.
/// </summary>
/// <typeparam name="TProvider">Specifies the type of the data provider.</typeparam>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
public interface IDataRequestHandler<in TProvider, in TRequest>
    where TProvider : IDataProvider
    where TRequest : IRequest
{
    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="provider">The data provider for the request.</param>
    /// <param name="request">The request to handle.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Handle(TProvider provider, TRequest request, CancellationToken cancellationToken = default);
}

/// <summary>
/// Represents a handler for a data request.
/// </summary>
/// <typeparam name="TProvider">Specifies the type of the data provider.</typeparam>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IDataRequestHandler<in TProvider, in TRequest, TResponse>
    where TProvider : IDataProvider
    where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="provider">The data provider for the request.</param>
    /// <param name="request">The request to handle.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The response from the request.</returns>
    Task<TResponse> Handle(TProvider provider, TRequest request, CancellationToken cancellationToken = default);
}