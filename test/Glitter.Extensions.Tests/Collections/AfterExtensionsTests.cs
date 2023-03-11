namespace Glitter.Extensions.Tests.Collections;

public class AfterExtensionsTests
{
    [Fact]
    public void SourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null!;

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => source!.After(searchValue: 1));
    }
    [Fact]
    public void SearchValueIsNull()
    {
        // Arrange
        IEnumerable<int?> source = new int?[] { 1, 2, 3 };

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => source.After(searchValue: null));
    }
    [Fact]
    public void SearchValueIsNotFound()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        IEnumerable<int> result = source.After(4);

        // Assert
        Assert.Empty(result);
    }
    [Fact]
    public void SearchValueIsFound()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        IEnumerable<int> result = source.After(2);

        // Assert
        Assert.Equal(new[] { 3 }, result);
    }
    [Fact]
    public void SearchValueIsFoundAtEnd()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        IEnumerable<int> result = source.After(3);

        // Assert
        Assert.Empty(result);
    }
    [Fact]
    public void SearchValueIsFoundAtBeginning()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        IEnumerable<int> result = source.After(1);

        // Assert
        Assert.Equal(new[] { 2, 3 }, result);
    }
    [Fact]
    public void SearchValueIsPresentMultipleTimes()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3, 2, 3 };

        // Act
        IEnumerable<int> result = source.After(2);

        // Assert
        Assert.Equal(new[] { 3, 2, 3 }, result);
    }
}