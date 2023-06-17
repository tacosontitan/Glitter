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

namespace Glitter.Sql;

/// <summary>
/// Represents an <see cref="Attribute"/> for marking properties as SQL columns.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public sealed class SqlColumnAttribute :
    Attribute
{
    /// <summary>
    /// The name of the column.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// The type of the column.
    /// </summary>k
    public DbType? Type { get; private set; }

    /// <summary>
    /// The size of the column.
    /// </summary>
    public int? Size { get; private set; }

    /// <summary>
    /// The precision of the column.
    /// </summary>
    public byte? Precision { get; private set; }

    /// <summary>
    /// The scale of the column.
    /// </summary>
    public byte? Scale { get; private set; }

    /// <summary>
    /// Creates a new <see cref="SqlColumnAttribute"/> instance.
    /// </summary>
    /// <param name="name">The name of the column.</param>
    public SqlColumnAttribute(string name) =>
        Name = name;

    /// <summary>
    /// Creates a new <see cref="SqlColumnAttribute"/> instance.
    /// </summary>
    /// <param name="name">The name of the column.</param>
    /// <param name="type">The type of the column.</param>
    public SqlColumnAttribute(string name, DbType type) :
        this(name) =>
        Type = type;

    /// <summary>
    /// Creates a new <see cref="SqlColumnAttribute"/> instance.
    /// </summary>
    /// <param name="name">The name of the column.</param>
    /// <param name="type">The type of the column.</param>
    /// <param name="size">The size of the column.</param>
    public SqlColumnAttribute(string name, DbType type, int size) :
        this(name)
    {
        Type = type;
        Size = size;
    }

    /// <summary>
    /// Creates a new <see cref="SqlColumnAttribute"/> instance.
    /// </summary>
    /// <param name="name">The name of the column.</param>
    /// <param name="type">The type of the column.</param>
    /// <param name="precision">The precision of the column.</param>
    /// <param name="scale">The scale of the column.</param>
    public SqlColumnAttribute(string name, DbType type, byte precision, byte scale) :
        this(name)
    {
        Type = type;
        Precision = precision;
        Scale = scale;
    }

    /// <summary>
    /// Creates a new <see cref="SqlColumnAttribute"/> instance.
    /// </summary>
    /// <param name="name">The name of the column.</param>
    /// <param name="type">The type of the column.</param>
    /// <param name="size">The size of the column.</param>
    /// <param name="precision">The precision of the column.</param>
    /// <param name="scale">The scale of the column.</param>
    public SqlColumnAttribute(string name, DbType type, int size, byte precision, byte scale) :
        this(name)
    {
        Type = type;
        Size = size;
        Precision = precision;
        Scale = scale;
    }
}
