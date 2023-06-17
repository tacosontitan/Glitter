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

namespace Glitter.Sql.Encapsulation;

/// <summary>
/// Defines a request for interacting with SQL.
/// </summary>
public interface ISqlRequest
{
    /// <summary>
    /// The type of command to execute.
    /// </summary>
    CommandType CommandType { get; set; }
    
    /// <summary>
    /// The parameters for the command.
    /// </summary>
    ICollection<SqlRequestParameter> Parameters { get; }

    /// <summary>
    /// Adds a parameter to the request.
    /// </summary>
    /// <param name="name">The name of the parameter.</param>
    /// <param name="value">The value of the parameter.</param>
    /// <param name="type">The <see cref="DbType"/> of the parameter.</param>
    /// <param name="direction">The direction of the parameter.</param>
    /// <param name="size">The size of the parameter.</param>
    /// <param name="precision">The precision of the parameter.</param>
    /// <param name="scale">The scale of the parameter.</param>
    /// <typeparam name="T">Specifies the type of the parameter.</typeparam>
    /// <returns>The <see cref="ISqlRequest"/> instance.</returns>
    ISqlRequest AddParameter<T>(
        string name,
        T? value,
        DbType? type = null,
        ParameterDirection? direction = null,
        int? size = null,
        byte? precision = null,
        byte? scale = null
    );

    /// <summary>
    /// Attempts to compile the request into a command.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <returns><see langword="true"/> if the request was successfully compiled; otherwise, <see langword="false"/>.</returns>
    bool TryCompile(out string? command);
}
