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
        _ = Assert.Throws<ArgumentNullException>(() => source!.After(input => input == 1));
    }
    
    [Fact]
    public void SearchValueIsNull()
    {
        // Arrange
        IEnumerable<int?> source = new int?[] { 1, 2, 3 };

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => source.After(searchValue: null!));
        _ = Assert.Throws<ArgumentNullException>(() => source.After(predicate: null!));
    }
    
    [Fact]
    public void SearchValueIsNotFound()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        IEnumerable<int> resultDirect = source.After(4);
        IEnumerable<int> resultPredicate = source.After(input => input == 4);

        // Assert
        Assert.Empty(resultDirect);
        Assert.Empty(resultPredicate);
    }
    
    [Fact]
    public void SearchValueIsFound()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        IEnumerable<int> resultDirect = source.After(2);
        IEnumerable<int> resultPredicate = source.After(input => input == 2);

        // Assert
        int[] expected = new[] { 3 };
        Assert.Equal(expected, resultDirect);
        Assert.Equal(expected, resultPredicate);
    }
    
    [Fact]
    public void SearchValueIsFoundAtEnd()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        IEnumerable<int> resultDirect = source.After(3);
        IEnumerable<int> resultPredicate = source.After(input => input == 3);

        // Assert
        Assert.Empty(resultDirect);
        Assert.Empty(resultPredicate);
    }
    
    [Fact]
    public void SearchValueIsFoundAtBeginning()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Act
        IEnumerable<int> resultDirect = source.After(1);
        IEnumerable<int> resultPredicate = source.After(input => input == 1);

        // Assert
        int[] expected = new[] { 2, 3 };
        Assert.Equal(expected, resultDirect);
        Assert.Equal(expected, resultPredicate);
    }
    
    [Fact]
    public void SearchValueIsPresentMultipleTimes()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3, 2, 3 };

        // Act
        IEnumerable<int> result = source.After(2);
        IEnumerable<int> resultPredicate = source.After(input => input == 2);

        // Assert
        int[] expected = new[] { 3, 2, 3 };
        Assert.Equal(expected, result);
        Assert.Equal(expected, resultPredicate);
    }
}