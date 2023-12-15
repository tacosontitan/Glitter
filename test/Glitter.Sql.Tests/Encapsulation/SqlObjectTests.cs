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

// All unit tests follow the naming convention of MethodName_StateUnderTest_ExpectedBehavior.
// This violates CA1707, but is common practice and widely accepted.
// See: https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1707-identifiers-should-not-contain-underscores?view=vs-2019

#pragma warning disable CA1707

using Glitter.Sql.Encapsulation;

namespace Glitter.Sql.Tests.Encapsulation;

/// <summary>
/// Defines unit tests for the <see cref="SqlObject"/> class.
/// </summary>
public class SqlObjectTests
{
    /// <summary>
    /// Tests that the constructor throws an <see cref="ArgumentException"/> when the name is invalid.
    /// </summary>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_InvalidName_ThrowsArgumentException(string name) =>
        Assert.Throws<ArgumentException>(() => new TestSqlObject(name));

    /// <summary>
    /// Tests that the constructor throws an <see cref="ArgumentException"/> when the schema is invalid.
    /// </summary>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_InvalidSchema_DefaultsToDbo(string schema)
    {
        var obj = new TestSqlObject(schema, "name");
        Assert.Equal("dbo", obj.Schema);
    }

    /// <summary>
    /// Represents a simple <see cref="SqlObject"/> for testing.
    /// </summary>
    internal sealed class TestSqlObject
        : SqlObject
    {
        /// <summary>
        /// Creates a new <see cref="TestSqlObject"/> instance.
        /// </summary>
        /// <param name="name">The name of the object.</param>
        internal TestSqlObject(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Creates a new <see cref="TestSqlObject"/> instance.
        /// </summary>
        /// <param name="schema">The schema for the object.</param>
        /// <param name="name">The name of the object.</param>
        internal TestSqlObject(string schema, string name)
            : base(schema, name)
        {
        }
    }
}