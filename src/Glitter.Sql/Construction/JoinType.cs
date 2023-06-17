namespace Glitter.Sql.Construction;

/// <summary>
/// Specifies different types of joins.
/// </summary>
public enum JoinType
{
    /// <summary>
    /// Specifies that the join only includes rows where the joined table has a matching row.
    /// </summary>
    Inner,

    /// <summary>
    /// Specifies that the join includes all rows from the left table, even if there are no matches in the right table.
    /// </summary>
    Left,

    /// <summary>
    /// Specifies that the join includes all rows from the right table, even if there are no matches in the left table.
    /// </summary>
    Right,

    /// <summary>
    /// Specifies that the join includes all rows from both tables, even if there are no matches in the other table.
    /// </summary>
    Full
}
