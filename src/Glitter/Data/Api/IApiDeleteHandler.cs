namespace Glitter.Data.Api;

/// <summary>
/// Represents a handler for a DELETE request.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
public interface IApiDeleteHandler<in TRequest>
    : IDataRequestHandler<IApiProvider, TRequest>
    where TRequest : IRequest;

/// <summary>
/// Represents a handler for a DELETE request.
/// </summary>
/// <typeparam name="TProvider">Specifies the type of the provider.</typeparam>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
public interface IApiDeleteHandler<in TProvider, in TRequest>
    : IDataRequestHandler<TProvider, TRequest>
    where TProvider : IApiProvider
    where TRequest : IRequest;