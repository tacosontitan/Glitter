namespace Glitter.Sql;

/// <summary>
/// Represents a procedure within SQL.
/// </summary>
public class SqlProcedure : SqlRequest
{
    /// <summary>
    /// Creates a new <see cref="SqlProcedure"/> instance.
    /// </summary>
    /// <param name="procedureName">The name of the procedure.</param>
    public SqlProcedure(string procedureName) :
        base(procedureName, CommandType.StoredProcedure)
    { }
}