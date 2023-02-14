using System.Data;

using Glitter.Sql;

namespace Glitter.Samples.Sql.Users
{
    /// <summary>
    /// A <see cref="SqlFunction"/> representing the table valued function <c>UsersByUsernameQuery</c>.
    /// </summary>
    internal sealed class UsersByUsernameFunction : SqlFunction
    {
        /// <summary>
        /// Creates a new <see cref="UsersByUsernameFunction"/> instance.
        /// </summary>
        /// <param name="request">The request for invoking the function.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><see cref="UsersByUsernameRequest.Username"/> is <see langword="null"/> or whitespace.</exception>
        public UsersByUsernameFunction(UsersByUsernameRequest request) :
            base("UsersByUsernameQuery")
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Username))
                throw new ArgumentException($"The specified username `{request.Username}` is invalid.");

            _ = AddParameter("Username", request.Username, DbType.String, size: 50);
        }
    }
}
