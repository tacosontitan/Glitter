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

## 🛢️ Working with SQL

Glitter offers several ways to encapsulate SQL requests, including a fluent interface for building queries.

### 📜 Building a Query

The following example shows how to build a query that returns a list of users based on a given filter.

```csharp
public void DoSomething()
{
    var query = CreateQuery.For<User>()
        .From(schema: "Accounting", target: "Users")
        .WhereLike(user => user.FirstName, "Hazel");
    var users = await _sqlService.Query<User>(query);
}
```

This results in a query that looks like the following:

```sql
SELECT *
FROM [Accounting].[Users]
WHERE [FirstName] LIKE @FirstName
```

For more information on how to build queries, see the [Query Builder](https://github.com/tacosontitan/Glitter/wiki) documentation.

### 🗃️ Encapsulating a Function

The following example shows how to encapsulate a function that returns a list of users based on a filter, page, and page size.

```csharp
internal sealed class UsersQuery : SqlFunction, IRequest<IEnumerable<User>>
{
    public UsersQuery(string filter = null, int? page = null, int? pageSize = null) :
        base(schema: "Accounting", functionName: "UsersQuery")
    {
        AddParameterIfNotNullOrWhiteSpace("Filter", filter, DbType.String, size: 255);
        AddParameterIfNotNull("Page", page);
        AddParameterIfNotNull("PageSize", pageSize);
    }
}
internal sealed class UsersQueryHandler : IRequestHandler<UsersQuery, IEnumerable<User>>
{
    private readonly SqlService _sqlService;
    public UsersQueryHandler(SqlService sqlService) => _sqlService = sqlService;
    public async Task<IEnumerable<User>> Handle(UsersQuery request, CancellationToken cancellationToken) =>
        await _sqlService.Query<User>(query, cancellationToken);
}
```
