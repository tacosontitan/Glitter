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

namespace Glitter.Data.Io;

/// <summary>
/// Represents a handler for a file scalar query.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IFileScalarQueryHandler<in TRequest, TResponse>
    : IDataRequestHandler<IFileProvider, TRequest, TResponse>
    where TRequest : IRequest<TResponse>;
    
/// <summary>
/// Represents a handler for a file scalar query.
/// </summary>
/// <typeparam name="TProvider">Specifies the type of the provider.</typeparam>
/// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
/// <typeparam name="TResponse">Specifies the type of the response.</typeparam>
public interface IFileScalarQueryHandler<in TProvider, in TRequest, TResponse>
    : IDataRequestHandler<TProvider, TRequest, TResponse>
    where TProvider : IFileProvider
    where TRequest : IRequest<TResponse>;