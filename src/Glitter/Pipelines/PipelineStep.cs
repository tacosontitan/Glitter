namespace Glitter.Pipelines;

/// <summary>
/// Represents a step in a pipeline.
/// </summary>
/// <typeparam name="T">The type of the input to the pipeline.</typeparam>
internal sealed class PipelineStep<T>
{
    /// <summary>
    /// The action to execute.
    /// </summary>
    internal PipelineAction<T> Action { get; }
    /// <summary>
    /// The conditions that must be met for the action to be executed.
    /// </summary>
    internal IEnumerable<Func<T, bool>> Conditions { get; }
    /// <summary>
    /// Initializes a new instance of the <see cref="PipelineStep{T}"/> class.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    /// <param name="conditions">The conditions that must be met for the action to be executed.</param>
    /// <exception cref="ArgumentNullException"><paramref name="action"/> is <see langword="null"/>.</exception>
    internal PipelineStep(PipelineAction<T> action, IEnumerable<Func<T, bool>> conditions)
    {
        if (action is null)
            throw new ArgumentNullException(nameof(action));

        Action = action;
        Conditions = conditions;
    }
}