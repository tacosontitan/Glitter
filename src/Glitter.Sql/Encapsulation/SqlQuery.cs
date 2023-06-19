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
/// Represents a SQL query.
/// </summary>
public class SqlQuery
    : SqlRequest
{
    /// <summary>
    /// Creates a new <see cref="SqlQuery"/> instance.
    /// </summary>
    /// <param name="query">The query to execute in the request.</param>
    public SqlQuery(string query)
        : base(query, CommandType.Text)
    { }
}
