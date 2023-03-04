using System.Linq.Expressions;

namespace Glitter.Pipelines;

/// <summary>
/// Represents a step in a pipeline.
/// </summary>
/// <typeparam name="T">The type of the input to the pipeline.</typeparam>
internal sealed class PipelineStep<T>
{
    /// <summary>
    /// The type of processor for the step.
    /// </summary>
    internal Type ProcessorType { get; }
    /// <summary>
    /// The conditions that must be met for the processor to be executed.
    /// </summary>
    internal IEnumerable<Func<T, bool>> Conditions { get; }
    /// <summary>
    /// Creates a new instance of the <see cref="PipelineStep{T}"/> class.
    /// </summary>
    /// <typeparam name="TProcessor">The type of the processor for this step.</typeparam>
    /// <param name="conditions">The conditions that must be met for the processor to be executed.</param>
    /// <returns>The new instance of the <see cref="PipelineStep{T}"/> class.</returns>
    internal PipelineStep<T> CreateFor<TProcessor>(IEnumerable<Func<T, bool>> conditions)
        where TProcessor : PipelineProcessor<T> =>
        new(typeof(TProcessor), conditions);
    /// <summary>
    /// Initializes a new instance of the <see cref="PipelineStep{T}"/> class.
    /// </summary>
    /// <param name="processorType">The type of the processor for this step..</param>
    /// <param name="conditions">The conditions that must be met for the processor to be executed.</param>
    /// <exception cref="ArgumentNullException"><paramref name="action"/> is <see langword="null"/>.</exception>
    private PipelineStep(Type processorType, IEnumerable<Func<T, bool>> conditions)
    {
        if (processorType is null)
            throw new ArgumentNullException(nameof(processorType));

        ProcessorType = processorType;
        Conditions = conditions;
    }
}