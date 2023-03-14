namespace Glitter.Pipelines;

/// <summary>
/// Represents a pipeline that processes a request.
/// </summary>
/// <typeparam name="T">Specifies the type of the input for the pipeline.</typeparam>
public class Pipeline<T> : IPipeline<T>
{
    private bool _recompileNeeded;
    private PipelineProcessor<T>? _head;
    private readonly bool _optimize;
    private readonly List<PipelineStep<T>> _steps;
    internal Pipeline(bool optimize)
    {
        _optimize = optimize;
        _steps = new List<PipelineStep<T>>();
    }
    /// <summary>
    /// Processes the request.
    /// </summary>
    /// <param name="input">The input to the pipeline.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Process(T input) =>
        Process(input, CancellationToken.None);
    /// <summary>
    /// Processes the request.
    /// </summary>
    /// <param name="input">The input to the pipeline.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task Process(T input, CancellationToken cancellationToken)
    {
        PipelineProcessor<T>? head = _head is null || _recompileNeeded || !_optimize
            ? CompileProcessorChain(input)
            : _head;

        if (head is null)
            return;

        if (_optimize)
            _head = head;

        await head.Invoke(input, cancellationToken);
    }
    /// <summary>
    /// Adds an processor to the pipeline.
    /// </summary>
    /// <typeparam name="TProcessor">The type of the processor to add.</typeparam>
    /// <returns>The pipeline.</returns>
    public IPipeline<T> Using<TProcessor>() where TProcessor : PipelineProcessor<T>
    {
        _recompileNeeded = true;
        var conditions = Array.Empty<Func<T, bool>>();
        var step = new PipelineStep<T>(typeof(TProcessor), conditions);
        _steps.Add(step);
        return this;
    }
    private PipelineProcessor<T>? CompileProcessorChain(T input)
    {
        if (_steps?.Any() != true)
            return null;

        PipelineStep<T> firstStep = _steps.First();
        if (firstStep is null)
            return null;

        if (!firstStep.Conditions.All(condition => condition(input)))
            return null;

        PipelineProcessor<T>? head = (PipelineProcessor<T>?)Activator.CreateInstance(_steps.First().ProcessorType);
        if (head is null)
            return null;

        PipelineProcessor<T>? previous = head;
        foreach (var step in _steps.Skip(1))
        {
            if (!step.Conditions.All(condition => condition(input)))
                break;

            var processor = (PipelineProcessor<T>?)Activator.CreateInstance(step.ProcessorType);
            if (processor is null)
                break;

            previous.Next = processor;
            previous = processor;
        }

        return head;
    }
}