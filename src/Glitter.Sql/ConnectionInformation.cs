namespace Glitter.Sql;

/// <summary>
/// Represents information about a connection to a SQL database.
/// </summary>
public class ConnectionInformation
{
    /// <summary>
    /// Should the connection use integrated security?
    /// </summary>
    public bool IntegratedSecurity { get; set; }
    /// <summary>
    /// The server to connect to.
    /// </summary>
    public string? Server { get; set; }
    /// <summary>
    /// The database to connect to.
    /// </summary>
    public string? Database { get; set; }
    /// <summary>
    /// The username to use when connecting.
    /// </summary>
    public string? Username { get; set; }
    /// <summary>
    /// The password to use when connecting.
    /// </summary>
    public string? Password { get; set; }
    /// <summary>
    /// The amount of time to wait for a connection to be established.
    /// </summary>
    /// <value></value>
    public TimeSpan? ConnectionTimeout { get; set; }
    /// <summary>
    /// The amount of time to wait for a command to execute.
    /// </summary>
    /// <value></value>
    public TimeSpan? CommandTimeout { get; set; }
    /// <summary>
    /// Creates a new <see cref="ConnectionInformation"/> with the specified values.
    /// </summary>
    /// <param name="integratedSecurity">Should the connection use integrated security?</param>
    /// <param name="server">The server to connect to.</param>
    /// <param name="database">The database to connect to.</param>
    /// <param name="username">The username to use when connecting.</param>
    /// <param name="password">The password to use when connecting.</param>
    /// <param name="connectionString">The connection string to use when connecting.</param>
    /// <param name="connectionTimeout">The amount of time to wait for a connection to be established.</param>
    /// <param name="commandTimeout">The amount of time to wait for a command to execute.</param>
    public ConnectionInformation(
        bool? integratedSecurity = null,
        string? server = null,
        string? database = null,
        string? username = null,
        string? password = null,
        string? connectionString = null,
        TimeSpan? connectionTimeout = null,
        TimeSpan? commandTimeout = null)
    {
        IntegratedSecurity = integratedSecurity ?? false;
        Server = server;
        Database = database;
        Username = username;
        Password = password;
        ConnectionTimeout = connectionTimeout;
        CommandTimeout = commandTimeout;
    }
}