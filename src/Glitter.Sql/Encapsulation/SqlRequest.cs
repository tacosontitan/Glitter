/*
   Copyright 2023 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace Glitter.Sql.Encapsulation;

/// <summary>
/// Defines a request for interacting with SQL.
/// </summary>
public class SqlRequest
    : ISqlRequest
{
    private readonly List<SqlRequestParameter> _parameters;

    /// <summary>
    /// Creates a new <see cref="SqlRequest"/> instance.
    /// </summary>
    /// <param name="commandType">The type of command to execute.</param>
    public SqlRequest(CommandType commandType)
    {
        CommandType = commandType;
        _parameters = new List<SqlRequestParameter>();
    }

    /// <summary>
    /// Creates a new <see cref="SqlRequest"/> instance.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <param name="commandType">The type of command to execute.</param>
    public SqlRequest(string? command, CommandType commandType)
        : this(commandType) =>
        Command = command;

    /// <summary>
    /// Gets or sets the command to execute.
    /// </summary>
    internal string? Command { get; set; }

    /// <summary>
    /// Gets or sets the type of command to execute.
    /// </summary>
    public CommandType CommandType { get; set; }

    /// <summary>
    /// Gets the parameters for the command.
    /// </summary>
    public ICollection<SqlRequestParameter> Parameters =>
        _parameters.AsReadOnly();

    /// <inheritdoc/>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is null or whitespace.</exception>
    /// <exception cref="InvalidOperationException">Thrown when <paramref name="name"/> has already been specified.</exception>
    public virtual ISqlRequest AddParameter<T>(
        string name,
        T? value,
        DbType? type = null,
        ParameterDirection? direction = null,
        int? size = null,
        byte? precision = null,
        byte? scale = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException($"The name of the parameter cannot be null or whitespace.");

        if (_parameters.Any(parameter => parameter.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            throw new InvalidOperationException($"The parameter `{name}` has already been specified.");

        _parameters.Add(new SqlRequestParameter(name, value, type, direction, size, precision, scale));
        return this;
    }

    /// <inheritdoc/>
    public virtual bool TryCompile(out string? command)
    {
        command = Command;
        return !string.IsNullOrWhiteSpace(command);
    }
}
