namespace Glitter.Pipelines;

/// <summary>
/// Defines a method for creating a pipeline.
/// </summary>
public static class CreatePipeline
{
    /// <summary>
    /// Creates a new pipeline for working with the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the input for the pipeline.</typeparam>
    /// <param name="optimize">Indicates whether the pipeline should be optimized.</param>
    public static IPipeline<T> For<T>(bool optimize = false) =>
        new Pipeline<T>(optimize);
}