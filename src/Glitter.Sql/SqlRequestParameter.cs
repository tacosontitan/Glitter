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

namespace Glitter.Sql;

/// <summary>
/// Represents a parameter for a SQL request.
/// </summary>
public class SqlRequestParameter
{
    /// <summary>
    /// The name of the parameter.
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// The value of the parameter.
    /// </summary>
    public object? Value { get; private set; }
    
    /// <summary>
    /// The <see cref="DbType"/> of the parameter.
    /// </summary>
    public DbType? Type { get; private set; }
    
    /// <summary>
    /// The direction of the parameter.
    /// </summary>
    public ParameterDirection? Direction { get; private set; }
    
    /// <summary>
    /// The size of the parameter.
    /// </summary>
    public int? Size { get; private set; }
    
    /// <summary>
    /// The precision of the parameter.
    /// </summary>
    public byte? Precision { get; private set; }
    
    /// <summary>
    /// The scale of the parameter.
    /// </summary>
    public byte? Scale { get; private set; }
    
    /// <summary>
    /// Creates a new <see cref="SqlRequestParameter"/> instance.
    /// </summary>
    /// <param name="name">The name of the parameter.</param>
    /// <param name="value">The value of the parameter.</param>
    /// <param name="type">The <see cref="DbType"/> of the parameter.</param>
    /// <param name="direction">The direction of the parameter.</param>
    /// <param name="size">The size of the parameter.</param>
    /// <param name="precision">The precision of the parameter.</param>
    /// <param name="scale">The scale of the parameter.</param>
    public SqlRequestParameter(
        string name,
        object? value = null,
        DbType? type = null,
        ParameterDirection? direction = null,
        int? size = null,
        byte? precision = null,
        byte? scale = null)
    {
        Name = name;
        Value = value;
        Type = type;
        Direction = direction;
        Size = size;
        Precision = precision;
        Scale = scale;
    }
}
