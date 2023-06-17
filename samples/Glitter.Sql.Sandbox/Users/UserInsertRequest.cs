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

public class UserInsertRequest : SqlProcedure
{
    /// <summary>
    /// Creates a new <see cref="UserInsertRequest"/> instance.
    /// </summary>
    /// <param name="senderId">The unique identifier of the user sending the request.</param>
    /// <param name="userToInsert">The user to insert.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="userToInsert"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="userToInsert"/> has a null, empty, or whitespace username, given name, or surname.</exception>
    public UserInsertRequest(Guid senderId, User userToInsert) :
        base(procedureName: "UserInsert")
    {
        if (userToInsert is null)
            throw new ArgumentNullException(nameof(userToInsert), "The user to insert cannot be null.");

        if (string.IsNullOrWhiteSpace(userToInsert.Username))
            throw new ArgumentException("The username of the user to insert cannot be null, empty, or whitespace.", nameof(userToInsert));

        if (string.IsNullOrWhiteSpace(userToInsert.GivenName))
            throw new ArgumentException("The given name of the user to insert cannot be null, empty, or whitespace.", nameof(userToInsert));

        if (string.IsNullOrWhiteSpace(userToInsert.Surname))
            throw new ArgumentException("The surname of the user to insert cannot be null, empty, or whitespace.", nameof(userToInsert));

        _ = AddParameter("SenderId", senderId, type: DbType.Guid);
        _ = AddParameter("Username", userToInsert.Username, type: DbType.String, size: 100);
        _ = AddParameter("GivenName", userToInsert.GivenName, type: DbType.String, size: 100);
        _ = AddParameter("Surname", userToInsert.Surname, type: DbType.String, size: 100);
    }
}
