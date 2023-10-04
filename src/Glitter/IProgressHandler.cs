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
/// Represents a progress handler.
/// </summary>
public interface IProgressHandler
{
    /// <summary>
    /// Appends the specified amount of progress to the progress handler.
    /// </summary>
    /// <param name="amount">The amount of progress made this step.</param>
    /// <param name="message">The message to report, if any.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task Append(
        double amount,
        string? message = null,
        CancellationToken cancellationToken = default);
}
