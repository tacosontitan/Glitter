using Glitter.Sql;

namespace Glitter.Tests.Sql;

public class SqlFunctionTests
{
    [Fact]
    public void Query()
    {
        var request = new SqlFunction("SELECT * FROM [dbo].[dummy]");
        var provider = new MockService();
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
        var request = new SqlFunction("SELECT * FROM [dbo].[dummy]");
        var provider = new MockService();
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
        var request = new SqlFunction("SELECT * FROM [dbo].[dummy]");
        var provider = new MockService();
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