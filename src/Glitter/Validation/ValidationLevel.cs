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
/// Defines validation levels.
/// </summary>
public enum ValidationLevel
{
    /// <summary>
    /// Indicates that the validation was successful.
    /// </summary>
    Success = 0,
    
    /// <summary>
    /// Indicates that the validation was successful, but with a warning.
    /// </summary>
    Warning = 1,
    
    /// <summary>
    /// Indicates that the validation was unsuccessful.
    /// </summary>
    Failure = 2,
    
    /// <summary>
    /// Indicates that the validation was unsuccessful, and that the application should not continue.
    /// </summary>
    Critical = 3
}
