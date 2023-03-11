# 🗻 Glitter

Named after the second largest mountain in Norway, Glitter is a simple framework for encapsulating functionality to keep implementations clean, concise, and optimized.

![License](https://img.shields.io/github/license/tacosontitan/Glitter.Extensions?logo=github&style=for-the-badge)

## 💁‍♀️ Getting Started

Get started by reviewing the answers to the following questions:

- [How do I navigate the codebase with confidence?](http://glitter.tacosontitan.com)
- [How can I help?](./CONTRIBUTING.md)
- [How should I behave here?](./CODE_OF_CONDUCT.md)
- [How do I report security concerns?](./SECURITY.md)

### ✅ Small changes, continuously integrated

Glitter employs workflows for continuous integration to ensure the repository is held to industry standards; here's the current state of those workflows:

![.NET Workflow](https://img.shields.io/github/actions/workflow/status/tacosontitan/Glitter.Extensions/dotnet.yml?label=Build%20and%20Test&logo=dotnet&style=for-the-badge)

### 💎 A few more gems

We believe in keeping the community informed, so here's a few more tidbits of information to satisfy some additional curiosities:

![Contributors](https://img.shields.io/github/contributors/tacosontitan/Glitter.Extensions?logo=github&style=for-the-badge)
![Issues](https://img.shields.io/github/issues/tacosontitan/Glitter.Extensions?logo=github&style=for-the-badge)
![Stars](https://img.shields.io/github/stars/tacosontitan/Glitter.Extensions?logo=github&style=for-the-badge)
![Size](https://img.shields.io/github/languages/code-size/tacosontitan/Glitter.Extensions?logo=github&style=for-the-badge)
![Line Count](https://img.shields.io/tokei/lines/github/tacosontitan/Glitter.Extensions?logo=github&style=for-the-badge)

## Generic Extensions

### `In`

Returns a value indicating whether a specified search value is present in a given collection of params values:

```csharp
int value = 1;
bool result = value.In(1, 2, 3);
Console.WriteLine(result);
```

## Extensions for `IEnumerable<T>`

### `After`

Returns all elements after a specified search value or predicate:

```csharp
IEnumerable<int> values = new[] { 1, 2, 3, 4, 5 };

// Using a search value:
IEnumerable<int> resultDirect = values.After(2);
Console.WriteLine(string.Join(", ", resultDirect));

// Using a predicate:
IEnumerable<int> resultPredicate = values.After(x => x == 2);
Console.WriteLine(string.Join(", ", resultPredicate));
```

### `ForEach`

Provides a set of extension methods for iterating over a collection of elements:

```csharp
IEnumerable<int> values = new[] { 1, 2, 3, 4, 5 };

// Using a synchronous action:
values.ForEach(x => Console.WriteLine(x));

// Using previous, current, and next elements:
values.ForEach((previous, current, next) => Console.WriteLine($"{previous}, {current}, {next}"));

// Using an asynchronous action with parallelism and cancellation support:
await values.ForEach(input => Console.WriteLine(input), cancellationToken, parallel: true);
```

- `IndexOf`
  - Returns the index of the first element that matches a specified search value or predicate.
- `SelectDistinct`
  - Returns a distinct set of elements based on a specified selector.

## Extensions for `IComparable`

- `Constrain`
  - Returns a specified value, constrained to a given range.
- `WithinRange`
  - Returns a value indicating whether a specified value is within a given range.
