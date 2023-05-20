namespace Glitter.Extensions.Tests.Collections;

public class ForEachExtensionsTests
{
    [Fact]
    public async Task SourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null!;

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => source!.ForEach(input => { }));
        _ = Assert.Throws<ArgumentNullException>(() => source!.ForEach((previous, current, next) => { }));
        _ = await Assert.ThrowsAsync<ArgumentNullException>(() => source!.ForEach(input => { }, CancellationToken.None, parallel: false)).ConfigureAwait(false);
        _ = await Assert.ThrowsAsync<ArgumentNullException>(() => source!.ForEach(input => { }, CancellationToken.None, parallel: true)).ConfigureAwait(false);
    }

    [Fact]
    public async Task ActionIsNull()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };

        // Assert
        _ = Assert.Throws<ArgumentNullException>(() => source.ForEach((Action<int>)null!));
        _ = Assert.Throws<ArgumentNullException>(() => source.ForEach((Action<int, int, int>)null!));
        _ = await Assert.ThrowsAsync<ArgumentNullException>(() => source.ForEach(action: null!, CancellationToken.None, parallel: false)).ConfigureAwait(false);
        _ = await Assert.ThrowsAsync<ArgumentNullException>(() => source.ForEach(action: null!, CancellationToken.None, parallel: true)).ConfigureAwait(false);
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
        await source.ForEach(expected.Add, CancellationToken.None, parallel: false).ConfigureAwait(false);
        await source.ForEach(expected.Add, CancellationToken.None, parallel: true).ConfigureAwait(false);

        // Assert
        int testCount = 4;
        Assert.True(source.All(x => expected.Count(y => y == x) == testCount));
    }
}