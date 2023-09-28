namespace Glitter.Extensions.Tests;

public class WithinExtensionsTests
{
    [Fact]
    public void InputIsNull()
    {
        // Arrange
        string? input = null;

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => input!.Within(lowerBound: "a", upperBound: "z"));
    }

#pragma warning disable CS8631 // Not all consumers care and will invoke anyways. Unit tests must handle this case.

    [Fact]
    public void LowerBoundIsNull()
    {
        // Arrange
        string input = "b";

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => input.Within(lowerBound: null, upperBound: "z"));
    }
    
    [Fact]
    public void UpperBoundIsNull()
    {
        // Arrange
        string? input = "b";

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => input.Within(lowerBound: "a", upperBound: null));
    }

#pragma warning restore CS8631 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match constraint type.

    [Fact]
    public void LowerBoundIsGreaterThanUpperBound()
    {
        // Arrange
        int input = 5;
        int lowerBound = 10;
        int upperBound = 0;

        // Assert
        _ = Assert.Throws<ArgumentException>(() => input.Within(lowerBound, upperBound));
    }
    
    [Fact]
    public void InputIsLessThanLowerBound()
    {
        // Arrange
        int input = 5;
        int lowerBound = 10;
        int upperBound = 20;

        // Act
        bool result = input.Within(lowerBound, upperBound);

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void InputIsEqualToLowerBound()
    {
        // Arrange
        int input = 10;
        int lowerBound = 10;
        int upperBound = 20;

        // Act
        bool result = input.Within(lowerBound, upperBound);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void InputIsGreaterThanLowerBoundAndLessThanUpperBound()
    {
        // Arrange
        int input = 15;
        int lowerBound = 10;
        int upperBound = 20;

        // Act
        bool result = input.Within(lowerBound, upperBound);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void InputIsEqualToUpperBound()
    {
        // Arrange
        int input = 20;
        int lowerBound = 10;
        int upperBound = 20;

        // Act
        bool result = input.Within(lowerBound, upperBound);

        // Assert
        Assert.True(result);
    }
}