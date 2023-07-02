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
using Microsoft.Extensions.Logging;

namespace Glitter.Sql.Sandbox.Diagnostics;

/// <summary>
/// Represents a log entry.
/// </summary>
[SqlTable(schema: "Sample", name: "Logs")]
public class LogEntry
    : DatabaseRecord
{
    /// <summary>
    /// Gets or sets the ID of the log entry.
    /// </summary>
    [PrimaryKey]
    [SqlColumn("Id", DbType.Int32)]
    public int? Id { get; set; }

    /// <summary>
    /// Gets or sets the level of the log entry.
    /// </summary>
    [SqlColumn("Level", DbType.String, size: 16)]
    public LogLevel? Level { get; set; }

    /// <summary>
    /// Gets or sets the subject of the log entry.
    /// </summary>
    [SqlColumn("Subject", DbType.String, size: 256)]
    public string? Subject { get; set; }

    /// <summary>
    /// Gets or sets the message of the log entry.
    /// </summary>
    [SqlColumn("Message", DbType.String, size: int.MaxValue)]
    public string? Message { get; set; }
}
