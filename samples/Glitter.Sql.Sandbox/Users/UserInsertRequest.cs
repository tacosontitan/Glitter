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
using Glitter.Data.Sql;

namespace Glitter.Sql.Sandbox.Users;

public class UserInsertRequest
    : SqlStoredProcedure
{
    /// <summary>
    /// Creates a new <see cref="UserInsertRequest"/> instance.
    /// </summary>
    /// <param name="user">The user to insert.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="user"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="user"/> has a null, empty, or whitespace username, given name, or surname.</exception>
    public UserInsertRequest(User user) : this(
        user.Username,
        user.GivenName,
        user.Surname
    )
    {
    }

    /// <summary>
    /// Creates a new <see cref="UserInsertRequest"/> instance.
    /// </summary>
    /// <param name="username">The username of the user to insert.</param>
    /// <param name="givenName">The given name of the user to insert.</param>
    /// <param name="surname">The surname of the user to insert.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="username"/>, <paramref name="givenName"/>, or <paramref name="surname"/> is null, empty, or whitespace.</exception>
    public UserInsertRequest(string? username, string? givenName, string? surname) :
        base("Sample", "UserInsert")
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("The username of the user to insert cannot be null, empty, or whitespace.",
                nameof(username));

        if (string.IsNullOrWhiteSpace(givenName))
            throw new ArgumentException("The given name of the user to insert cannot be null, empty, or whitespace.",
                nameof(givenName));

        if (string.IsNullOrWhiteSpace(surname))
            throw new ArgumentException("The surname of the user to insert cannot be null, empty, or whitespace.",
                nameof(surname));

        _ = AddParameter("Username", username, DbType.String, size: 100);
        _ = AddParameter("GivenName", givenName, DbType.String, size: 100);
        _ = AddParameter("Surname", surname, DbType.String, size: 100);
    }
}