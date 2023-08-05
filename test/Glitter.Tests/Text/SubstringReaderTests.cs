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

    [Fact]
    public void Peek_DoesNotAdvanceCurrentIndex()
    {
        // Arrange
        string sample = "Hello, world!";
        SubstringReader reader = new(sample);
        
        // Act
        _ = reader.Peek();
        
        // Assert
        Assert.Equal(expected: 0, actual: reader.CurrentIndex);
    }

    [Fact]
    public void Peek_WithLength_DoesNotAdvanceCurrentIndex()
    {
        // Arrange
        string sample = "Hello, world!";
        SubstringReader reader = new(sample);
        
        // Act
        string? result = reader.Peek(length: 5);
        string expectation = sample.Substring(startIndex: 0, length: 5);
        
        // Assert
        Assert.Equal(expected: 0, actual: reader.CurrentIndex);
        Assert.Equal(expected: expectation, actual: result);
    }
    
    [Fact]
    public void Peek_WithExcessiveLength_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        string sample = "Hello, world!";
        SubstringReader reader = new(sample);
        
        // Act
        void TestAction() =>
            _ = reader.Peek(length: 100);
        
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(TestAction);
    }

    [Fact]
    public void TryPeek_WithExcessiveLength_ReturnsFalse()
    {
        // Arrange
        string sample = "Hello, world!";
        SubstringReader reader = new(sample);
        
        // Act
        bool peekResult = reader.TryPeek(length: 100, out string? parsedResult);
        
        // Assert
        Assert.False(peekResult);
        Assert.Null(parsedResult);
    }

    [Fact]
    public void TryPeek_WithValidLength_ReturnsTrue()
    {
        // Arrange
        string sample = "Hello, world!";
        SubstringReader reader = new(sample);
        
        // Act
        bool peekResult = reader.TryPeek(length: 5, out string? parsedResult);
        
        // Assert
        Assert.True(peekResult);
        Assert.Equal(expected: "Hello", actual: parsedResult);
    }

    [Fact]
    public void TryPeek_WithInvalidTypeParameter_ReturnsFalse()
    {
        // Arrange
        string sample = "Hello, world!";
        SubstringReader reader = new(sample);
        
        // Act
        bool peekResult = reader.TryPeek<int>(length: 5, out int parsedResult);
        
        // Assert
        Assert.False(peekResult);
        Assert.Equal(expected: default, actual: parsedResult);
    }
}
