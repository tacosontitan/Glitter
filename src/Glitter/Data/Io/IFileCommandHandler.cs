namespace Glitter.Data.Io;

/// <summary>
/// Represents a handler for a file command.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
public interface IFileCommandHandler<in TRequest>
    : IDataRequestHandler<IFileProvider, TRequest>
    where TRequest : IRequest;
    
/// <summary>
/// Represents a handler for a file command.
/// </summary>
/// <typeparam name="TProvider">Specifies the type of the provider.</typeparam>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
public interface IFileCommandHandler<in TProvider, in TRequest>
    : IDataRequestHandler<TProvider, TRequest>
    where TProvider : IFileProvider
    where TRequest : IRequest;