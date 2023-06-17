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
/// Represents a procedure within SQL.
/// </summary>
public class SqlProcedure :
    SqlRequest
{
    /// <summary>
    /// Creates a new <see cref="SqlProcedure"/> instance.
    /// </summary>
    /// <param name="procedureName">The name of the procedure.</param>
    public SqlProcedure(string procedureName) :
        base(procedureName, CommandType.StoredProcedure)
    { }
}
