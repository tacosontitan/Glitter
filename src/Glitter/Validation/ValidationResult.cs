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
public class ValidationResult
    : IValidationResult
{
    private readonly IValidationOptions _options;
    private readonly List<ValidationMessage> _messages;
    private readonly IValidationMessageApprovalStrategy _messageApprovalStrategy;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult"/> class.
    /// </summary>
    /// <param name="options">The options to use for validation.</param>
    /// <param name="approvalStrategy">The strategy to use for determining if a validation message is approved.</param>
    public ValidationResult(
        IValidationOptions? options = null,
        IValidationMessageApprovalStrategy? approvalStrategy = null)
    {
        _messages = new List<ValidationMessage>();
        _options = options ?? new ValidationOptions();
        _messageApprovalStrategy = approvalStrategy ?? new ValidationMessageLevelApprovalStrategy(_options);
    }

    /// <inheritdoc />
    public bool Successful =>
        _messages.All(_messageApprovalStrategy.IsApproved);

    /// <inheritdoc />
    public IEnumerable<ValidationMessage> Messages => _messages;

    /// <summary>
    /// Adds a critical level validation message to the result.
    /// </summary>
    /// <param name="value">The message describing the validation message.</param>
    public virtual void AddCritical(string? value) =>
        AddMessage(ValidationLevel.Critical, value);

    /// <summary>
    /// Adds an error level validation message to the result.
    /// </summary>
    /// <param name="value">The message describing the validation message.</param>
    public virtual void AddFailure(string? value) =>
        AddMessage(ValidationLevel.Failure, value);

    /// <summary>
    /// Adds a validation message to the result.
    /// </summary>
    /// <param name="message">The message describing the validation message.</param>
    public virtual void AddMessage(ValidationMessage message) =>
        _messages.Add(message);

    /// <summary>
    /// Adds a validation message to the result.
    /// </summary>
    /// <param name="level">The level of the validation message.</param>
    /// <param name="value">The message describing the validation message.</param>
    public virtual void AddMessage(ValidationLevel level, string? value)
    {
        var validationMessage = new ValidationMessage(level, value);
        _messages.Add(validationMessage);
    }

    /// <summary>
    /// Adds an information level validation message to the result.
    /// </summary>
    /// <param name="value">The message describing the validation message.</param>
    public virtual void AddSuccess(string? value) =>
        AddMessage(ValidationLevel.Success, value);

    /// <summary>
    /// Adds a warning level validation message to the result.
    /// </summary>
    /// <param name="value">The message describing the validation message.</param>
    public virtual void AddWarning(string? value) =>
        AddMessage(ValidationLevel.Warning, value);
}