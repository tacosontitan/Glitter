﻿/*
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
/// Defines methods for providing asynchronous validation.
/// </summary>
public interface IAsyncValidatable
{
    /// <summary>
    /// Attempts to validate the implementing instance.
    /// </summary>
    /// <param name="result">The result of the validation.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous validation operation.</returns>
    Task<IValidationResult> Validate(CancellationToken cancellationToken = default);
}