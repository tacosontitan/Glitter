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

namespace Glitter.Sql.Sandbox;

/// <summary>
/// Represents a record in the database.
/// </summary>
public class DatabaseRecord
{
    /// <summary>
    /// Gets or sets the date and time the record was inserted.
    /// </summary>
    [SqlColumn("InsertDate", DbType.DateTimeOffset)]
    public DateTimeOffset? InsertDate { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user inserted the record.
    /// </summary>
    [SqlColumn("InsertedBy", DbType.Guid)]
    public Guid? InsertedBy { get; set; }

    /// <summary>
    /// Gets or sets the date and time the record was last updated.
    /// </summary>
    [SqlColumn("UpdateDate", DbType.DateTimeOffset)]
    public DateTimeOffset? UpdateDate { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user updated the record.
    /// </summary>
    [SqlColumn("UpdatedBy", DbType.Guid)]
    public Guid? UpdatedBy { get; set; }
}
