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

namespace Glitter.Sql;

/// <summary>
/// Represents information about a connection to a SQL database.
/// </summary>
public class ConnectionInformation
    : IConnectionInformation
{
    /// <summary>
    /// Should the connection use integrated security?
    /// </summary>
    public bool IntegratedSecurity { get; set; }

    /// <summary>
    /// The server to connect to.
    /// </summary>
    public string? Server { get; set; }

    /// <summary>
    /// The database to connect to.
    /// </summary>
    public string? Database { get; set; }

    /// <summary>
    /// The username to use when connecting.
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// The password to use when connecting.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// The amount of time to wait for a connection to be established.
    /// </summary>
    /// <value></value>
    public TimeSpan? ConnectionTimeout { get; set; }

    /// <summary>
    /// The amount of time to wait for a command to execute.
    /// </summary>
    /// <value></value>
    public TimeSpan? CommandTimeout { get; set; }

    /// <summary>
    /// Creates a new <see cref="ConnectionInformation"/> with the specified values.
    /// </summary>
    /// <param name="integratedSecurity">Should the connection use integrated security?</param>
    /// <param name="server">The server to connect to.</param>
    /// <param name="database">The database to connect to.</param>
    /// <param name="username">The username to use when connecting.</param>
    /// <param name="password">The password to use when connecting.</param>
    /// <param name="connectionTimeout">The amount of time to wait for a connection to be established.</param>
    /// <param name="commandTimeout">The amount of time to wait for a command to execute.</param>
    public ConnectionInformation(
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
}
