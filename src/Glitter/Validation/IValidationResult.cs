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

namespace Glitter.Validation;

/// <summary>
/// Describes the result of validation.
/// </summary>
public interface IValidationResult
{
    /// <summary>
    /// Gets whether or not validation was successful.
    /// </summary>
    bool Successful { get; }

    /// <summary>
    /// Gets the messages associated with the result.
    /// </summary>
    IEnumerable<ValidationMessage> Messages { get; }
}