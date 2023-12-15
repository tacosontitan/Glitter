using Glitter.Collections;

namespace Glitter.Tests.Collections;

public class QueueExtensionsTests
{
    [Fact]
    public void Dequeue_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        Queue<int>? source = null;
        int count = 10;

        // Act
        void TestDequeue()
        {
            QueueExtensions.Dequeue(source!, count);
        }

        // Assert
        _ = Assert.Throws<ArgumentNullException>(TestDequeue);
    }

    [Fact]
    public void Dequeue_ThrowsArgumentOutOfRangeException_WhenCountIsLessThanZero()
    {
        // Arrange
        Queue<int>? source = new();
        int count = -1;

        // Act
        void TestDequeue()
        {
            source.Dequeue(count);
        }

        // Assert
        _ = Assert.Throws<ArgumentOutOfRangeException>(TestDequeue);
    }

    [Fact]
    public void Dequeue_ThrowsArgumentOutOfRangeException_WhenCountIsGreaterThanSourceCount()
    {
        // Arrange
        Queue<int>? source = new();
        int count = 1;

        // Act
        void TestDequeue()
        {
            source.Dequeue(count);
        }

        // Assert
        _ = Assert.Throws<ArgumentOutOfRangeException>(TestDequeue);
    }

    [Fact]
    public void Dequeue_DoesNotDequeueItems_WhenSourceIsNotNullAndCountIsZero()
    {
        // Arrange
        Queue<int>? source = new();
        int count = 0;

        // Act
        _ = source.Enqueue(Enumerable.Range(0, 10));
        _ = source.Dequeue(count);

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
        _ = source.Enqueue(Enumerable.Range(0, 10));
        IEnumerable<int> result = source.Dequeue(count);

        // Assert
        _ = Assert.Single(result);
        Assert.Equal(9, source.Count);
    }

    [Fact]
    public void Dequeue_DequeuesMultipleItems_WhenSourceIsNotNullAndCountIsGreaterThanOne()
    {
        // Arrange
        Queue<int>? source = new();
        int count = 5;

        // Act
        _ = source.Enqueue(Enumerable.Range(0, 10));
        IEnumerable<int> result = source.Dequeue(count);

        // Assert
        Assert.Equal(5, result.Count());
        Assert.Equal(5, source.Count);
    }

    [Fact]
    public void EnqueueEnumerable_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        Queue<int>? source = null;
        IEnumerable<int>? items = Enumerable.Range(0, 10);

        // Act
        void TestEnqueue()
        {
            source!.Enqueue(items!);
        }

        // Assert
        _ = Assert.Throws<ArgumentNullException>(TestEnqueue);
    }

    [Fact]
    public void EnqueueEnumerable_ThrowsArgumentNullException_WhenItemsIsNull()
    {
        // Arrange
        Queue<int>? source = new();
        IEnumerable<int>? items = null;

        // Act
        void TestEnqueue()
        {
            source!.Enqueue(items!);
        }

        // Assert
        _ = Assert.Throws<ArgumentNullException>(TestEnqueue);
    }

    [Fact]
    public void EnqueueEnumerable_EnqueuesItems_WhenSourceIsNotNull()
    {
        // Arrange
        Queue<int>? source = new();
        IEnumerable<int>? items = Enumerable.Range(0, 10);

        // Act
        _ = source!.Enqueue(items!);

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
        _ = source!.Enqueue(items!);

        // Assert
        Assert.Empty(source);
    }

    [Fact]
    public void EnqueueParams_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        Queue<int>? source = null;

        // Act
        void TestEnqueue()
        {
            source!.Enqueue(0, 1, 2);
        }

        // Assert
        _ = Assert.Throws<ArgumentNullException>(TestEnqueue);
    }

    [Fact]
    public void EnqueueParams_ThrowsArgumentNullException_WhenItemsIsNull()
    {
        // Arrange
        Queue<int>? source = new();

        // Act
        void TestEnqueue()
        {
            source!.Enqueue(null!);
        }

        // Assert
        _ = Assert.Throws<ArgumentNullException>(TestEnqueue);
    }

    [Fact]
    public void EnqueueParams_EnqueuesItems_WhenSourceIsNotNull()
    {
        // Arrange
        Queue<int>? source = new();

        // Act
        _ = source!.Enqueue(0, 1, 2);

        // Assert
        Assert.Equal(3, source.Count);
    }

    [Fact]
    public void EnqueueParams_DoesNotEnqueueItems_WhenSourceIsNotNullAndItemsIsEmpty()
    {
        // Arrange
        Queue<int>? source = new();

        // Act
        _ = source!.Enqueue();

        // Assert
        Assert.Empty(source);
    }
}