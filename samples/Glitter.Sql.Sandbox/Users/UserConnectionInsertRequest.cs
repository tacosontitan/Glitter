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

using Glitter.Sql.Encapsulation;

namespace Glitter.Sql.Sandbox.Users;

/// <summary>
/// Represents a request to insert a user connection.
/// </summary>
public class UserConnectionInsertRequest
    : SqlStoredProcedure
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserConnectionInsertRequest"/> class.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="userId"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="userId"/> is <see cref="Guid.Empty"/>.</exception>
    public UserConnectionInsertRequest(Guid? userId)
        : base(schema: "Sample", "UserConnectionInsert")
    {
        if (userId is null)
            throw new ArgumentNullException(nameof(userId), "The user identifier cannot be null.");

        if (userId == Guid.Empty)
            throw new ArgumentException("The user identifier cannot be empty.", nameof(userId));

        _ = AddParameter("UserId", userId);
    }

    /// <summary>
    /// Creates a new <see cref="UserConnectionInsertRequest"/> instance.
    /// </summary>
    /// <param name="user">The user to insert a new connection for.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="userId"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="userId"/> is <see cref="Guid.Empty"/>.</exception>
    public UserConnectionInsertRequest(User user)
        : this(user?.Id)
    { }
}
