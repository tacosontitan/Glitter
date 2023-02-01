using Glitter.Sql;

namespace Glitter.Tests.Sql;

/// <summary>
/// Represents a mocked <see cref="ISqlProvider"/> for testing purposes.
/// </summary>
public class MockProvider : ISqlProvider
{
    /// <summary>
    /// Simulates a successful execution of a <see cref="SqlRequest"/>.
    /// </summary>
    /// <param name="request">The <see cref="SqlRequest"/> to execute.</param>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public Task Execute(SqlRequest request) => Task.CompletedTask;
    /// <summary>
    /// Simulates a successful execution of a <see cref="SqlRequest"/>.
    /// </summary>
    /// <param name="request">The <see cref="SqlRequest"/> to execute.</param>
    /// <typeparam name="T">Specifies the type to be returned.</typeparam>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public Task<T> ExecuteScalar<T>(SqlRequest request) => Task.FromResult(default(T)!);
    /// <summary>
    /// Simulates a successful execution of a <see cref="SqlRequest"/>.
    /// </summary>
    /// <param name="request">The <see cref="SqlRequest"/> to execute.</param>
    /// <typeparam name="T">Specifies the type to be returned.</typeparam>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public Task<IEnumerable<T>> Query<T>(SqlRequest request) => Task.FromResult(Enumerable.Empty<T>());
}