namespace Glitter.Pipelines;

/// <summary>
/// Defines a method for creating a pipeline.
/// </summary>
public static class Pipeline
{
    /// <summary>
    /// Creates a new pipeline for working with the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the input for the pipeline.</typeparam>
    public static IPipeline<T> For<T>() =>
        new Pipeline<T>();
}