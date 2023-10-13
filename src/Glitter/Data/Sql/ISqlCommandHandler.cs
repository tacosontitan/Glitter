namespace Glitter.Data.Sql;

/// <summary>
/// Defines a handler for a SQL command.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
public interface ISqlCommandHandler<in TRequest>
    : IDataRequestHandler<ISqlProvider, TRequest>
    where TRequest : IRequest;

/// <summary>
/// Defines a handler for a SQL command.
/// </summary>
/// <typeparam name="TProvider">Specifies the type of the provider.</typeparam>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
public interface ISqlCommandHandler<in TProvider, in TRequest>
    : IDataRequestHandler<TProvider, TRequest>
    where TProvider : ISqlProvider
    where TRequest : IRequest;