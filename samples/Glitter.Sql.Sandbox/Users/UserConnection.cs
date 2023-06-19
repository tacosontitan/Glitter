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

using Glitter.Sql.Attributes;

namespace Glitter.Sql.Sandbox.Users;

/// <summary>
/// Represents a user's connection to the sandbox.
/// </summary>
[SqlTable(schema: "Sample", name: "UserConnections")]
public class UserConnection
    : DatabaseRecord
{
    /// <summary>
    /// Gets or sets whether or not the connection is active.
    /// </summary>
    [SqlColumn("IsActive", DbType.Boolean)]
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the connection.
    /// </summary>
    [SqlColumn("Id", DbType.Guid)]
    public Guid? Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// </summary>
    [SqlColumn("UserId", DbType.Guid)]
    [ForeignKey(typeof(User), nameof(User.Id))]
    public Guid? UserId { get; set; }
}
