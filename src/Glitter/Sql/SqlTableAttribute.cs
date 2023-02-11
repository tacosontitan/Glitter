namespace Glitter.Sql;

/// <summary>
/// Represents an <see cref="Attribute"/> for marking types as SQL targets.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public sealed class SqlTableAttribute : Attribute
{
    /// <summary>
    /// The name of the table.
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Creates a new <see cref="SqlTargetAttribute"/> instance.
    /// </summary>
    /// <param name="name">The name of the target.</param>
    public SqlTableAttribute(string name) =>
        Name = name;
}