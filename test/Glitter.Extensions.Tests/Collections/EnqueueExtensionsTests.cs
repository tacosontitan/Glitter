namespace Glitter.Extensions.Tests.Collections;

public class EnqueueExtensionsTests
{
    [Fact]
    public void EnqueueEnumerable_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        Queue<int>? source = null;
        IEnumerable<int>? items = Enumerable.Range(0, 10);

        // Act
        Action action = () => source!.Enqueue(items!);

        // Assert
        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void EnqueueEnumerable_ThrowsArgumentNullException_WhenItemsIsNull()
    {
        // Arrange
        Queue<int>? source = new();
        IEnumerable<int>? items = null;

        // Act
        Action action = () => source!.Enqueue(items!);

        // Assert
        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void EnqueueEnumerable_EnqueuesItems_WhenSourceIsNotNull()
    {
        // Arrange
        Queue<int>? source = new();
        IEnumerable<int>? items = Enumerable.Range(0, 10);

        // Act
        source!.Enqueue(items!);

        // Assert
        Assert.Equal(10, source.Count);
    }

    [Fact]
    public void EnqueueEnumerable_DoesNotEnqueueItems_WhenSourceIsNotNullAndItemsIsEmpty()
    {
        // Arrange
        Queue<int>? source = new();
        IEnumerable<int>? items = Enumerable.Empty<int>();

        // Act
        source!.Enqueue(items!);

        // Assert
        Assert.Equal(0, source.Count);
    }

    [Fact]
    public void EnqueueParams_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        Queue<int>? source = null;

        // Act
        Action action = () => source!.Enqueue(0, 1, 2);

        // Assert
        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void EnqueueParams_ThrowsArgumentNullException_WhenItemsIsNull()
    {
        // Arrange
        Queue<int>? source = new();

        // Act
        Action action = () => source!.Enqueue(null!);

        // Assert
        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void EnqueueParams_EnqueuesItems_WhenSourceIsNotNull()
    {
        // Arrange
        Queue<int>? source = new();

        // Act
        source!.Enqueue(0, 1, 2);

        // Assert
        Assert.Equal(3, source.Count);
    }

    [Fact]
    public void EnqueueParams_DoesNotEnqueueItems_WhenSourceIsNotNullAndItemsIsEmpty()
    {
        // Arrange
        Queue<int>? source = new();

        // Act
        source!.Enqueue();

        // Assert
        Assert.Equal(0, source.Count);
    }
}
