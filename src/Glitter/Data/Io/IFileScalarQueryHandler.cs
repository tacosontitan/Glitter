namespace Glitter.Data.Io;

/// <summary>
/// Represents a handler for a file scalar query.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IFileScalarQueryHandler<in TRequest, TResponse>
    : IDataRequestHandler<IFileProvider, TRequest, TResponse>
    where TRequest : IRequest<TResponse>;
    
/// <summary>
/// Represents a handler for a file scalar query.
/// </summary>
/// <typeparam name="TProvider">Specifies the type of the provider.</typeparam>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IFileScalarQueryHandler<in TProvider, in TRequest, TResponse>
    : IDataRequestHandler<TProvider, TRequest, TResponse>
    where TProvider : IFileProvider
    where TRequest : IRequest<TResponse>;