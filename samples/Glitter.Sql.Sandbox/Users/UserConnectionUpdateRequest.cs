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

/// <summary>
/// Represents a request to update a user connection.
/// </summary>
public class UserConnectionUpdateRequest
    : SqlStoredProcedure
{
    /// <summary>
    /// Creates a new <see cref="UserConnectionUpdateRequest"/> instance.
    /// </summary>
    /// <param name="connectionId">The unique identifier of the connection.</param>
    /// <param name="isActive">Whether or not the connection is active.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="connectionId"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="connectionId"/> is <see cref="Guid.Empty"/>.</exception>
    public UserConnectionUpdateRequest(Guid? connectionId, bool? isActive)
        : base("Sample", "UserConnectionUpdate")
    {
        if (connectionId is null)
            throw new ArgumentNullException(nameof(connectionId), "The connection identifier cannot be null.");

        if (connectionId == Guid.Empty)
            throw new ArgumentException("The connection identifier cannot be empty.", nameof(connectionId));

        _ = AddParameter("ConnectionId", connectionId, DbType.Guid);
        _ = AddParameter("IsActive", isActive, DbType.Boolean);
    }

    /// <summary>
    /// Creates a new <see cref="UserConnectionUpdateRequest"/> instance.
    /// </summary>
    /// <param name="connection">The connection to update.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="connectionId"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="connectionId"/> is <see cref="Guid.Empty"/>.</exception>
    public UserConnectionUpdateRequest(UserConnection connection)
        : this(connection?.Id, connection?.IsActive)
    {
    }
}