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
    /// Adds an action to the pipeline.
    /// </summary>
    /// <typeparam name="TAction">The type of the action to add.</typeparam>
    /// <returns>The pipeline.</returns>
    IPipeline<T> With<TAction>() where TAction : PipelineAction<T>;
    /// <summary>
    /// Adds a condition that must be met for the next action to be executed.
    /// </summary>
    /// <param name="condition">The condition to add.</param>
    /// <returns>The pipeline.</returns>
    IPipeline<T> When(Func<T, bool> condition);
    /// <summary>
    /// Provides an alternative action to execute if the previously specified condition is not met.
    /// </summary>
    /// <typeparam name="TAction">The type of the action to add.</typeparam>
    /// <returns>The pipeline.</returns>
    IPipeline<T> Else<TAction>() where TAction : PipelineAction<T>;
}