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
/// Defines methods for translating to and from a type.
/// </summary>
/// <typeparam name="TSelf">Specifies the consuming translatable type.</typeparam>
/// <typeparam name="T">Specifies the target translatable type.</typeparam>
/// <remarks>
/// This interface simplifies the implementation definition of <see cref="ITranslatableTo{TSelf, TTo}"/> and <see cref="ITranslatableFrom{TSelf, TFrom}"/>.
/// </remarks>
public interface ITranslatable<TSelf, T> :
    ITranslatableFrom<TSelf, T>,
    ITranslatableTo<TSelf, T>
    where TSelf : ITranslatable<TSelf, T>
{ }
