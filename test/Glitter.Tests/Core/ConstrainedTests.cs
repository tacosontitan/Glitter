namespace Glitter.Tests.Core;

public class ConstrainedTests
{
    [Fact]
    public void Constructor_LessThanLowerBound_ConstrainsToLowerBound()
    {
        // Arrange
        int value = 0;
        int lowerBound = 1;
        int upperBound = 10;
        
        // Act
        Clamped<int> clamped = new(value, lowerBound, upperBound);
        
        // Assert
        Assert.Equal(expected: lowerBound, actual: clamped.Value);
    }
    
    [Fact]
    public void Constructor_GreaterThanUpperBound_ConstrainsToUpperBound()
    {
        // Arrange
        int value = 100;
        int lowerBound = 1;
        int upperBound = 10;
        
        // Act
        Clamped<int> clamped = new(value, lowerBound, upperBound);
        
        // Assert
        Assert.Equal(expected: upperBound, actual: clamped.Value);
    }
    
    [Fact]
    public void Constructor_WithinBounds_DoesNotAdjust()
    {
        // Arrange
        int value = 5;
        int lowerBound = 1;
        int upperBound = 10;
        
        // Act
        Clamped<int> clamped = new(value, lowerBound, upperBound);
        
        // Assert
        Assert.Equal(expected: value, actual: clamped.Value);
    }
    
    [Fact]
    public void LowerBoundSet_GreaterThanValue_ConstrainsToLowerBound()
    {
        // Arrange
        int value = 5;
        int lowerBound = 1;
        int upperBound = 15;
        Clamped<int> clamped = new(value, lowerBound, upperBound);
        
        // Act
        clamped.LowerBound = value + 1;
        
        // Assert
        Assert.Equal(expected: clamped.LowerBound, actual: clamped.Value);
    }
    
    [Fact]
    public void LowerBoundSet_LessThanValue_DoesNotAdjust()
    {
        // Arrange
        int value = 5;
        int lowerBound = 1;
        int upperBound = 15;
        Clamped<int> clamped = new(value, lowerBound, upperBound);
        
        // Act
        clamped.LowerBound = value - 1;
        
        // Assert
        Assert.Equal(expected: value, actual: clamped.Value);
    }
    
    [Fact]
    public void UpperBoundSet_LessThanValue_ConstrainsToUpperBound()
    {
        // Arrange
        int value = 5;
        int lowerBound = 1;
        int upperBound = 15;
        Clamped<int> clamped = new(value, lowerBound, upperBound);
        
        // Act
        clamped.UpperBound = value - 1;
        
        // Assert
        Assert.Equal(expected: clamped.UpperBound, actual: clamped.Value);
    }
    
    [Fact]
    public void UpperBoundSet_GreaterThanValue_DoesNotAdjust()
    {
        // Arrange
        int value = 5;
        int lowerBound = 1;
        int upperBound = 15;
        Clamped<int> clamped = new(value, lowerBound, upperBound);
        
        // Act
        clamped.UpperBound = value + 1;
        
        // Assert
        Assert.Equal(expected: value, actual: clamped.Value);
    }
}