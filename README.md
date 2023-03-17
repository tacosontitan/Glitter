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
![Size](https://img.shields.io/github/languages/code-size/tacosontitan/Glitter?logo=github&style=for-the-badge)
![Line Count](https://img.shields.io/tokei/lines/github/tacosontitan/Glitter?logo=github&style=for-the-badge)

## 💠 Pipelines

Glitter offers a way to encapsulate the chain of responsibility pattern in a way that is easy to understand and maintain through what we call a pipeline. A pipeline is a collection of processors that are executed in order, and each processor can choose to handle the request or pass it on to the next processor in the chain. This allows for a clean separation of concerns, and the ability to easily add or remove processors from the pipeline.

```csharp
IPipeline<int> fizzBuzzPipeline = CreatePipeline.For<int>(optimize: true)
    .Using<FizzBuzzProcessor>()
    .Using<FizzProcessor>()
    .Using<BuzzProcessor>()
    .Using<DefaultProcessor>();

foreach (int number in Enumerable.Range(1, 100))
    await fizzBuzzPipeline.Process(number);
```

## 🛡️ Guard Clauses

Guard clauses are used to validate input parameters to a method:

```csharp
[HttpGet]
public async Task<User> GetUserById(Guid id)
{
    if (id == Guid.Empty)
        throw new ArgumentException($"The specified value `{id}` is invalid.", nameof(id));

    ...
}
```

Glitters offers two classes (`GuardedValue` and `CreateGuard`) that are utilized to create fluent guard clauses through extension methods which enables rapid development of guard clauses that are easy to read and maintain:

```csharp
public record Sample(int Value);
public void ProcessSample(Sample? sample)
{
    CreateGuard.For(sample.Value, nameof(sample.Value))
        .AgainstNull()
        .AgainstLessThan(0)
        .AgainstGreaterThan(100)
        .Against(val => val == 3)
        .Against(val => val % 2 == 0, "Number must be odd");
}
```

## 📝 Simplified Serialization

Glitter offers a common interface for serializing and deserializing objects to and from any format:

```csharp
using Newtonsoft.Json;
internal sealed class JsonSerializationProvider : ISerializationProvider
{
    public string Serialize<T>(T value) => JsonConvert.SerializeObject(value);
    public T Deserialize<T>(string value) => JsonConvert.DeserializeObject<T>(value);
}
```

This affords consumers the ability to easily swap out the serialization provider without having to change any code:

```csharp
ISerializationProvider serializationProvider = new JsonSerializationProvider();
...
string serializedSample = serializationProvider.Serialize(new ComplexSampleObject());
ComplexSampleObject parsedSample = serializationProvider.Deserialize<ComplexSampleObject>(serializedSample);
```

The driving force behind this is to allow consumers to utilize extension methods that serve to simplify the serialization process:

```csharp
var sample = new ComplexSampleObject();
...
string json = sample.Serialize<JsonSerializationProvider>();
ComplexSampleObject parsedSample = json.Deserialize<ComplexSampleObject, JsonSerializationProvider>();
```

## 🛢️ SQL Encapsulation

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
