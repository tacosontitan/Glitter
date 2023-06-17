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
/// Represents a defined request for interacting with SQL.
/// </summary>
public class DefinedSqlRequest :
    SqlRequest,
    ISqlObject
{
    /// <summary>
    /// Creates a new <see cref="DefinedSqlRequest"/> instance.
    /// </summary>
    /// <param name="schema">The schema of the object.</param>
    /// <param name="name">The name of the object.</param>
    /// <param name="commandType">The type of command to execute.</param>
    protected DefinedSqlRequest(
        string schema,
        string name,
        CommandType commandType) :
        base(commandType)
    {
        Schema = schema;
        Name = name;
    }

    /// <inheritdoc/>
    public string Schema { get; }

    /// <inheritdoc/>
    public string Name { get; }
}
