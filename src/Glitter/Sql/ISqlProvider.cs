namespace Glitter.Sql;

/// <summary>
/// Defines methods for interacting with a SQL database.
/// </summary>
public interface ISqlProvider
{
    /// <summary>
    /// Executes the specified <see cref="SqlRequest"/> as a query and returns the results.
    /// </summary>
    /// <param name="request">The request to execute.</param>
    /// <typeparam name="T">Specifies the expected return type.</typeparam>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    Task<IEnumerable<T>> Query<T>(SqlRequest request);
    /// <summary>
    /// Executes the specified <see cref="SqlRequest"/> as a query and returns the first column of the first row in the result set returned by the query.
    /// </summary>
    /// <param name="request">The request to execute.</param>
    /// <typeparam name="T">Specifies the expected return type.</typeparam>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    Task<T> ExecuteScalar<T>(SqlRequest request);
    /// <summary>
    /// Executes the specified <see cref="SqlRequest"/>.
    /// </summary>
    /// <param name="request">The request to execute.</param>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    Task Execute(SqlRequest request);
}