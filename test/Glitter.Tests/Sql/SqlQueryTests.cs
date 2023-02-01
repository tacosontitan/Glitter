using Glitter.Sql;

namespace Glitter.Tests.Sql;

public class SqlQueryTests
{
    [Fact]
    public void Query()
    {
        var request = new SqlQuery("SELECT * FROM [dbo].[dummy]");
        var provider = new MockProvider();
        try
        {
            _ = provider.Query<object>(request);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
    [Fact]
    public void Scalar()
    {
        var request = new SqlQuery("SELECT * FROM [dbo].[dummy]");
        var provider = new MockProvider();
        try
        {
            _ = provider.ExecuteScalar<object>(request);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
    [Fact]
    public void Execute()
    {
        var request = new SqlQuery("SELECT * FROM [dbo].[dummy]");
        var provider = new MockProvider();
        try
        {
            provider.Execute(request);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
}