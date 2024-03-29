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
/// Defines members for approving validation messages.
/// </summary>
/// <param name="options">Options for validating message levels.</param>
public class ValidationMessageLevelApprovalStrategy(
    IValidationOptions? options = null)
    : IValidationMessageApprovalStrategy
{
    private readonly IValidationOptions _options = options ?? new ValidationOptions();

    /// <inheritdoc />
    public virtual bool IsApproved(ValidationMessage message) => _options.TreatWarningsAsFailures
        ? message.Level < ValidationLevel.Warning
        : message.Level < ValidationLevel.Failure;
}