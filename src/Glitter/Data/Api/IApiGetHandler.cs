namespace Glitter.Data.Api;

/// <summary>
/// Represents a handler for a GET request.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IApiGetHandler<in TRequest, TResponse>
    : IDataRequestHandler<IApiProvider, TRequest, TResponse>
    where TRequest : IRequest<TResponse>;
    
/// <summary>
/// Represents a handler for a GET request.
/// </summary>
/// <typeparam name="TProvider">Specifies the type of the provider.</typeparam>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IApiGetHandler<in TProvider, in TRequest, TResponse>
    : IDataRequestHandler<TProvider, TRequest, TResponse>
    where TProvider : IApiProvider
    where TRequest : IRequest<TResponse>;