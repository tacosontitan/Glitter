//using Glitter.Extensions;

//namespace Glitter.Tests.Extensions;

//public class IEnumerableForEachTests
//{
//    [Fact]
//    public void SourceIsNull()
//    {
//        IEnumerable<int>? source = null;
//        Assert.Throws<ArgumentNullException>(() => source!.ForEach(_ => { }));
//    }
//    [Fact]
//    public void ActionIsNull()
//    {
//        IEnumerable<int> source = Enumerable.Range(0, 10);
//        Assert.Throws<ArgumentNullException>(() => source!.ForEach(null!));
//    }
//    [Fact]
//    public void EachElementIsUtilized()
//    {
//        IEnumerable<int> source = Enumerable.Range(0, 10);
//        source.ForEach(i => Assert.Equal(i, source.ElementAt(i)));
//    }
//}