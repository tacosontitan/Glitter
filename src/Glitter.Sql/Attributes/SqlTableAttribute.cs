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

namespace Glitter.Sql.Attributes;

/// <summary>
/// Represents an <see cref="Attribute"/> for marking types as SQL targets.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public sealed class SqlTableAttribute
    : Attribute
{
    /// <summary>
    /// Creates a new <see cref="SqlTableAttribute"/> instance.
    /// </summary>
    /// <param name="name">The name of the table.</param>
    public SqlTableAttribute(string name)
        : this(schema: "dbo", name)
    { }

    /// <summary>
    /// Creates a new <see cref="SqlTableAttribute"/> instance.
    /// </summary>
    /// <param name="schema">The schema of the table.</param>
    /// <param name="name">The name of the table.</param>
    public SqlTableAttribute(string schema, string name)
    {
        Schema = schema;
        Name = name;
    }

    /// <summary>
    /// Gets or sets the name of the table.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the schema of the table.
    /// </summary>
    public string Schema { get; set; }
}
