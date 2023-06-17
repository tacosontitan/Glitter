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

namespace Glitter.Sql.Execution;

/// <summary>
/// Defines methods for executing SQL queries that do not return a value.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of <see cref="ISqlRequest"/> to execute.</typeparam>
public interface INonQueryHandler<TRequest>
    where TRequest : ISqlRequest
{
    /// <summary>
    /// Executes the specified <see cref="ISqlRequest"/> as a query and returns the number of rows affected.
    /// </summary>
    /// <param name="request">The request to execute.</param>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    Task ExecuteNonQuery(TRequest request);
}
