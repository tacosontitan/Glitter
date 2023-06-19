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
/// Represents an <see cref="Attribute"/> for marking properties as foreign keys.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class ForeignKeyAttribute
    : Attribute
{
    /// <summary>
    /// Creates a new <see cref="ForeignKeyAttribute"/> instance.
    /// </summary>
    /// <param name="containingTableType">The type of the table containing the foreign key.</param>
    /// <param name="columnName">The name of the column to which the foreign key refers.</param>
    public ForeignKeyAttribute(
        Type containingTableType,
        string columnName)
    {
        ContainingTableType = containingTableType;
        ColumnName = columnName;
    }

    /// <summary>
    /// Gets or sets the name of the column to which the foreign key refers.
    /// </summary>
    public string ColumnName { get; set; }

    /// <summary>
    /// Gets or sets the type of the table containing the foreign key.
    /// </summary>
    public Type ContainingTableType { get; set; }
}
