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

namespace Glitter.Data.Io;

/// <summary>
/// Represents a file.
/// </summary>
public interface IFile
{
    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    string Name { get; set; }
    
    /// <summary>
    /// Gets or sets the extension of the file.
    /// </summary>
    string Extension { get; set; }
    
    /// <summary>
    /// Gets or sets the content of the file.
    /// </summary>
    IEnumerable<byte> Content { get; set; }
}
