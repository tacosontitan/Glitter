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

namespace Glitter.Sql.Sandbox.Users;

/// <summary>
/// Represents a user in the sandbox.
/// </summary>
public class User
    : DatabaseRecord
{
    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// </summary>
    public Guid? Id { get; set; }

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the given name of the user.
    /// </summary>
    public string? GivenName { get; set; }

    /// <summary>
    /// Gets or sets the surname of the user.
    /// </summary>
    public string? Surname { get; set; }
}