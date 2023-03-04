namespace Glitter.Pipelines;

/// <summary>
/// Represents a processor that is executed as part of a pipeline.
/// </summary>
public abstract class PipelineProcessor<T>
{
    /// <summary>
    /// Executes the processor.
    /// </summary>
    /// <param name="input">The input to the pipeline.</param>
    /// <param name="next">The next action in the pipeline.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public abstract Task Invoke(T input, PipelineProcessor<T> next, CancellationToken cancellationToken);
}