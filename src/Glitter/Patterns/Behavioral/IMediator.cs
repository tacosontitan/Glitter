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

namespace Glitter.Patterns.Behavioral;

/// <summary>
/// Represents a mediator.
/// </summary>
public interface IMediator
{
    /// <summary>
    /// Sends the specified request.
    /// </summary>
    /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
    /// <param name="request">The request to send.</param>
    /// <param name="cancellationToken">A cancellation token to support cancellation of the request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Send<TRequest>(IRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;

    /// <summary>
    /// Sends the specified request.
    /// </summary>
    /// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
    /// <param name="request">The request to send.</param>
    /// <param name="cancellationToken">A cancellation token to support cancellation of the request.</param>
    /// <returns>The result of the request.</returns>
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}