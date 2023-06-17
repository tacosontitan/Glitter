/*
   Copyright 2023 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System.Data;

using Glitter.Sql.Encapsulation;

namespace Glitter.Sql.Sandbox.Users;

/// <summary>
/// Represents a request to update a user.
/// </summary>
public class UserUpdateRequest : SqlProcedure
{
    /// <summary>
    /// Creates a new <see cref="UserUpdateRequest"/> instance.
    /// </summary>
    /// <param name="senderId">The unique identifier of the user sending the request.</param>
    /// <param name="user">The user to update.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="user"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="senderId"/> or <paramref name="user"/> has an empty unique identifier.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="user"/> has a null, empty, or whitespace given name or surname.</exception>
    public UserUpdateRequest(Guid senderId, User user) :
        base(procedureName: "UserUpdate")
    {
        if (senderId == Guid.Empty)
            throw new ArgumentException("The unique identifier of the sender cannot be empty.", nameof(senderId));

        if (user is null)
            throw new ArgumentNullException(nameof(user), "The user cannot be null.");

        if (user.Id == Guid.Empty)
            throw new ArgumentException("The unique identifier of the user cannot be empty.", nameof(user));

        if (string.IsNullOrWhiteSpace(user.GivenName))
            throw new ArgumentException("The given name of the user cannot be null, empty, or whitespace.", nameof(user));

        if (string.IsNullOrWhiteSpace(user.Surname))
            throw new ArgumentException("The surname of the user cannot be null, empty, or whitespace.", nameof(user));

        _ = AddParameter("SenderId", senderId, type: DbType.Guid);
        _ = AddParameter("UserId", user.Id, type: DbType.Guid);
        _ = AddParameter("GivenName", user.GivenName, type: DbType.String, size: 100);
        _ = AddParameter("Surname", user.Surname, type: DbType.String, size: 100);
    }
}
