namespace Glitter.Extensions.Tests;

public class ConstrainsExtensionsTests
{
    [Fact]
    public void InputIsNull()
    {
        // Arrange
        string? input = null;

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => input!.Constrain("a", "z"));
    }

#pragma warning disable CS8631 // Not all consumers care and will invoke anyways. Unit tests must handle this case.

    [Fact]
    public void LowerBoundIsNull()
    {
        // Arrange
        string input = "b";

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => input.Constrain(null, "z"));
    }
    [Fact]
    public void UpperBoundIsNull()
    {
        // Arrange
        string? input = "b";

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => input.Constrain("a", null));
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
        _ = Assert.Throws<ArgumentException>(() => input.Constrain(lowerBound, upperBound));
    }
    [Fact]
    public void InputIsLessThanLowerBound()
    {
        // Arrange
        int input = 5;
        int lowerBound = 10;
        int upperBound = 20;

        // Act
        int result = input.Constrain(lowerBound, upperBound);

        // Assert
        Assert.Equal(lowerBound, result);
    }
    [Fact]
    public void InputIsGreaterThanUpperBound()
    {
        // Arrange
        int input = 25;
        int lowerBound = 10;
        int upperBound = 20;

        // Act
        int result = input.Constrain(lowerBound, upperBound);

        // Assert
        Assert.Equal(upperBound, result);
    }
    [Fact]
    public void InputIsWithinBounds()
    {
        // Arrange
        int input = 15;
        int lowerBound = 10;
        int upperBound = 20;

        // Act
        int result = input.Constrain(lowerBound, upperBound);

        // Assert
        Assert.Equal(input, result);
    }
}