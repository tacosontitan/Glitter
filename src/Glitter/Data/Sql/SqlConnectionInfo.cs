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
/// Represents information about a connection to a SQL database.
/// </summary>
public class SqlConnectionInfo
    : ISqlConnection
{
    /// <summary>
    /// Creates a new <see cref="SqlConnectionInfo"/> with the specified values.
    /// </summary>
    /// <param name="integratedSecurity">Should the connection use integrated security?</param>
    /// <param name="server">The server to connect to.</param>
    /// <param name="database">The database to connect to.</param>
    /// <param name="username">The username to use when connecting.</param>
    /// <param name="password">The password to use when connecting.</param>
    /// <param name="connectionTimeout">The amount of time to wait for a connection to be established.</param>
    /// <param name="commandTimeout">The amount of time to wait for a command to execute.</param>
    public SqlConnectionInfo(
        bool? integratedSecurity = null,
        string? server = null,
        string? database = null,
        string? username = null,
        string? password = null,
        TimeSpan? connectionTimeout = null,
        TimeSpan? commandTimeout = null)
    {
        IntegratedSecurity = integratedSecurity ?? false;
        Server = server;
        Database = database;
        Username = username;
        Password = password;
        ConnectionTimeout = connectionTimeout;
        CommandTimeout = commandTimeout;
    }

    /// <inheritdoc/>
    public bool IntegratedSecurity { get; set; }

    /// <inheritdoc/>
    public string? Server { get; set; }

    /// <inheritdoc/>
    public string? Database { get; set; }

    /// <inheritdoc/>
    public string? Username { get; set; }

    /// <inheritdoc/>
    public string? Password { get; set; }

    /// <inheritdoc/>
    public TimeSpan? ConnectionTimeout { get; set; }

    /// <inheritdoc/>
    public TimeSpan? CommandTimeout { get; set; }
}