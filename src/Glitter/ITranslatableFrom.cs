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
/// Defines a method to translate from a specified type to the consuming type.
/// </summary>
/// <typeparam name="TSelf">Specifies the consuming type capable of recieving the target type.</typeparam>
/// <typeparam name="TFrom">Specifies the type to translate into the consumer type from.</typeparam>
public interface ITranslatableFrom<TSelf, TFrom> where TSelf : ITranslatableFrom<TSelf, TFrom>
{
    /// <summary>
    /// Translates from a type to another type.
    /// </summary>
    /// <param name="from">The type to translate from.</param>
    /// <returns>The type to translate to.</returns>
    TSelf Translate(TFrom from);
}