/*
   Copyright 2023 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

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