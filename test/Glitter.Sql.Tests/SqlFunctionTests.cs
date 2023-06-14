using Glitter.Sql;

namespace Glitter.Tests.Sql;

public class SqlFunctionTests
{
    [Fact]
    public void Query()
    {
        var request = new SqlFunction("SELECT * FROM [dbo].[dummy]");
        var service = new MockService();
        try
        {
            _ = service.Query<object>(request);
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
        var service = new MockService();
        try
        {
            _ = service.ExecuteScalar<object>(request);
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
        var service = new MockService();
        try
        {
            service.Execute(request);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
}