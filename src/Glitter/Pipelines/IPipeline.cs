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
    /// <summary>
    /// Processes the request.
    /// </summary>
    /// <param name="input">The input to the pipeline.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Process(T input, CancellationToken cancellationToken);
    /// <summary>
    /// Adds an processor to the pipeline.
    /// </summary>
    /// <typeparam name="TProcessor">The type of the processor to add.</typeparam>
    /// <returns>The pipeline.</returns>
    IPipeline<T> With<TProcessor>() where TProcessor : PipelineProcessor<T>;
    /// <summary>
    /// Adds a condition that must be met for the next processor to be executed.
    /// </summary>
    /// <param name="condition">The condition to add.</param>
    /// <returns>The pipeline.</returns>
    IPipeline<T> When(Func<T, bool> condition);
    /// <summary>
    /// Provides an alternative processor to execute if the previously specified condition is not met.
    /// </summary>
    /// <typeparam name="TProcessor">The type of the processor to add.</typeparam>
    /// <returns>The pipeline.</returns>
    IPipeline<T> Else<TProcessor>() where TProcessor : PipelineProcessor<T>;
}