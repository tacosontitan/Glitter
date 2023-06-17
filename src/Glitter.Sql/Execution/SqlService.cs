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
/// Represents a service for interacting with SQL.
/// </summary>
public abstract class SqlService :
    IQueryHandler,
    IScalarHandler,
    INonQueryHandler
{
    private readonly ISqlProvider _sqlProvider;

    /// <summary>
    /// Creates a new <see cref="SqlService"/> instance.
    /// </summary>
    /// <param name="provider">The <see cref="ISqlProvider"/> to use for interacting with SQL.</param>
    public SqlService(ISqlProvider provider)
    {
        if (provider is null)
            throw new ArgumentNullException(nameof(provider), "The SQL provider cannot be null.");

        _sqlProvider = provider;
    }

    /// <inheritdoc/>
    public virtual Task<IEnumerable<T>> Query<T>(ISqlRequest request) =>
        _sqlProvider.Query<T>(request);

    /// <inheritdoc/>
    public virtual Task<T> ExecuteScalar<T>(ISqlRequest request) =>
        _sqlProvider.ExecuteScalar<T>(request);

    /// <inheritdoc/>
    public virtual Task ExecuteNonQuery(ISqlRequest request) =>
        _sqlProvider.ExecuteNonQuery(request);
}
