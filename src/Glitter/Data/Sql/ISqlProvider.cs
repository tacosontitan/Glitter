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

using Glitter.Behaviors;

namespace Glitter.Data.Sql;

/// <summary>
/// Defines a handler for a SQL command.
/// </summary>
public interface ISqlProvider
    : IDataProvider
{
    /// <summary>
    /// Executes a non-query request.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to execute.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ExecuteNonQuery<TRequest>(
        TRequest request,
        CancellationToken cancellationToken = default)
        where TRequest : IRequest;

    /// <summary>
    /// Executes a query that returns a scalar value.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to execute.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The response from the request.</returns>
    Task<TResponse> ExecuteScalar<TResponse>(
        IRequest<TResponse> request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Executes a query.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to execute.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The response from the request.</returns>
    Task<IEnumerable<TResponse>> Query<TResponse>(
        IRequest<IEnumerable<TResponse>> request,
        CancellationToken cancellationToken = default);
}