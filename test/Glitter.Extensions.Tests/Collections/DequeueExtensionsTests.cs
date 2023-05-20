namespace Glitter.Extensions.Tests.Collections;

public class DequeueExtensionsTests
{
    [Fact]
    public void Dequeue_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        Queue<int>? source = null;
        int count = 10;

        // Act
        Action action = () => source!.Dequeue(count);

        // Assert
        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void Dequeue_ThrowsArgumentOutOfRangeException_WhenCountIsLessThanZero()
    {
        // Arrange
        Queue<int>? source = new();
        int count = -1;

        // Act
        Action action = () => source!.Dequeue(count);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void Dequeue_ThrowsArgumentOutOfRangeException_WhenCountIsGreaterThanSourceCount()
    {
        // Arrange
        Queue<int>? source = new();
        int count = 1;

        // Act
        Action action = () => source!.Dequeue(count);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void Dequeue_DoesNotDequeueItems_WhenSourceIsNotNullAndCountIsZero()
    {
        // Arrange
        Queue<int>? source = new();
        int count = 0;

        // Act
        source!.Enqueue(Enumerable.Range(0, 10));
        source.Dequeue(count);

        // Assert
        Assert.Equal(10, source.Count);
    }

    [Fact]
    public void Dequeue_DequeuesOneItem_WhenSourceIsNotNullAndCountIsEqualToOne()
    {
        // Arrange
        Queue<int>? source = new();
        int count = 1;

        // Act
        source!.Enqueue(Enumerable.Range(0, 10));
        IEnumerable<int> result = source.Dequeue(count);

        // Assert
        Assert.Equal(1, result.Count());
        Assert.Equal(9, source.Count);
    }

    [Fact]
    public void Dequeue_DequeuesMultipleItems_WhenSourceIsNotNullAndCountIsGreaterThanOne()
    {
        // Arrange
        Queue<int>? source = new();
        int count = 5;

        // Act
        source!.Enqueue(Enumerable.Range(0, 10));
        IEnumerable<int> result = source.Dequeue(count);

        // Assert
        Assert.Equal(5, result.Count());
        Assert.Equal(5, source.Count);
    }
}
