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
public class SqlRequest :
    ISqlRequest
{
    private readonly List<SqlRequestParameter> _parameters;

    /// <summary>
    /// The command to execute.
    /// </summary>
    internal string? Command { get; set; }
    
    /// <summary>
    /// The type of command to execute.
    /// </summary>
    public CommandType CommandType { get; set; }
    
    /// <summary>
    /// The parameters for the command.
    /// </summary>
    public ICollection<SqlRequestParameter> Parameters =>
        _parameters.AsReadOnly();

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
    public SqlRequest(string? command, CommandType commandType) :
        this(commandType) =>
        Command = command;
    
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
    /// <returns>The <see cref="SqlRequest"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is null or whitespace.</exception>
    /// <exception cref="InvalidOperationException">Thrown when <paramref name="name"/> has already been specified.</exception>
    public virtual SqlRequest AddParameter<T>(
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
