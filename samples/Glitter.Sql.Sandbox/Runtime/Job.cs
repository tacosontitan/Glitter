using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Glitter.Sql.Attributes;

namespace Glitter.Sql.Sandbox.Runtime;

/// <summary>
/// Represents a job in the sandbox.
/// </summary>
[SqlTable(schema: "Sample", name: "Jobs")]
public class Job
    : DatabaseRecord
{
    /// <summary>
    /// Creates a new <see cref="Job"/> instance.
    /// </summary>
    /// <param name="name">The name of the job.</param>
    /// <param name="displayName">The display name of the job.</param>
    /// <param name="description">The description of the job.</param>
    public Job(
        string name,
        string displayName,
        string description)
    {
        Name = name;
        DisplayName = displayName;
        Description = description;
    }

    /// <summary>
    /// Gets or sets the unique identifier of the job.
    /// </summary>
    [PrimaryKey]
    [SqlColumn("Id", DbType.Guid)]
    public Guid? Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the job.
    /// </summary>
    [SqlColumn("Name", DbType.String, size: 500)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the display name of the job.
    /// </summary>
    [SqlColumn("DisplayName", DbType.String, size: 500)]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the description of the job.
    /// </summary>
    [SqlColumn("Description", DbType.String, size: 2500)]
    public string? Description { get; set; }
}
