using Glitter.Sql;

namespace Glitter.Tests.Sql;

public class SqlProcedureTests
{
    [Fact]
    public void Query()
    {
        var request = new SqlProcedure("[dummy]");
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
        var request = new SqlProcedure("[dummy]");
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
        var request = new SqlProcedure("[dummy]");
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