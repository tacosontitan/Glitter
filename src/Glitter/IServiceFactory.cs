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

namespace Glitter;

/// <summary>
/// Represents a service factory.
/// </summary>
public interface IServiceFactory
{
    /// <summary>
    /// Gets the service of the specified type.
    /// </summary>
    /// <typeparam name="TService">Specifies the type of the service.</typeparam>
    /// <param name="parameters">The parameters to use when constructing the service.</param>
    /// <returns>The service of the specified type.</returns>
    TService GetService<TService>(params object[] parameters);
    
    /// <summary>
    /// Gets the service of the specified type.
    /// </summary>
    /// <typeparam name="TService">Specifies the type of the service.</typeparam>
    /// <param name="parameters">The parameters to use when constructing the service.</param>
    /// <returns>The service of the specified type.</returns>
    /// <exception cref="InvalidOperationException">The service of the specified type is not registered.</exception>
    TService GetRequiredService<TService>(params object[] parameters);
}
