using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glitter.Sql.Attributes;

/// <summary>
/// Defines a SQL column attribute.
/// </summary>
public interface ISqlColumnAttribute
{
    /// <summary>
    /// Gets the name of the column.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the type of the column.
    /// </summary>
    DbType? Type { get; }

    /// <summary>
    /// Gets the size of the column.
    /// </summary>
    int? Size { get; }

    /// <summary>
    /// Gets the precision of the column.
    /// </summary>
    byte? Precision { get; }

    /// <summary>
    /// Gets the scale of the column.
    /// </summary>
    byte? Scale { get; }
}
