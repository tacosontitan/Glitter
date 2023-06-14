using Glitter.Sql;

namespace Glitter.Tests.Sql;

public class SqlRequestTests
{
    [Fact]
    public void TextQuery()
    {
        var request = new SqlRequest("SELECT * FROM [dbo].[dummy]", System.Data.CommandType.Text);
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
    public void TableDirectQuery()
    {
        var request = new SqlRequest("[dbo].[dummy]", System.Data.CommandType.TableDirect);
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
    public void ProcedureQuery()
    {
        var request = new SqlRequest("[dummy]", System.Data.CommandType.StoredProcedure);
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
    public void TextScalar()
    {
        var request = new SqlRequest("SELECT * FROM [dbo].[dummy]", System.Data.CommandType.Text);
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
    public void TableDirectScalar()
    {
        var request = new SqlRequest("[dbo].[dummy]", System.Data.CommandType.TableDirect);
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
    public void ProcedureScalar()
    {
        var request = new SqlRequest("[dummy]", System.Data.CommandType.StoredProcedure);
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
    public void TextExecute()
    {
        var request = new SqlRequest("SELECT * FROM [dbo].[dummy]", System.Data.CommandType.Text);
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
    [Fact]
    public void TableDirectExecute()
    {
        var request = new SqlRequest("[dbo].[dummy]", System.Data.CommandType.TableDirect);
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
    [Fact]
    public void ProcedureExecute()
    {
        var request = new SqlRequest("[dummy]", System.Data.CommandType.StoredProcedure);
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