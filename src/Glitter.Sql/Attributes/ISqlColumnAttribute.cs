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

// This interface is defining an attribute, so it should be named as such.
// The reason for this convention is to improve proxy support for consumers who desire it.
// This violates CA1711, but is something this repository stands firm on.
// See: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-type-members#nouns-and-noun-phrases
#pragma warning disable CA1711

namespace Glitter.Sql.Attributes;

/// <summary>
/// Defines a SQL column attribute.
/// </summary>
public interface ISqlColumnAttribute
{
    /// <summary>
    /// Gets the name of the column.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the type of the column.
    /// </summary>
    DbType? Type { get; }

    /// <summary>
    /// Gets the size of the column.
    /// </summary>
    int? Size { get; }

    /// <summary>
    /// Gets the precision of the column.
    /// </summary>
    byte? Precision { get; }

    /// <summary>
    /// Gets the scale of the column.
    /// </summary>
    byte? Scale { get; }
}
