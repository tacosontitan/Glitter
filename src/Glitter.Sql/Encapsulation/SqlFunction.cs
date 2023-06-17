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
    DefinedSqlRequest
{
    /// <summary>
    /// Creates a new <see cref="SqlFunction"/> instance.
    /// </summary>
    /// <param name="functionName">The name of the function being invoked.</param>
    /// <exception cref="ArgumentException"><paramref name="functionName"/> is null or whitespace.</exception>
    protected SqlFunction(string functionName) :
        base(
            schema: "dbo",
            name: functionName,
            commandType: CommandType.Text)
    { }

    /// <summary>
    /// Creates a new <see cref="SqlFunction"/> instance.
    /// </summary>
    /// <param name="schema">The schema for the function.</param>
    /// <param name="functionName">The name of the function being invoked.</param>
    /// <exception cref="ArgumentException"><paramref name="functionName"/> or <paramref name="functionName"/> is null or whitespace.</exception>
    protected SqlFunction(string schema, string functionName) :
        base(
            schema: schema,
            name: functionName,
            commandType: CommandType.Text)
    { }

    /// <inheritdoc/>
    public override bool TryCompile(out string? command)
    {
        string parameters = string.Join(", ", Parameters.Select(x => $"@{x.Name}"));
        Command = $"SELECT * FROM [{Schema}].[{Name}] ({parameters})";
        return base.TryCompile(out command);
    }
}
