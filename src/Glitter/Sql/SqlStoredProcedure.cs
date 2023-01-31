namespace Glitter.Sql;

/// <summary>
/// Represents a stored procedure within SQL.
/// </summary>
public class SqlStoredProcedure : SqlRequest
{
    /// <summary>
    /// Creates a new <see cref="SqlStoredProcedure"/> instance.
    /// </summary>
    /// <param name="procedureName">The name of the stored procedure.</param>
    public SqlStoredProcedure(string procedureName) :
        base(procedureName, CommandType.StoredProcedure)
    { }
}