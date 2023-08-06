using Glitter.Text;

namespace Glitter.Tests.Text;

public class SubstringReaderTests
{
    [Fact]
    public void Constructor_NullSource_ThrowsArgumentException()
    {
        // Arrange
        string? sample = null;
        
        // Act
        void TestAction() =>
            _ = new SubstringReader(source: sample!);

        // Assert
        Assert.Throws<ArgumentException>(TestAction);
    }
}
