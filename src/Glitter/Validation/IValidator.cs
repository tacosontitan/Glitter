using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glitter.Validation;

/// <summary>
/// Defines methods for providing basic validation.
/// </summary>
public interface IValidator
{
    /// <summary>
    /// Validates the specified value.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    ValidationResult<object> Validate(object? value);

    /// <summary>
    /// Attempts to validate the specified value.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns><see langword="true"/> if the validation was successful; otherwise, <see langword="false"/>.</returns>
    ValidationResult<object> TryValidate(object? value);
}

/// <summary>
/// Defines methods for providing basic validation.
/// </summary>
/// <typeparam name="T">The type of the value to validate.</typeparam>
public interface IValidator<T>
    : IValidator
{
    /// <summary>
    /// Validates the specified value.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    ValidationResult<T> Validate(T? value);

    /// <summary>
    /// Attempts to validate the specified value.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns><see langword="true"/> if the validation was successful; otherwise, <see langword="false"/>.</returns>
    bool TryValidate(T? value, out ValidationResult<T> result);
}
