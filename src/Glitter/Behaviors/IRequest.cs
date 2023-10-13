namespace Glitter;

/// <summary>
/// Represents a request.
/// </summary>
public interface IRequest;

/// <summary>
/// Represents a request with a response.
/// </summary>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IRequest<out TResponse>;
