using Glitter.Sql;

namespace Glitter.Tests.Sql;

/// <summary>
/// Represents a mocked <see cref="ISqlProvider"/> for testing purposes.
/// </summary>
public class MockService : SqlService
{
    public MockService() :
        base(new ConnectionInformation())
    { }
    public override Task Execute(SqlRequest request) => Task.CompletedTask;
    public override Task<T> ExecuteScalar<T>(SqlRequest request) =>
        Task.FromResult(default(T)!);
    public override Task<IEnumerable<T>> Query<T>(SqlRequest request) =>
        Task.FromResult(Enumerable.Empty<T>());
}