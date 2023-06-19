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
/// Defines unit tests for the <see cref="SqlRequest"/> class.
/// </summary>
public class SqlRequestTests
{
    /// <summary>
    /// Tests that the constructor throws an <see cref="ArgumentException"/> when the command text is invalid.
    /// </summary>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void AddParameter_InvalidName_ThrowsArgumentException(string name)
    {
        var request = new TestSqlRequest("command", CommandType.Text);
        _ = Assert.Throws<ArgumentException>(() => request.AddParameter(name, "value"));
    }

    /// <summary>
    /// Tests that the constructor throws an <see cref="InvalidOperationException"/> when the parameter name is already in use.
    /// </summary>
    [Fact]
    public void AddParameter_DuplicateName_ThrowsInvalidOperationException()
    {
        var request = new TestSqlRequest("command", CommandType.Text);
        _ = request.AddParameter("name", "value");
        _ = Assert.Throws<InvalidOperationException>(() => request.AddParameter("name", "value"));
    }

    /// <summary>
    /// Tests that the constructor throws an <see cref="ArgumentException"/> when the parameter value is null.
    /// </summary>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void TryCompile_InvalidCommand_ReturnsFalse(string commandText)
    {
        var request = new TestSqlRequest(commandText, CommandType.Text);
        Assert.False(request.TryCompile(out _));
    }

    /// <summary>
    /// Represents a simple <see cref="SqlRequest"/> for testing.
    /// </summary>
    internal sealed class TestSqlRequest
        : SqlRequest
    {
        /// <summary>
        /// Creates a new <see cref="TestSqlRequest"/> instance.
        /// </summary>
        /// <param name="command">The command text.</param>
        /// <param name="commandType">The command type.</param>
        public TestSqlRequest(string? command, CommandType commandType)
            : base(command, commandType)
        { }
    }
}
