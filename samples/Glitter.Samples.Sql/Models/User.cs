namespace Glitter.Samples.Sql;

/// <summary>
/// Represents a user.
/// </summary>
[SqlTarget(SqlTargetType.Table, "Users")]
internal sealed class User
{
    /// <summary>
    /// The ID of the user.
    /// </summary>
    [SqlColumn("ID", DbType.Int32)]
    public int Id { get; set; }
    /// <summary>
    /// The name of the user.
    /// </summary>
    [SqlColumn("Name", DbType.String, size: 255)]
    public string Name { get; set; }
}