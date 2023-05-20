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
        void TestEnqueue() => source!.Enqueue(items!);

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
        void TestEnqueue() => source!.Enqueue(items!);

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
        void TestEnqueue() => source!.Enqueue(0, 1, 2);

        // Assert
        _ = Assert.Throws<ArgumentNullException>(TestEnqueue);
    }

    [Fact]
    public void EnqueueParams_ThrowsArgumentNullException_WhenItemsIsNull()
    {
        // Arrange
        Queue<int>? source = new();

        // Act
        void TestEnqueue() => source!.Enqueue(null!);

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
