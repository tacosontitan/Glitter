namespace Glitter.Data.Sql;

/// <summary>
/// Defines a handler for a SQL command.
/// </summary>
public interface ISqlProvider
    : IDataProvider
{
    /// <summary>
    /// Executes a non-query request.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to execute.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ExecuteNonQuery<TRequest>(
        TRequest request,
        CancellationToken cancellationToken = default)
        where TRequest : IRequest;

    /// <summary>
    /// Executes a query that returns a scalar value.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to execute.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The response from the request.</returns>
    Task<TResponse> ExecuteScalar<TResponse>(
        IRequest<TResponse> request,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Executes a query.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to execute.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The response from the request.</returns>
    Task<IEnumerable<TResponse>> Query<TResponse>(
        IRequest<IEnumerable<TResponse>> request,
        CancellationToken cancellationToken = default);
}
