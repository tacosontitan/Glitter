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
/// Represents a service for interacting with SQL.
/// </summary>
public abstract class SqlService
{
    /// <summary>
    /// The <see cref="Sql.ConnectionInformation"/> used by this service for interacting with SQL.
    /// </summary>
    protected ConnectionInformation? ConnectionInformation { get; set; }
    /// <summary>
    /// Creates a new <see cref="SqlService"/> with the specified <see cref="ISqlProvider"/>.
    /// </summary>
    /// <param name="connectionInformation">The <see cref="Sql.ConnectionInformation"/> used by this service for interacting with SQL.</param>
    public SqlService(ConnectionInformation connectionInformation) =>
        ConnectionInformation = connectionInformation;
    /// <summary>
    /// Executes the specified <see cref="SqlRequest"/> as a query and returns the results.
    /// </summary>
    /// <param name="request">The request to execute.</param>
    /// <typeparam name="T">Specifies the expected return type.</typeparam>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public abstract Task<IEnumerable<T>> Query<T>(SqlRequest request);
    /// <summary>
    /// Executes the specified <see cref="SqlRequest"/> as a query and returns the first column of the first row in the result set returned by the query.
    /// </summary>
    /// <param name="request">The request to execute.</param>
    /// <typeparam name="T">Specifies the expected return type.</typeparam>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public abstract Task<T> ExecuteScalar<T>(SqlRequest request);
    /// <summary>
    /// Executes the specified <see cref="SqlRequest"/>.
    /// </summary>
    /// <param name="request">The request to execute.</param>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public abstract Task Execute(SqlRequest request);
}