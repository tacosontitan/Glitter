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
/// Represents a simple validation message.
/// </summary>
/// <param name="level">The level of the validation message.</param>
/// <param name="value">The message associated with the validation.</param>
public class ValidationMessage(
    ValidationLevel level,
    string? value)
{
    /// <summary>
    /// Gets the level of the validation result.
    /// </summary>
    public ValidationLevel Level { get; } = level;
    
    /// <summary>
    /// Gets the message describing the validation result.
    /// </summary>
    public string? Value { get; } = value;
}
