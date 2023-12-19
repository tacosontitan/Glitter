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

namespace Glitter.Data.Sql;

/// <summary>
/// Represents a stored procedure within SQL.
/// </summary>
public class SqlStoredProcedure
    : DefinedSqlRequest
{
    /// <summary>
    /// Creates a new <see cref="SqlStoredProcedure"/> instance.
    /// </summary>
    /// <param name="name">The name of the stored procedure.</param>
    protected SqlStoredProcedure(string name)
        : base(
            "dbo",
            name,
            System.Data.CommandType.StoredProcedure)
    {
    }

    /// <summary>
    /// Creates a new <see cref="SqlStoredProcedure"/> instance.
    /// </summary>
    /// <param name="schema">The schema of the stored procedure.</param>
    /// <param name="name">The name of the stored procedure.</param>
    protected SqlStoredProcedure(
        string schema,
        string name)
        : base(
            schema,
            name,
            System.Data.CommandType.StoredProcedure)
    {
    }

    /// <inheritdoc/>
    public override bool TryCompile(out string? command)
    {
        string parameters = string.Join(", ", Parameters.Select(x => $"@{x.Name}"));
        Command = $"[{Schema}].[{Name}] ({parameters})";
        return base.TryCompile(out command);
    }
}