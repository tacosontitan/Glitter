namespace Glitter.Data.Io;

/// <summary>
/// Represents a handler for a file query.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IFileQueryHandler<in TRequest, TResponse>
    : IDataRequestHandler<IFileProvider, TRequest, IEnumerable<TResponse>>
    where TRequest : IRequest<IEnumerable<TResponse>>;
    
/// <summary>
/// Represents a handler for a file query.
/// </summary>
/// <typeparam name="TProvider">Specifies the type of the provider.</typeparam>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IFileQueryHandler<in TProvider, in TRequest, TResponse>
    : IDataRequestHandler<TProvider, TRequest, IEnumerable<TResponse>>
    where TProvider : IFileProvider
    where TRequest : IRequest<IEnumerable<TResponse>>;