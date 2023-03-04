namespace Glitter.Pipelines;

/// <summary>
/// Represents a pipeline that processes a request.
/// </summary>
public interface IPipeline<T>
{
    /// <summary>
    /// Processes the request.
    /// </summary>
    /// <param name="input">The input to the pipeline.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Process(T input);
}