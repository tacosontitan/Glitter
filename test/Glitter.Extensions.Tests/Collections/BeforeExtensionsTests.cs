namespace Glitter.Extensions.Tests.Collections;

public class BeforeExtensionsTests
{
    [Fact]
    public void SourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => source.Before(1));
    }
    [Fact]
    public void SearchValueIsNull()
    {
        // Arrange
        IEnumerable<int?> source = new int?[] { 1, 2, 3 };

        // Assert
        Assert.Throws<ArgumentNullException>(() => source.Before(null));
    }
    [Fact]
    public void SearchValueIsNotFound()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        IEnumerable<int> result = source.Before(4);

        // Assert
        Assert.Empty(result);
    }
    [Fact]
    public void SearchValueIsFound()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        IEnumerable<int> result = source.Before(2);

        // Assert
        Assert.Equal(new[] { 1 }, result);
    }
    [Fact]
    public void SearchValueIsFoundAtBeginning()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        IEnumerable<int> result = source.Before(1);

        // Assert
        Assert.Empty(result);
    }
    [Fact]
    public void SearchValueIsFoundAtEnd()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        IEnumerable<int> result = source.Before(3);

        // Assert
        Assert.Equal(new[] { 1, 2 }, result);
    }
    [Fact]
    public void SearchValueIsPresentMultipleTimes()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3, 2, 3 };

        // Act
        IEnumerable<int> result = source.Before(3);

        // Assert
        Assert.Equal(new[] { 1, 2 }, result);
    }
}