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
    }
}
