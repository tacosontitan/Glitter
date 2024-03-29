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

// ReSharper disable once CheckNamespace
// This class defines extension methods for ISqlRequest to keep the interface clean.

using System.Data;

namespace Glitter.Data.Sql;

/// <summary>
/// Defines extension methods for <see cref="ISqlRequest"/>.
/// </summary>
public static class AddParameterIfNotExtensions
{
    /// <summary>
    /// Adds a parameter to the request if its value does not meet the condition of a specified predicate.
    /// </summary>
    /// <param name="request">The <see cref="ISqlRequest"/> instance.</param>
    /// <param name="predicate">The predicate that determines whether the parameter should be added.</param>
    /// <param name="name">The name of the parameter.</param>
    /// <param name="value">The value of the parameter.</param>
    /// <param name="type">The <see cref="DbType"/> of the parameter.</param>
    /// <param name="direction">The direction of the parameter.</param>
    /// <param name="size">The size of the parameter.</param>
    /// <param name="precision">The precision of the parameter.</param>
    /// <param name="scale">The scale of the parameter.</param>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <returns>The <see cref="ISqlRequest"/> instance.</returns>
    public static ISqlRequest AddParameterIfNot<T>(
        this ISqlRequest request,
        Func<T?, bool> predicate,
        string name,
        T? value,
        DbType? type = null,
        ParameterDirection? direction = null,
        int? size = null,
        byte? precision = null,
        byte? scale = null)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("The name of the parameter cannot be null or whitespace.");

        if (!predicate(value))
            _ = request.AddParameter(name, value, type, direction, size, precision, scale);

        return request;
    }
}