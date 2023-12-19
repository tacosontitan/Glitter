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

using System.Globalization;

namespace Glitter.Text;

/// <summary>
/// Represents options for a <see cref="SubstringReader"/>.
/// </summary>
public class SubstringReaderOptions
{
    /// <summary>
    /// Creates new options for a <see cref="SubstringReader"/>.
    /// </summary>
    public SubstringReaderOptions()
    {
        FormatProvider = CultureInfo.InvariantCulture;
        TrimInstructions = null;
    }

    /// <summary>
    /// Gets or sets the format provider for the <see cref="SubstringReader"/>.
    /// </summary>
    public IFormatProvider? FormatProvider { get; set; }

    /// <summary>
    /// Gets or sets the trimming options for the <see cref="SubstringReader"/>.
    /// </summary>
    public IEnumerable<TrimInstruction>? TrimInstructions { get; set; }
}