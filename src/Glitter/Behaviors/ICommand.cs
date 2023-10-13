namespace Glitter.Behaviors;

/// <summary>
/// Represents a command.
/// </summary>
public interface ICommand
{
    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to support cancellation of the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Execute(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Rolls back the command.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to support cancellation of the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Rollback(CancellationToken cancellationToken = default);
}
