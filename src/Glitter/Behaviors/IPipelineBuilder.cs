namespace Glitter.Behaviors;

/// <summary>
/// Represents a pipeline for processing requests.
/// </summary>
public interface IPipelineBuilder<TRequest>
{
    IPipelineBuilder<TRequest> Add<TPipe>()
        where TPipe : IPipe<TRequest>;
}
