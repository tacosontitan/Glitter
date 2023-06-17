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
/// Represents a query request for a user by their unique identifier.
/// </summary>
public class UserQueryByIdRequest :
    TableValuedSqlFunction
{
    /// <summary>
    /// Creates a new <see cref="UserQueryByIdRequest"/> instance.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to query.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="userId"/> has an empty unique identifier.</exception>
    public UserQueryByIdRequest(Guid? userId) : base(
        schema: "Sample",
        functionName: "UserQueryById")
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("The unique identifier of the user cannot be empty.", nameof(userId));

        _ = AddParameter("UserId", userId, type: DbType.Guid);
    }
}
