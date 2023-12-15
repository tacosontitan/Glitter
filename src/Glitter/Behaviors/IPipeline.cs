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

namespace Glitter.Behaviors;

/// <summary>
/// Represents a pipeline for processing requests.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
public interface IPipeline<in TRequest>
{
    /// <summary>
    /// Processes the specified request.
    /// </summary>
    /// <param name="request">The request to process.</param>
    /// <param name="cancellationToken">A token for cancelling the request.</param>
    /// <returns>A task that represents the asynchronous processing operation.</returns>
    Task Process(TRequest request, CancellationToken cancellationToken = default);
}

/// <summary>
/// Represents a pipeline for processing requests.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IPipeline<in TRequest, TResponse>
{
    /// <summary>
    /// Processes the specified request.
    /// </summary>
    /// <param name="request">The request to process.</param>
    /// <param name="cancellationToken">A token for cancelling the request.</param>
    /// <returns>A task that represents the asynchronous processing operation.</returns>
    Task<TResponse> Process(TRequest request, CancellationToken cancellationToken = default);
}