namespace Glitter.Sql;

/// <summary>
/// Represents an <see cref="Attribute"/> for marking types as SQL targets.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public sealed class SqlTargetAttribute : Attribute
{
    /// <summary>
    /// The name of the target.
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// The type of the target.
    /// </summary>
    public SqlTargetType? Type { get; private set; }
    /// <summary>
    /// Creates a new <see cref="SqlTargetAttribute"/> instance.
    /// </summary>
    /// <param name="name">The name of the target.</param>
    public SqlTargetAttribute(string name) =>
        Name = name;
    /// <summary>
    /// Creates a new <see cref="SqlTargetAttribute"/> instance.
    /// </summary>
    /// <param name="name">The name of the target.</param>
    /// <param name="type">The type of the target.</param>
    public SqlTargetAttribute(string name, SqlTargetType type) :
        this(name) =>
        Type = type;
}