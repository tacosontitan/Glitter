using System.Data;

using Glitter.Sql.Encapsulation;

namespace Glitter.Sql.Sandbox.Runtime;

/// <summary>
/// Represents a request to register a new job.
/// </summary>
public class JobInsertRequest
    : SqlStoredProcedure
{
    /// <summary>
    /// Creates a new <see cref="JobInsertRequest"/> instance.
    /// </summary>
    /// <param name="job">The job to register.</param>
    public JobInsertRequest(Job job) : this(
        name: job?.Name,
        displayName: job?.DisplayName,
        description: job?.Description
    ) { }

    /// <summary>
    /// Creates a new <see cref="JobInsertRequest"/> instance.
    /// </summary>
    /// <param name="name">The name of the job.</param>
    /// <param name="displayName">The display name of the job.</param>
    /// <param name="description">The description of the job.</param>
    protected JobInsertRequest(
        string? name,
        string? displayName,
        string? description)
        : base("Sample", "JobInsert")
    {
        _ = AddParameter("Name", name, DbType.String, size: 500);
        _ = AddParameter("DisplayName", displayName, DbType.String, size: 500);
        _ = AddParameter("Description", description, DbType.String, size: 2500);
    }
}
