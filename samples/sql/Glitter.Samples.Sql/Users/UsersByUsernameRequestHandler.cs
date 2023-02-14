using Glitter.Samples.Sql.Sql;
using Glitter.Sql;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Glitter.Samples.Sql.Users;

/// <summary>
/// Represents an <see cref="IRequestHandler{TRequest, TResponse}"/> for <see cref="UsersByUsernameRequest"/>s.
/// </summary>
internal sealed class UsersByUsernameRequestHandler : IRequestHandler<UsersByUsernameRequest, IEnumerable<User>>
{
    private readonly ILogger _logger;
    private readonly SqlService _sqlService;
    /// <summary>
    /// Creates a new <see cref="UsersByUsernameRequestHandler"/> instance.
    /// </summary>
    /// <param name="sqlService">The <see cref="SqlService"/> to handle the request with.</param>
    /// <param name="logger">The <see cref="ILogger"/> for recording information about processing.</param>
    public UsersByUsernameRequestHandler(SampleSqlService sqlService, ILogger<UsersByUsernameRequestHandler> logger)
    {
        _logger = logger;
        _sqlService = sqlService;
    }
    /// <summary>
    /// Handles the incoming <see cref="UsersByUsernameRequest"/>.
    /// </summary>
    /// <param name="request">The <see cref="UsersByUsernameRequest"/> to handle.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> for canceling the operation.</param>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public Task<IEnumerable<User>> Handle(UsersByUsernameRequest request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            _logger.LogDebug("Cancellation requested, canceling.");
            return Task.FromResult(Enumerable.Empty<User>());
        }

        if (!TryValidate(request))
            return Task.FromResult(Enumerable.Empty<User>());

        try
        {

            var function = new UsersByUsernameFunction(request);
            return _sqlService.Query<User>(function);
        } catch (Exception e)
        {
            _logger.LogError($"Unable to process the query request for the username `{request.Username}`. {e.Message}");
            return Task.FromResult(Enumerable.Empty<User>());
        }
    }
    /// <summary>
    /// Attempt to validate the state of the handler and the incoming request.
    /// </summary>
    /// <param name="request">The incoming request to validate.</param>
    /// <returns><see langword="true"/> if the handler and request are in a valid state to attempt processing, otherwise <see langword="false"/>.</returns>
    private bool TryValidate(UsersByUsernameRequest request)
    {
        if (_logger is null)
            return false;

        if (_sqlService is null)
        {
            _logger.LogError("Unable to process user query due to the lack of a SQL service.");
            return false;
        }

        if (request is null)
        {
            _logger.LogError("Unable to process an unspecified request.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(request.Username))
        {
            _logger.LogError($"The specified username `{request.Username}` cannot be `null` or whitespace.");
            return false;
        }

        return true;
    }
}
