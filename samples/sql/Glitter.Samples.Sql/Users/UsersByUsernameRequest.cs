using MediatR;

namespace Glitter.Samples.Sql.Users;

/// <summary>
/// Represents a request for <see cref="User"/>s with a username like a specified value.
/// </summary>
internal sealed class UsersByUsernameRequest : IRequest<IEnumerable<User>>
{
    /// <summary>
    /// The username to search for.
    /// </summary>
    public string Username { get; set; }
    /// <summary>
    /// Creates a new <see cref="UsersByUsernameRequest"/> instance.
    /// </summary>
    /// <param name="username">The username to search for.</param>
    /// <exception cref="ArgumentException"><paramref name="username"/> is <see langword="null"/> or whitespace.</exception>
    public UsersByUsernameRequest(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException($"The specified username `{username}` is invalid.");

        Username = username;
    }
}
