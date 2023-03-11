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

- `After`
  - Returns all elements after a specified search value or predicate.
- `ForEach`
  - `ForEach<T>(this IEnumerable<T>, Action<T>)`
    - Replicates the `ForEach` extension method for `List<T>`.
  - `ForEach<T>(this IEnumerable<T>, Action<T?, T?, T?>)`
    - Provides the previous and next elements.
  - `ForEach<T>(this IEnumerable<T>, Action<T>, CancellationToken, bool)`
    - Allows asynchronous iteration with cancellation and parallelism support.
- `IndexOf`
  - Returns the index of the first element that matches a specified search value or predicate.
- `SelectDistinct`
  - Returns a distinct set of elements based on a specified selector.

## Extensions for `IComparable`

- `Constrain`
  - Returns a specified value, constrained to a given range.
- `WithinRange`
  - Returns a value indicating whether a specified value is within a given range.
