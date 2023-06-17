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
public class UserUpdateRequest :
    SqlStoredProcedure
{
    /// <summary>
    /// Creates a new <see cref="UserUpdateRequest"/> instance.
    /// </summary>
    /// <param name="senderId">The unique identifier of the user sending the request.</param>
    /// <param name="user">The user to update.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="user"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="senderId"/> or <paramref name="user"/> has an empty unique identifier.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="user"/> has a null, empty, or whitespace given name or surname.</exception>
    public UserUpdateRequest(User user) : this(
        userId: user.Id,
        givenName: user.GivenName,
        surname: user.Surname
    ) { }

    /// <summary>
    /// Creates a new <see cref="UserUpdateRequest"/> instance.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to update.</param>
    /// <param name="givenName">The given name of the user to update.</param>
    /// <param name="surname">The surname of the user to update.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="userId"/> has an empty unique identifier.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="givenName"/> or <paramref name="surname"/> is null, empty, or whitespace.</exception>
    public UserUpdateRequest(Guid? userId, string? givenName, string? surname) :
        base(schema: "Sample", name: "UserUpdate")
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("The unique identifier of the user cannot be empty.", nameof(userId));

        if (string.IsNullOrWhiteSpace(givenName))
            throw new ArgumentException("The given name of the user cannot be null, empty, or whitespace.", nameof(givenName));

        if (string.IsNullOrWhiteSpace(surname))
            throw new ArgumentException("The surname of the user cannot be null, empty, or whitespace.", nameof(surname));

        _ = AddParameter("UserId", userId, type: DbType.Guid);
        _ = AddParameter("GivenName", givenName, type: DbType.String, size: 100);
        _ = AddParameter("Surname", surname, type: DbType.String, size: 100);
    }
}
