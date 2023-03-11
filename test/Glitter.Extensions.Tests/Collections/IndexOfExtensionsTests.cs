namespace Glitter.Extensions.Collections.Tests;

public class IndexOfExtensionsTests
{
    [Fact]
    public void SourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null!;

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => source!.IndexOf(searchValue: 1));
        _ = Assert.Throws<ArgumentNullException>(() => source!.IndexOf(input => input == 1));
    }
    [Fact]
    public void SearchValueIsNull()
    {
        // Arrange
        IEnumerable<int?> source = new int?[] { 1, 2, 3 };

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => source.IndexOf(searchValue: null!));
        _ = Assert.Throws<ArgumentNullException>(() => source.IndexOf(predicate: null!));
    }
    [Fact]
    public void SearchValueIsNotFound()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        int resultDirect = source.IndexOf(4);
        int resultPredicate = source.IndexOf(input => input == 4);

        // Assert
        Assert.Equal(-1, resultDirect);
        Assert.Equal(-1, resultPredicate);
    }
    [Fact]
    public void SearchValueIsFound()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        int resultDirect = source.IndexOf(2);
        int resultPredicate = source.IndexOf(input => input == 2);

        // Assert
        Assert.Equal(1, resultDirect);
        Assert.Equal(1, resultPredicate);
    }
    [Fact]
    public void SearchValueIsFoundAtEnd()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        int resultDirect = source.IndexOf(3);
        int resultPredicate = source.IndexOf(input => input == 3);

        // Assert
        Assert.Equal(2, resultDirect);
        Assert.Equal(2, resultPredicate);
    }
    [Fact]
    public void SearchValueIsFoundAtStart()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        int resultDirect = source.IndexOf(1);
        int resultPredicate = source.IndexOf(input => input == 1);

        // Assert
        Assert.Equal(0, resultDirect);
        Assert.Equal(0, resultPredicate);
    }
}