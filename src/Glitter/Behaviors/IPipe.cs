namespace Glitter.Behaviors;

/// <summary>
/// Represents a pipe in a pipeline.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
public interface IPipe<in TRequest>
    where TRequest : IRequest
{
    /// <summary>
    /// Gets the next pipe in the pipeline.
    /// </summary>
    IPipe<TRequest> Successor { get; }
    
    /// <summary>
    /// Processes the specified request.
    /// </summary>
    Task Process(TRequest request, CancellationToken cancellationToken = default);
}

/// <summary>
/// Represents a pipe in a pipeline.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IPipe<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Gets the next pipe in the pipeline.
    /// </summary>
    IPipe<TRequest, TResponse> Successor { get; }
    
    /// <summary>
    /// Processes the specified request.
    /// </summary>
    Task<TResponse> Process(TRequest request, CancellationToken cancellationToken = default);
}
