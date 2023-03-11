namespace Glitter.Extensions.Collections.Tests;

public class SelectDistinctExtensionsTests
{
    [Fact]
    public void SourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null!;

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => source!.SelectDistinct(input => input));
    }
    [Fact]
    public void SelectorIsNull()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => source.SelectDistinct<int, int>(selector: null!));
    }
    [Fact]
    public void SourceIsEmpty()
    {
        // Arrange
        IEnumerable<int> source = new int[0];

        // Act
        IEnumerable<int> result = source.SelectDistinct(input => input);

        // Assert
        Assert.Empty(result);
    }
    [Fact]
    public void SourceHasOneItem()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1 };

        // Act
        IEnumerable<int> result = source.SelectDistinct(input => input);

        // Assert
        var expected = new[] { 1 };
        Assert.Equal(expected, result);
    }
    [Fact]
    public void SourceHasMultipleItems()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3, 2, 1 };

        // Act
        IEnumerable<int> result = source.SelectDistinct(input => input);

        // Assert
        var expected = new[] { 1, 2, 3 };
        Assert.Equal(expected, result);
    }
    [Fact]
    public void SourceHasMultipleItemsWithSelector()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3, 2, 1 };

        // Act
        IEnumerable<int> result = source.SelectDistinct(input => input % 2);

        // Assert
        var expected = new[] { 1, 0 };
        Assert.Equal(expected, result);
    }
}