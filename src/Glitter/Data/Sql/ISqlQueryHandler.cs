namespace Glitter.Data.Sql;

/// <summary>
/// Represents a handler for a SQL query.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface ISqlQueryHandler<in TRequest, TResponse>
    : IDataRequestHandler<ISqlProvider, TRequest, IEnumerable<TResponse>>
    where TRequest : IRequest<IEnumerable<TResponse>>;
    
/// <summary>
/// Represents a handler for a SQL query.
/// </summary>
/// <typeparam name="TProvider">Specifies the type of the provider.</typeparam>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface ISqlQueryHandler<in TProvider, in TRequest, TResponse>
    : IDataRequestHandler<TProvider, TRequest, IEnumerable<TResponse>>
    where TProvider : ISqlProvider
    where TRequest : IRequest<IEnumerable<TResponse>>;