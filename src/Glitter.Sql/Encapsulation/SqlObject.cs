using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glitter.Sql.Encapsulation;

/// <summary>
/// Represents an object within SQL.
/// </summary>
public abstract class SqlObject
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