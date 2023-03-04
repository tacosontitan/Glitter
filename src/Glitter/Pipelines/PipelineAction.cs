namespace Glitter.Pipelines;

/// <summary>
/// Represents a request handler that is executed as part of a pipeline.
/// </summary>
public abstract class PipelineAction<T>
{
    /// <summary>
    /// Executes the pipeline action.
    /// </summary>
    /// <param name="input">The input to the pipeline.</param>
    /// <param name="next">The next action in the pipeline.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public abstract Task Invoke(T input, PipelineAction<T> next);
}