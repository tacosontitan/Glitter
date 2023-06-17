# 🗻 Glitter.Sql

Named after the second largest mountain in Norway, Glitter is a simple framework for encapsulating functionality to keep implementations clean, concise, and optimized. The SQL project is designed to help encapsulate and interactions with SQL for those who do not have access to more advanced ORMs like Entity Framework.

![License](https://img.shields.io/github/license/tacosontitan/Glitter.Sql?logo=github&style=for-the-badge)

## 💁‍♀️ Getting Started

Get started by reviewing the answers to the following questions:

- [How do I navigate the codebase with confidence?](http://glitter.tacosontitan.com)
- [How can I help?](./CONTRIBUTING.md)
- [How should I behave here?](./CODE_OF_CONDUCT.md)
- [How do I report security concerns?](./SECURITY.md)

### ✅ Small changes, continuously integrated

Glitter employs workflows for continuous integration to ensure the repository is held to industry standards; here's the current state of those workflows:

![.NET Workflow](https://img.shields.io/github/actions/workflow/status/tacosontitan/Glitter.Sql/dotnet.yml?label=Build%20and%20Test&logo=dotnet&style=for-the-badge)

### 💎 A few more gems

We believe in keeping the community informed, so here's a few more tidbits of information to satisfy some additional curiosities:

![Contributors](https://img.shields.io/github/contributors/tacosontitan/Glitter.Sql?logo=github&style=for-the-badge)
![Issues](https://img.shields.io/github/issues/tacosontitan/Glitter.Sql?logo=github&style=for-the-badge)
![Stars](https://img.shields.io/github/stars/tacosontitan/Glitter.Sql?logo=github&style=for-the-badge)
![Size](https://img.shields.io/github/languages/code-size/tacosontitan/Glitter.Sql?logo=github&style=for-the-badge)
![Line Count](https://img.shields.io/tokei/lines/github/tacosontitan/Glitter.Sql?logo=github&style=for-the-badge)

## 🛢️ Encapsulating SQL Requests

Glitter offers several ways to encapsulate SQL requests:

- [SqlStoredProcedure](./src/Glitter.Sql/Encapsulation/SqlStoredProcedure.cs)
- [TableValuedSqlFunction](./src/Glitter.Sql/Encapsulation/TableValuedSqlFunction.cs)
- [ScalarValuedSqlFunction](./src/Glitter.Sql/Encapsulation/ScalarValuedSqlFunction.cs)
- [SqlQuery](./src/Glitter.Sql/Encapsulation/SqlQuery.cs)

The encapsulation strategy employed by Glitter is definition driven. This means that your encapsulations simply define a request to execute a stored procedure, function, or query. The encapsulation does not actually execute the request, but rather provides a means to execute the request. For example, the following encapsulation defines a request to execute a stored procedure:

```csharp
public class UserInsertRequest
    : SqlStoredProcedure
{
    public UserInsertRequest(string username, string givenName, string surname)
        : base(schema: "Sample", name: "UserInsert")
    {
        _ = AddParameter("Username", username, DbType.String, length: 100);
        _ = AddParameter("GivenName", givenName, DbType.String, length: 100);
        _ = AddParameter("Surname", surname, DbType.String, length: 100);
    }
}
```
