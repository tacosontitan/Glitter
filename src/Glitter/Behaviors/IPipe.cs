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
/// Represents a pipe in a pipeline.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
public interface IPipe<in TRequest>
    where TRequest : IRequest
{
    /// <summary>
    /// Gets the next pipe in the pipeline.
    /// </summary>
    IPipe<TRequest> Successor { get; }
    
    /// <summary>
    /// Processes the specified request.
    /// </summary>
    Task Process(TRequest request, CancellationToken cancellationToken = default);
}

/// <summary>
/// Represents a pipe in a pipeline.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IPipe<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Gets the next pipe in the pipeline.
    /// </summary>
    IPipe<TRequest, TResponse> Successor { get; }
    
    /// <summary>
    /// Processes the specified request.
    /// </summary>
    Task<TResponse> Process(TRequest request, CancellationToken cancellationToken = default);
}
