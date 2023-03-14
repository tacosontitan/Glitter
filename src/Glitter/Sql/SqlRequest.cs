namespace Glitter.Sql;

/// <summary>
/// Defines a request for interacting with SQL.
/// </summary>
public class SqlRequest
{
    /// <summary>
    /// The command to execute.
    /// </summary>
    internal string? Command { get; set; }
    /// <summary>
    /// The type of command to execute.
    /// </summary>
    public CommandType CommandType { get; private set; }
    /// <summary>
    /// The parameters for the command.
    /// </summary>
    public List<SqlRequestParameter> Parameters { get; private set; }
    /// <summary>
    /// Creates a new <see cref="SqlRequest"/> instance.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <param name="commandType">The type of command to execute.</param>
    public SqlRequest(string? command, CommandType commandType)
    {
        Command = command;
        CommandType = commandType;
        Parameters = new List<SqlRequestParameter>();
    }
    /// <summary>
    /// Creates a new <see cref="SqlRequest"/> instance.
    /// </summary>
    /// <param name="commandType">The command to execute.</param>
    protected SqlRequest(CommandType commandType) :
        this(null, commandType)
    { }
    /// <summary>
    /// Adds a parameter to the request.
    /// </summary>
    /// <param name="name">The name of the parameter.</param>
    /// <param name="value">The value of the parameter.</param>
    /// <param name="type">The <see cref="DbType"/> of the parameter.</param>
    /// <param name="direction">The direction of the parameter.</param>
    /// <param name="size">The size of the parameter.</param>
    /// <param name="precision">The precision of the parameter.</param>
    /// <param name="scale">The scale of the parameter.</param>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    public virtual SqlRequest AddParameter<T>(
        string name,
        T? value,
        DbType? type = null,
        ParameterDirection? direction = null,
        int? size = null,
        byte? precision = null,
        byte? scale = null)
    {
        Parameters.Add(new SqlRequestParameter(name, value, type, direction, size, precision, scale));
        return this;
    }
    public virtual SqlRequest AddParameterIfNotNull<T>(
        string name,
        T? value,
        DbType? type = null,
        ParameterDirection? direction = null,
        int? size = null,
        byte? precision = null,
        byte? scale = null)
    {
        if (value is not null)
            Parameters.Add(new SqlRequestParameter(name, value, type, direction, size, precision, scale));

        return this;
    }
    public SqlRequest AddParameterIfNotNullOrEmpty(string name, string? value, DbType? type = null, ParameterDirection? direction = null, int? size = null, byte? precision = null, byte? scale = null)
    {
        if (!string.IsNullOrEmpty(value))
            Parameters.Add(new SqlRequestParameter(name, value, type, direction, size, precision, scale));

        return this;
    }
    public SqlRequest AddParameterIfNotNullOrWhiteSpace(string name, string? value, DbType? type = null, ParameterDirection? direction = null, int? size = null, byte? precision = null, byte? scale = null)
    {
        if (!string.IsNullOrWhiteSpace(value))
            Parameters.Add(new SqlRequestParameter(name, value, type, direction, size, precision, scale));

        return this;
    }
    public SqlRequest AddParameterIf<T>(Func<T, bool> predicate, string name, T? value, DbType? type = null, ParameterDirection? direction = null, int? size = null, byte? precision = null, byte? scale = null)
    {
        if (predicate(value))
            Parameters.Add(new SqlRequestParameter(name, value, type, direction, size, precision, scale));

        return this;
    }
    public SqlRequest AddParameterIfNot<T>(Func<T, bool> predicate, string name, T? value, DbType? type = null, ParameterDirection? direction = null, int? size = null, byte? precision = null, byte? scale = null)
    {
        if (!predicate(value))
            Parameters.Add(new SqlRequestParameter(name, value, type, direction, size, precision, scale));

        return this;
    }
    /// <summary>
    /// Attempts to build the command for the request.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public virtual bool TryBuildCommand(out string? command)
    {
        command = Command;
        return !string.IsNullOrWhiteSpace(command);
    }
}