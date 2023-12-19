using Glitter.Collections;

namespace Glitter.Tests.Collections;

public class EnumerableForEachExtensionsTests
{
    [Fact]
    public async Task SourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null!;

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => source!.ForEach(input => { }));
        _ = Assert.Throws<ArgumentNullException>(() => source!.ForEach((previous, current, next) => { }));
        _ = await Assert
            .ThrowsAsync<ArgumentNullException>(() => source!.ForEach(input => { }, false, CancellationToken.None))
            .ConfigureAwait(false);
        _ = await Assert
            .ThrowsAsync<ArgumentNullException>(() => source!.ForEach(input => { }, true, CancellationToken.None))
            .ConfigureAwait(false);
    }

    [Fact]
    public async Task ActionIsNull()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => source.ForEach((Action<int>)null!));
        _ = Assert.Throws<ArgumentNullException>(() => source.ForEach((Action<int, int, int>)null!));
        _ = await Assert.ThrowsAsync<ArgumentNullException>(() => source.ForEach(null!, false, CancellationToken.None))
            .ConfigureAwait(false);
        _ = await Assert.ThrowsAsync<ArgumentNullException>(() => source.ForEach(null!, true, CancellationToken.None))
            .ConfigureAwait(false);
    }

    [Fact]
    public async Task ActionIsInvoked()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };
        var expected = new List<int>();

        // Act
        source.ForEach(expected.Add);
        source.ForEach((previous, current, next) => expected.Add(current));
        await source.ForEach(expected.Add, false, CancellationToken.None).ConfigureAwait(false);
        await source.ForEach(expected.Add, true, CancellationToken.None).ConfigureAwait(false);

        // Assert
        int testCount = 4;
        Assert.True(source.All(x => expected.Count(y => y == x) == testCount));
    }
}