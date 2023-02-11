namespace Glitter.Sql;

/// <summary>
/// Represents an <see cref="Attribute"/> for marking properties as SQL columns.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public sealed class SqlColumnAttribute : Attribute
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