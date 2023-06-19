using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glitter.Sql.Attributes;

/// <summary>
/// Defines a foreign key attribute.
/// </summary>
public interface IForeignKeyAttribute
{
    /// <summary>
    /// Gets or sets the name of the column to which the foreign key refers.
    /// </summary>
    public string ColumnName { get; set; }

    /// <summary>
    /// Gets or sets the type of the table containing the foreign key.
    /// </summary>
    public Type ContainingTableType { get; set; }
}
