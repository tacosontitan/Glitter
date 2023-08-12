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
/// Represents an exception that is thrown when a resource is not found.
/// </summary>
public sealed class NotFoundException
    : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    public NotFoundException()
        : this(additionalInformation: null)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    /// <param name="additionalInformation">Additional information about the exception.</param>
    public NotFoundException(string? additionalInformation) :
        base(message: "The requested resource was not found.") =>
        AdditionalInformation = additionalInformation;

    /// <summary>
    /// Gets additional information about the exception.
    /// </summary>
    public string? AdditionalInformation { get; }
}
