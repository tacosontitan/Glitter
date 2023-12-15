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

using Glitter.Sql.Encapsulation;

namespace Glitter.Sql;

/// <summary>
/// Defines members for providing SQL services.
/// </summary>
public interface ISqlProvider
{
    /// <summary>
    /// The <see cref="ISqlConnection"/> used by this service for interacting with SQL.
    /// </summary>
    ISqlConnection? ConnectionDefinition { get; set; }

    /// <summary>
    /// Executes a request and returns the results.
    /// </summary>
    /// <param name="request">The <see cref="ISqlRequest"/> to execute.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <typeparam name="T">The type of the value to return.</typeparam>
    /// <returns>The results of the request.</returns>
    Task<IEnumerable<T>> Execute<T>(
        ISqlRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Executes a request and returns the number of rows affected.
    /// </summary>
    /// <param name="request">The <see cref="ISqlRequest"/> to execute.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>The number of rows affected.</returns>
    Task<int> ExecuteNonQuery(
        ISqlRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Executes a request and returns the first column of the first row in the result set returned.
    /// </summary>
    /// <param name="request">The <see cref="ISqlRequest"/> to execute.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <typeparam name="T">The type of the value to return.</typeparam>
    /// <returns>The first column of the first row in the result set.</returns>
    Task<T> ExecuteScalar<T>(
        ISqlRequest request,
        CancellationToken cancellationToken = default);
}