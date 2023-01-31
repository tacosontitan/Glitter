namespace Glitter.Sql;

/// <summary>
/// Represents a SQL query.
/// </summary>
public class SqlQuery : SqlRequest
{
    /// <summary>
    /// Creates a new <see cref="SqlQuery"/> instance.
    /// </summary>
    /// <param name="query">The query to execute in the request.</param>
    public SqlQuery(string query) :
        base(query, CommandType.Text)
    { }
}