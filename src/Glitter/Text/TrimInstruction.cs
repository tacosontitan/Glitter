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

namespace Glitter.Text;

/// <summary>
/// Represents instructions to be utilized when trimming strings.
/// </summary>
public class TrimInstruction
{
    /// <summary>
    /// Creates new trim instructions.
    /// </summary>
    /// <param name="orientation">The orientation of the trim.</param>
    /// <param name="values">The characters to trim.</param>
    public TrimInstruction(TrimOrientation orientation, params char[] values)
    {
        Orientation = orientation;
        Values = values;
    }

    public TrimOrientation Orientation { get; set; }
    
    /// <summary>
    /// Gets or sets the characters to trim.
    /// </summary>
    public IEnumerable<char> Values { get; set; }
    
    /// <summary>
    /// Gets preconfigured instructions for trimming whitespace from the beginning and end of a string.
    /// </summary>
    public static TrimInstruction WhiteSpace =>
        new TrimInstruction(TrimOrientation.Full, values: new[] { ' ', '\t', '\r', '\n' });
}
