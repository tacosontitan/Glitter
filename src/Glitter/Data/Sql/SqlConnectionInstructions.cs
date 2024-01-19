namespace Glitter.Data.Sql;

/// <summary>
/// Represents instructions for connecting to a SQL server.
/// </summary>
public class SqlConnectionInstructions
{
    /// <summary>
    /// Creates a new set of connection instructions.
    /// </summary>
    public SqlConnectionInstructions(
        string server,
        string database,
        TimeSpan? connectionTimeout = null,
        TimeSpan? commandTimeout = null)
    {
        Server = server;
        Database = database;
        ConnectionTimeout = connectionTimeout ?? TimeSpan.FromSeconds(30);
        CommandTimeout = commandTimeout ?? TimeSpan.FromSeconds(30);
    }

    /// <summary>
    /// Gets or sets whether or not the connection should use integrated security.
    /// </summary>
    public bool IntegratedSecurity { get; set; }

    /// <summary>
    /// Gets or sets the server to connect to.
    /// </summary>
    public string? Server { get; set; }

    /// <summary>
    /// Gets or sets the database to connect to.
    /// </summary>
    public string? Database { get; set; }

    /// <summary>
    /// Gets or sets the username to use when connecting.
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the password to use when connecting.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Gets or sets the amount of time to wait for a connection to be established.
    /// </summary>
    public TimeSpan? ConnectionTimeout { get; set; }

    /// <summary>
    /// Gets or sets the amount of time to wait for a command to execute.
    /// </summary>
    public TimeSpan? CommandTimeout { get; set; }
}