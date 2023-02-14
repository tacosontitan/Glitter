using System.Data;

using Glitter.Sql;

namespace Glitter.Samples.Sql.Users;

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
    /// The given name of the user.
    /// </summary>
    [SqlColumn("GivenName", DbType.String, size: 50)]
    public string? GivenName { get; set; }
    /// <summary>
    /// The surname of the user.
    /// </summary>
    [SqlColumn("Surname", DbType.String, size: 50)]
    public string? Surname { get; set; }
    /// <summary>
    /// The username of the user.
    /// </summary>
    [SqlColumn("Username", DbType.String, size: 50)]
    public string? Username { get; set; }
}