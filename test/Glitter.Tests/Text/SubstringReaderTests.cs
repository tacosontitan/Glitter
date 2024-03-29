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

using Glitter.Text;

namespace Glitter.Tests.Text;

public class SubstringReaderTests
{
    [Fact]
    public void Constructor_NullSource_ThrowsArgumentException()
    {
        // Arrange
        string? sample = null;

        // Act
        void TestAction()
        {
            _ = new SubstringReader(sample!);
        }

        // Assert
        _ = Assert.Throws<ArgumentException>(TestAction);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    [InlineData("\n")]
    [InlineData("\r")]
    public void Constructor_InvalidSource_ThrowsArgumentException(string? sample)
    {
        // Arrange & Act
        void TestAction()
        {
            _ = new SubstringReader(sample!);
        }

        // Assert
        _ = Assert.Throws<ArgumentException>(TestAction);
    }

    [Fact]
    public void Peek_PriorToEndOfSource_ReturnsSubstring()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        string? result = reader.Peek();

        // Assert
        Assert.Equal(sample, result);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void Peek_NegativeLength_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        void TestAction()
        {
            _ = reader.Peek(-1);
        }

        // Assert
        _ = Assert.Throws<ArgumentOutOfRangeException>(TestAction);
    }

    [Fact]
    public void Peek_ExceedsLengthOfSource_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        void TestAction()
        {
            _ = reader.Peek(sample.Length + 1);
        }

