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
        void TestAction() =>
            _ = new SubstringReader(source: sample!);

        // Assert
        Assert.Throws<ArgumentException>(TestAction);
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
        void TestAction() =>
            _ = new SubstringReader(source: sample!);

        // Assert
        Assert.Throws<ArgumentException>(TestAction);
    }
    
    [Fact]
    public void Peek_PriorToEndOfSource_ReturnsSubstring()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);

        // Act
        string? result = reader.Peek();

        // Assert
        Assert.Equal(expected: sample, actual: result);
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Fact]
    public void Peek_NegativeLength_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);

        // Act
        void TestAction() =>
            _ = reader.Peek(length: -1);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(TestAction);
    }
    
    [Fact]
    public void Peek_ExceedsLengthOfSource_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);

        // Act
        void TestAction() =>
            _ = reader.Peek(length: sample.Length + 1);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(TestAction);
    }
    
    [Fact]
    public void Peek_ValidLength_ReturnsSubstring()
    {
        // Arrange
        const int testLength = 5;
        const string sample = "Hello, world!";
        string expectedSubstring = sample.Substring(startIndex: 0, length: testLength);
        var reader = new SubstringReader(source: sample);

        // Act
        string? result = reader.Peek(length: testLength);

        // Assert
        Assert.Equal(expected: expectedSubstring, actual: result);
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Fact]
    public void Peek_TryConvertToInvalidType_ThrowsFormatException()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);

        // Act
        void TestAction() =>
            _ = reader.Peek<bool>();

        // Assert
        Assert.Throws<FormatException>(TestAction);
    }
    
    [Fact]
    public void Peek_TryConvertToValidType_ReturnsConvertedValue()
    {
        // Arrange
        const string sample = "123";
        var reader = new SubstringReader(source: sample);

        // Act
        int? result = reader.Peek<int>();

        // Assert
        Assert.Equal(expected: 123, actual: result);
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Fact]
    public void Peek_SubstringExceedsRange_ThrowsOverflowException()
    {
        // Arrange
        const string sample = "12345678";
        var reader = new SubstringReader(source: sample);

        // Act
        void TestAction() =>
            _ = reader.Peek<byte>();

        // Assert
        Assert.Throws<OverflowException>(TestAction);
    }
    
    [Fact]
    public void TryPeek_PriorToEndOfSource_ReturnsSubstring()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);

        // Act
        bool result = reader.TryPeek(out string? substring);

        // Assert
        Assert.True(result);
        Assert.Equal(expected: sample, actual: substring);
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Fact]
    public void TryPeek_NegativeLength_ReturnsFalse()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);

        // Act
        bool result = reader.TryPeek(length: -1, out string? substring);

        // Assert
        Assert.False(result);
        Assert.Null(substring);
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Fact]
    public void TryPeek_ExceedsLengthOfSource_ReturnsFalse()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);

        // Act
        bool result = reader.TryPeek(length: sample.Length + 1, out string? substring);

        // Assert
        Assert.False(result);
        Assert.Null(substring);
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Fact]
    public void TryPeek_ValidLength_ReturnsSubstring()
    {
        // Arrange
        const int testLength = 5;
        const string sample = "Hello, world!";
        string expectedSubstring = sample.Substring(startIndex: 0, length: testLength);
        var reader = new SubstringReader(source: sample);

        // Act
        bool result = reader.TryPeek(length: testLength, out string? substring);

        // Assert
        Assert.True(result);
        Assert.Equal(expected: expectedSubstring, actual: substring);
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Fact]
    public void TryPeek_TryConvertToInvalidType_ReturnsFalse()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);

        // Act
        bool result = reader.TryPeek(out bool value);

        // Assert
        Assert.False(result);
        Assert.False(value);
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Fact]
    public void TryPeek_TryConvertToValidType_ReturnsConvertedValue()
    {
        // Arrange
        const string sample = "123";
        var reader = new SubstringReader(source: sample);

        // Act
        bool result = reader.TryPeek(out int value);

        // Assert
        Assert.True(result);
        Assert.Equal(expected: 123, actual: value);
        Assert.Equal(expected: 0, actual: reader.Position);
    }

    [Fact]
    public void Skip_PriorToEndOfSource_SkipsNextCharacter()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);
        
        // Act
        reader.Skip();
        string? result = reader.Peek();
        
        // Assert
        Assert.Equal(expected: "ello, world!", actual: result);
        Assert.Equal(expected: 1, actual: reader.Position);
    }
    
    [Theory]
    [InlineData(-100)]
    [InlineData(100)]
    public void Seek_InvalidLength_ThrowsArgumentOutOfRangeException(int length)
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);
        
        // Act
        void TestAction() =>
            reader.Seek(length);
        
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(TestAction);
    }
    
    [Fact]
    public void Seek_PriorToEndOfSource_SkipsNextCharacter()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);
        
        // Act
        reader.Seek(1);
        string? result = reader.Peek();
        
        // Assert
        Assert.Equal(expected: "ello, world!", actual: result);
        Assert.Equal(expected: 1, actual: reader.Position);
    }
    
    [Fact]
    public void Seek_NegativeLength_SkipsPreviousCharacter()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);
        
        // Act & Assert 1
        reader.Skip();
        Assert.Equal(expected: "ello, world!", actual: reader.Peek());
        Assert.Equal(expected: 1, actual: reader.Position);
        
        // Act & Assert 2
        reader.Seek(-1);
        Assert.Equal(expected: sample, actual: reader.Peek());
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void SkipTo_SearchValueFound_SkipsToSearchValue(bool skipSearchValue)
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);
        
        // Act
        reader.SkipTo(',', skipSearchValue);
        string? result = reader.Peek();
        
        // Assert
        string expectedResult = skipSearchValue ? " world!" : ", world!";
        Assert.Equal(expected: expectedResult, actual: result);
        
        int expectedPosition = skipSearchValue ? sample.IndexOf(',') + 1 : sample.IndexOf(',');
        Assert.Equal(expected: expectedPosition, actual: reader.Position);
    }
    
    [Fact]
    public void Read_PriorToEndOfSource_ReturnsSubstring()
    {
        // Arrange
        const int testLength = 5;
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);
        
        // Act
        _ = reader.Read(length: testLength, out string? result);
        
        // Assert
        Assert.Equal(expected: "Hello", actual: result);
        Assert.Equal(expected: testLength, actual: reader.Position);
    }
    
    [Fact]
    public void Read_NegativeLength_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);
        
        // Act
        void TestAction() =>
            _ = reader.Read(length: -1, out string? result);
        
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(TestAction);
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Fact]
    public void Read_ExceedsLengthOfSource_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);
        
        // Act
        void TestAction() =>
            _ = reader.Read(length: sample.Length + 1, out string? result);
        
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(TestAction);
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Fact]
    public void Read_FailureToParseResult_ThrowsFormatException()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);
        
        // Act
        void TestAction() =>
            _ = reader.Read(length: sample.Length, out int result);
        
        // Assert
        Assert.Throws<FormatException>(TestAction);
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Fact]
    public void Read_SuccessfulParseResult_ReturnsParsedValue()
    {
        // Arrange
        const string sample = "123";
        var reader = new SubstringReader(source: sample);
        
        // Act
        _ = reader.Read(length: sample.Length, out int result);
        
        // Assert
        Assert.Equal(expected: 123, actual: result);
        Assert.Equal(expected: sample.Length, actual: reader.Position);
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ReadTo_SearchValueFound_ReturnsSubstring(bool includeSearchValue)
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);
        
        // Act
        _ = reader.ReadTo(',', out string? result, includeSearchValue);
        
        // Assert
        string expectedResult = includeSearchValue ? "Hello," : "Hello";
        Assert.Equal(expected: expectedResult, actual: result);
        
        int expectedPosition = includeSearchValue ? sample.IndexOf(',') + 1 : sample.IndexOf(',');
        Assert.Equal(expected: expectedPosition, actual: reader.Position);
    }
    
    [Fact]
    public void ReadTo_SearchValueNotFound_ReturnsSubstring()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);
        
        // Act
        _ = reader.ReadTo('.', out string? result);
        
        // Assert
        Assert.Null(result);
        Assert.Equal(expected: 0, actual: reader.Position);
    }
    
    [Fact]
    public void Reset_ReaderPositionIsNotZero_SetsReaderPositionToZero()
    {
        // Arrange
        const string sample = "Hello, world!";
        var reader = new SubstringReader(source: sample);
        
        // Act
        _ = reader.Skip().Reset();
        
        // Assert
        Assert.Equal(expected: 0, actual: reader.Position);
    }
}
