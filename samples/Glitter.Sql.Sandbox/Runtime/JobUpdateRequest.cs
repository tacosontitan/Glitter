using System.Data;

using Glitter.Sql.Encapsulation;

namespace Glitter.Sql.Sandbox.Runtime;

/// <summary>
/// Represents a request to update an existing job.
/// </summary>
public class JobUpdateRequest
    : SqlStoredProcedure
{
    /// <summary>
    /// Creates a new <see cref="JobUpdateRequest"/> instance.
    /// </summary>
    /// <param name="job">The job to update.</param>
    public JobUpdateRequest(Job job) : this(
        id: job?.Id,
        name: job?.Name,
        displayName: job?.DisplayName,
        description: job?.Description
    ) { }

    /// <summary>
    /// Creates a new <see cref="JobUpdateRequest"/> instance.
    /// </summary>
    /// <param name="id">The unique identifier of the job.</param>
    /// <param name="name">The name of the job.</param>
    /// <param name="displayName">The display name of the job.</param>
    /// <param name="description">The description of the job.</param>
    public JobUpdateRequest(
        Guid? id,
        string? name,
        string? displayName,
        string? description)
        : base("Sample", "JobUpdate")
    {
        _ = AddParameter("Id", id, DbType.Guid);
        _ = AddParameter("Name", name, DbType.String, size: 500);
        _ = AddParameter("DisplayName", displayName, DbType.String, size: 500);
        _ = AddParameter("Description", description, DbType.String, size: 2500);
    }
}