        // Assert
        _ = Assert.Throws<ArgumentOutOfRangeException>(TestAction);
    }

    [Fact]
    public void Peek_ValidLength_ReturnsSubstring()
    {
        // Arrange
        const int testLength = 5;
        const string sample = "Hello, world!";
        string expectedSubstring = sample.Substring(0, testLength);
        var reader = new SubstringReader(sample);

        // Act
        string? result = reader.Peek(testLength);

        // Assert
        Assert.Equal(expectedSubstring, result);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void Peek_TryConvertToInvalidType_ThrowsFormatException()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        void TestAction()
        {
            _ = reader.Peek<bool>();
        }

        // Assert
        _ = Assert.Throws<FormatException>(TestAction);
    }

    [Fact]
    public void Peek_TryConvertToValidType_ReturnsConvertedValue()
    {
        // Arrange
        const string sample = "123";
        var reader = new SubstringReader(sample);

        // Act
        int? result = reader.Peek<int>();

        // Assert
        Assert.Equal(123, result);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void Peek_SubstringExceedsRange_ThrowsOverflowException()
    {
        // Arrange
        const string sample = "12345678";
        var reader = new SubstringReader(sample);

        // Act
        void TestAction()
        {
            _ = reader.Peek<byte>();
        }

        // Assert
        _ = Assert.Throws<OverflowException>(TestAction);
    }

    [Fact]
    public void TryPeek_PriorToEndOfSource_ReturnsSubstring()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        bool result = reader.TryPeek(out string? substring);

        // Assert
        Assert.True(result);
        Assert.Equal(sample, substring);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void TryPeek_NegativeLength_ReturnsFalse()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        bool result = reader.TryPeek(-1, out string? substring);

        // Assert
        Assert.False(result);
        Assert.Null(substring);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void TryPeek_ExceedsLengthOfSource_ReturnsFalse()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        bool result = reader.TryPeek(sample.Length + 1, out string? substring);

        // Assert
        Assert.False(result);
        Assert.Null(substring);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void TryPeek_ValidLength_ReturnsSubstring()
    {
        // Arrange
        const int testLength = 5;
        const string sample = "Hello, world!";
        string expectedSubstring = sample.Substring(0, testLength);
        var reader = new SubstringReader(sample);

        // Act
        bool result = reader.TryPeek(testLength, out string? substring);

        // Assert
        Assert.True(result);
        Assert.Equal(expectedSubstring, substring);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void TryPeek_TryConvertToInvalidType_ReturnsFalse()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        bool result = reader.TryPeek(out bool value);

        // Assert
        Assert.False(result);
        Assert.False(value);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void TryPeek_TryConvertToValidType_ReturnsConvertedValue()
    {
        // Arrange
        const string sample = "123";
        var reader = new SubstringReader(sample);

        // Act
        bool result = reader.TryPeek(out int value);

        // Assert
        Assert.True(result);
        Assert.Equal(123, value);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void Skip_PriorToEndOfSource_SkipsNextCharacter()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        _ = reader.Skip();
        string? result = reader.Peek();

        // Assert
        Assert.Equal("ello, world!", result);
        Assert.Equal(1, reader.Position);
    }

    [Theory]
    [InlineData(-100)]
    [InlineData(100)]
    public void Seek_InvalidLength_ThrowsArgumentOutOfRangeException(int length)
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        void TestAction()
        {
            reader.Seek(length);
        }

        // Assert
        _ = Assert.Throws<ArgumentOutOfRangeException>(TestAction);
    }

    [Fact]
    public void Seek_PriorToEndOfSource_SkipsNextCharacter()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        _ = reader.Seek(1);
        string? result = reader.Peek();

        // Assert
        Assert.Equal("ello, world!", result);
        Assert.Equal(1, reader.Position);
    }

    [Fact]
    public void Seek_NegativeLength_SkipsPreviousCharacter()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act & Assert 1
        _ = reader.Skip();
        Assert.Equal("ello, world!", reader.Peek());
        Assert.Equal(1, reader.Position);

        // Act & Assert 2
        _ = reader.Seek(-1);
        Assert.Equal(sample, reader.Peek());
        Assert.Equal(0, reader.Position);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void SkipTo_SearchValueFound_SkipsToSearchValue(bool skipSearchValue)
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        _ = reader.SkipTo(',', skipSearchValue);
        string? result = reader.Peek();

        // Assert
        string expectedResult = skipSearchValue ? " world!" : ", world!";
        Assert.Equal(expectedResult, result);

        int expectedPosition = skipSearchValue ? sample.IndexOf(',') + 1 : sample.IndexOf(',');
        Assert.Equal(expectedPosition, reader.Position);
    }

    [Fact]
    public void Read_PriorToEndOfSource_ReturnsSubstring()
    {
        // Arrange
        const int testLength = 5;
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        _ = reader.Read(testLength, out string? result);

        // Assert
        Assert.Equal("Hello", result);
        Assert.Equal(testLength, reader.Position);
    }

    [Fact]
    public void Read_NegativeLength_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        void TestAction()
        {
            _ = reader.Read(-1, out string? result);
        }

        // Assert
        _ = Assert.Throws<ArgumentOutOfRangeException>(TestAction);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void Read_ExceedsLengthOfSource_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        void TestAction()
        {
            _ = reader.Read(sample.Length + 1, out string? result);
        }

        // Assert
        _ = Assert.Throws<ArgumentOutOfRangeException>(TestAction);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void Read_FailureToParseResult_ThrowsFormatException()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        void TestAction()
        {
            _ = reader.Read(sample.Length, out int result);
        }

        // Assert
        _ = Assert.Throws<FormatException>(TestAction);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void Read_SuccessfulParseResult_ReturnsParsedValue()
    {
        // Arrange
        const string sample = "123";
        var reader = new SubstringReader(sample);

        // Act
        _ = reader.Read(sample.Length, out int result);

        // Assert
        Assert.Equal(123, result);
        Assert.Equal(sample.Length, reader.Position);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ReadTo_SearchValueFound_ReturnsSubstring(bool includeSearchValue)
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        _ = reader.ReadTo(',', out string? result, includeSearchValue);

        // Assert
        string expectedResult = includeSearchValue ? "Hello," : "Hello";
        Assert.Equal(expectedResult, result);

        int expectedPosition = includeSearchValue ? sample.IndexOf(',') + 1 : sample.IndexOf(',');
        Assert.Equal(expectedPosition, reader.Position);
    }

    [Fact]
    public void ReadTo_SearchValueNotFound_ReturnsSubstring()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        _ = reader.ReadTo('.', out string? result);

        // Assert
        Assert.Null(result);
        Assert.Equal(0, reader.Position);
    }

    [Fact]
    public void Reset_ReaderPositionIsNotZero_SetsReaderPositionToZero()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(sample);

        // Act
        _ = reader.Skip().Reset();

        // Assert
        Assert.Equal(0, reader.Position);
    }
}