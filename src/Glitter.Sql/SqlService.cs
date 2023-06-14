namespace Glitter.Sql;

/// <summary>
/// Represents a service for interacting with SQL.
/// </summary>
public abstract class SqlService
{
    /// <summary>
    /// The <see cref="Sql.ConnectionInformation"/> used by this service for interacting with SQL.
    /// </summary>
    protected ConnectionInformation? ConnectionInformation { get; set; }
    /// <summary>
    /// Creates a new <see cref="SqlService"/> with the specified <see cref="ISqlProvider"/>.
    /// </summary>
    /// <param name="connectionInformation">The <see cref="Sql.ConnectionInformation"/> used by this service for interacting with SQL.</param>
    public SqlService(ConnectionInformation connectionInformation) =>
        ConnectionInformation = connectionInformation;
    /// <summary>
    /// Executes the specified <see cref="SqlRequest"/> as a query and returns the results.
    /// </summary>
    /// <param name="request">The request to execute.</param>
    /// <typeparam name="T">Specifies the expected return type.</typeparam>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public abstract Task<IEnumerable<T>> Query<T>(SqlRequest request);
    /// <summary>
    /// Executes the specified <see cref="SqlRequest"/> as a query and returns the first column of the first row in the result set returned by the query.
    /// </summary>
    /// <param name="request">The request to execute.</param>
    /// <typeparam name="T">Specifies the expected return type.</typeparam>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public abstract Task<T> ExecuteScalar<T>(SqlRequest request);
    /// <summary>
    /// Executes the specified <see cref="SqlRequest"/>.
    /// </summary>
    /// <param name="request">The request to execute.</param>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public abstract Task Execute(SqlRequest request);
}