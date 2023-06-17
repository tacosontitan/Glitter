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
/// Represents a function within SQL.
/// </summary>
public class SqlFunction :
    SqlRequest
{
    private readonly string _schema;
    private readonly string _functionName;
    private readonly ICollection<string> _parameterNames;

    /// <summary>
    /// Creates a new <see cref="SqlFunction"/> instance.
    /// </summary>
    /// <param name="functionName">The name of the function being invoked.</param>
    /// <exception cref="ArgumentException"><paramref name="functionName"/> is null or whitespace.</exception>
    public SqlFunction(string functionName) :
        base(CommandType.Text)
    {
        // Validate the function name.
        if (string.IsNullOrWhiteSpace(functionName))
            throw new ArgumentException("The function name cannot be null or whitespace.");

        _schema = "dbo";
        _functionName = functionName;
        _parameterNames = new List<string>();
    }

    /// <summary>
    /// Creates a new <see cref="SqlFunction"/> instance.
    /// </summary>
    /// <param name="schema">The schema for the function.</param>
    /// <param name="functionName">The name of the function being invoked.</param>
    /// <exception cref="ArgumentException"><paramref name="functionName"/> is null or whitespace.</exception>
    public SqlFunction(string schema, string functionName) :
        this(functionName) =>
        _schema = schema;

    /// <inheritdoc/>
    /// <exception cref="ArgumentException"><paramref name="name"/> is <see langword="null"/>, whitespace, or already specified.</exception>
    public override SqlRequest AddParameter<T>(
        string name,
        T? value,
        DbType? type = null,
        ParameterDirection? direction = null,
        int? size = null,
        byte? precision = null,
        byte? scale = null) where T : default
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException($"The name of the parameter cannot be null or whitespace.");

        // If the parameter name is already listed then throw an exception.
        if (_parameterNames.Contains(name))
            throw new ArgumentException($"The parameter `{name}` has already been specified.");

        _parameterNames.Add(name);
        base.AddParameter(name, value, type, direction, size, precision, scale);
        return this;
    }

    /// <inheritdoc/>
    public override bool TryBuildCommand(out string? command)
    {
        string parameters = string.Join(", ", _parameterNames.Select(x => $"@{x}"));
        Command = $"SELECT * FROM [{_schema}].[{_functionName}] ({parameters})";
        return base.TryBuildCommand(out command);
    }
}
