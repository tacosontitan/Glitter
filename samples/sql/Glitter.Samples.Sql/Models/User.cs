using System.Data;

using Glitter.Sql;

namespace Glitter.Samples.Sql.Models;

/// <summary>
/// Represents a user.
/// </summary>
[SqlTable("Users")]
internal sealed class User
{
    /// <summary>
    /// The ID of the user.
    /// </summary>
    [SqlColumn("Id", DbType.Int32)]
    public int Id { get; set; }
    /// <summary>
    /// The name of the user.
    /// </summary>
    [SqlColumn("Name", DbType.String, size: 255)]
    public string Name { get; set; }
}