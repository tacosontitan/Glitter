namespace Glitter.Pipelines;

/// <summary>
/// Represents a pipeline that processes a request.
/// </summary>
/// <typeparam name="T">Specifies the type of the input for the pipeline.</typeparam>
public class Pipeline<T> : IPipeline<T>
{
    private readonly List<PipelineStep<T>> _steps;
    internal Pipeline() =>
        _steps = new List<PipelineStep<T>>();
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
        if (_steps?.Any() != true)
            return;

        PipelineStep<T>? firstStep = _steps?.FirstOrDefault();
        if (firstStep is null)
            return;

        var processor = (PipelineProcessor<T>?)Activator.CreateInstance(firstStep.ProcessorType);
        if (processor is null)
            return;

        PipelineStep<T>? secondStep = _steps?.Count > 1 ? _steps[1] : null;
        PipelineProcessor<T>? nextProcessor = null;
        if (secondStep is not null)
            nextProcessor = (PipelineProcessor<T>?)Activator.CreateInstance(secondStep.ProcessorType);

        await processor.Invoke(input, nextProcessor, cancellationToken);
    }
    /// <summary>
    /// Adds an processor to the pipeline.
    /// </summary>
    /// <typeparam name="TProcessor">The type of the processor to add.</typeparam>
    /// <returns>The pipeline.</returns>
    public IPipeline<T> Using<TProcessor>() where TProcessor : PipelineProcessor<T>
    {
        var conditions = Array.Empty<Func<T, bool>>();
        var step = new PipelineStep<T>(typeof(TProcessor), conditions);
        _steps.Add(step);
        return this;
    }
}