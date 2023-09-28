# 🗻 Glitter

Named after the second largest mountain in Norway, Glitter is a simple framework for encapsulating functionality to keep implementations clean, concise, and optimized.

![License](https://img.shields.io/github/license/tacosontitan/Glitter?logo=github&style=for-the-badge)

## 💁‍♀️ Getting Started

Get started by reviewing the answers to the following questions:

- [How do I navigate the codebase with confidence?](http://glitter.tacosontitan.com)
- [How can I help?](./CONTRIBUTING.md)
- [How should I behave here?](./CODE_OF_CONDUCT.md)
- [How do I report security concerns?](./SECURITY.md)

### ✅ Small changes, continuously integrated

Glitter employs workflows for continuous integration to ensure the repository is held to industry standards; here's the current state of those workflows:

![.NET Workflow](https://img.shields.io/github/actions/workflow/status/tacosontitan/Glitter/dotnet.yml?label=Build%20and%20Test&logo=dotnet&style=for-the-badge)

### 💎 A few more gems

We believe in keeping the community informed, so here's a few more tidbits of information to satisfy some additional curiosities:

![Contributors](https://img.shields.io/github/contributors/tacosontitan/Glitter?logo=github&style=for-the-badge)
![Issues](https://img.shields.io/github/issues/tacosontitan/Glitter?logo=github&style=for-the-badge)
![Stars](https://img.shields.io/github/stars/tacosontitan/Glitter?logo=github&style=for-the-badge)

## 🛢️ Encapsulating SQL Requests

Glitter offers several ways to encapsulate SQL requests:

- [SqlStoredProcedure](./src/Glitter.Sql/Encapsulation/SqlStoredProcedure.cs)
- [SqlTableFunction](./src/Glitter.Sql/Encapsulation/SqlTableFunction.cs)
- [SqlScalarFunction](./src/Glitter.Sql/Encapsulation/SqlScalarFunction.cs)
- [SqlScript](./src/Glitter.Sql/Encapsulation/SqlScript.cs)

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
