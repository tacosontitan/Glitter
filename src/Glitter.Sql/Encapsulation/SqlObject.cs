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
/// Represents an object within SQL.
/// </summary>
public class SqlObject
    : ISqlObject
{
    /// <summary>
    /// Creates a new <see cref="SqlObject"/> instance.
    /// </summary>
    /// <param name="name">The name of the object.</param>
    /// <exception cref="ArgumentException"><paramref name="name"/> is null or whitespace.</exception>
    protected SqlObject(string name) : this(
        schema: "dbo",
        name: name
    ) { }

    /// <summary>
    /// Creates a new <see cref="SqlObject"/> instance.
    /// </summary>
    /// <param name="schema">The schema for the object.</param>
    /// <param name="name">The name of the object.</param>
    /// <exception cref="ArgumentException"><paramref name="name"/> is null or whitespace.</exception>
    protected SqlObject(string schema, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("The name of the object cannot be null or whitespace.");

        Name = name;
        Schema = string.IsNullOrWhiteSpace(schema)
            ? "dbo"
            : schema;
    }

    /// <summary>
    /// Gets the schema for the object.
    /// </summary>
    public string Schema { get; }

    /// <summary>
    /// Gets the name of the object.
    /// </summary>
    public string Name { get; }
}