using System.Reflection;

namespace Glitter.Sql;

public sealed class SqlQueryBuilder
{
    private SqlQueryBuilder() { }
    /// <summary>
    /// Creates a new <see cref="SqlQueryBuilder"/> instance.
    /// </summary>
    public static SqlQueryBuilder Create() => new();
    /// <summary>
    /// Specifies the target of the query.
    /// </summary>
    /// <param name="alias">The alias of the target.</param>
    /// <returns>A <see cref="SqlTargetSelector"/> instance to continue the build process with.</returns>
    public SqlTargetSelector From<T>(string? alias = null) {
        var type = typeof(T);
        var attribute = type.GetCustomAttribute<SqlTargetAttribute>();
        if (attribute is null)
            throw new InvalidOperationException("The specified type does not have a SqlTargetAttribute.");

        return new SqlTargetSelector(attribute.Name, alias);
    }
        /// <summary>
    /// Specifies the target of the query.
    /// </summary>
    /// <param name="target">The name of the target.</param>
    /// <param name="alias">The alias of the target.</param>
    /// <returns>A <see cref="SqlTargetSelector"/> instance to continue the build process with.</returns>
    public SqlTargetSelector From(string target, string? alias = null) =>
        new SqlTargetSelector(target, alias);
}