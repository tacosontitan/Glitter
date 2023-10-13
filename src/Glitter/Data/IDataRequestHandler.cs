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

namespace Glitter.Data;

/// <summary>
/// Represents a handler for a data request.
/// </summary>
/// <typeparam name="TProvider">Specifies the type of the data provider.</typeparam>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
public interface IDataRequestHandler<in TProvider, in TRequest>
    where TProvider : IDataProvider
    where TRequest : IRequest
{
    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="provider">The data provider for the request.</param>
    /// <param name="request">The request to handle.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Handle(TProvider provider, TRequest request, CancellationToken cancellationToken = default);
}

/// <summary>
/// Represents a handler for a data request.
/// </summary>
/// <typeparam name="TProvider">Specifies the type of the data provider.</typeparam>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IDataRequestHandler<in TProvider, in TRequest, TResponse>
    where TProvider : IDataProvider
    where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="provider">The data provider for the request.</param>
    /// <param name="request">The request to handle.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The response from the request.</returns>
    Task<TResponse> Handle(TProvider provider, TRequest request, CancellationToken cancellationToken = default);
}