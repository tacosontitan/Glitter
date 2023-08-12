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
/// Represents the orientation that should be used during trimming.
/// </summary>
public enum TrimOrientation
{
    /// <summary>
    /// Indicates that trimming should be applied to both sides of the target.
    /// </summary>
    Full = 0,
    
    /// <summary>
    /// Indicates that trimming should be applied to the start of the target.
    /// </summary>
    Start = 1,
    
    /// <summary>
    /// Indicates that trimming should be applied to the end of the target.
    /// </summary>
    End = 2
}
