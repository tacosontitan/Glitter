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

namespace Glitter.Serialization;

/// <summary>
/// Defines methods for serializing and deserializing objects.
/// </summary>
public interface ISerializationProvider
{
    /// <summary>
    /// Serializes the specified value.
    /// </summary>
    /// <param name="value">The value to serialize.</param>
    /// <param name="formatProvider">An object providing culture-specific formatting information.</param>
    /// <returns>The result of the serialization operation.</returns>
    string Serialize<T>(T? value, IFormatProvider? formatProvider = null);
    
    /// <summary>
    /// Deserializes the specified value.
    /// </summary>
    /// <param name="value">The value to deserialize.</param>
    /// <param name="formatProvider">An object providing culture-specific formatting information.</param>
    /// <returns>The result of the deserialization operation.</returns>
    T? Deserialize<T>(string? value, IFormatProvider? formatProvider = null);
}
