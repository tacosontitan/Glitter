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
/// Represents the result of a validation.
/// </summary>
public class ValidationMessage
    : IValidationMessage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationMessage"/> class.
    /// </summary>
    /// <param name="value">The message describing the validation result.</param>
    public ValidationMessage(ValidationLevel level, string? value)
    {
        Level = level;
        Value = value;
    }
    
    /// <inheritdoc />
    public ValidationLevel Level { get; }
    
    /// <inheritdoc />
    public string? Value { get; }
}
