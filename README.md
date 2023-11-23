# 🗻 Glitter

Named after the second largest mountain in Norway, Glitter is a simple framework for encapsulating functionality to keep implementations clean, concise, and optimized.

![License](https://img.shields.io/github/license/tacosontitan/Glitter?logo=github&style=for-the-badge)

> [!IMPORTANT]
> This repository is undergoing a consolidation effort. As a result some things may feel out of place, or incomplete. Please be patient as we work to bring everything together.*

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

## 🛣️ What does the future hold

The future of Glitter is bright, and we're excited to share our roadmap with you. It all starts with a simple consolidation effort:

- [x] Import the old `Glitter.Extensions` repo.
  - [x] Add the old repo to this one.
  - [x] Find proper namespaces for existing extensions.
  - [x] Move files from the dedicated project into the primary project.
  - [x] Consolidate unit tests.
- [ ] Import the old `Glitter.Sql` repo.
  - [x] Add the old repo to this one.
  - [x] Create the official `Glitter.Data.Sql` namespace in the `Glitter` project.
  - [ ] Move files from the dedicated project into the primary project.
  - [ ] Consolidate unit tests.

Our next steps involve adding new features to the consolidated repo:

- [ ] Add support for encapsulation of individual workloads.
- [ ] Complete support for encapsulated SQL interactions.
- [ ] Add support for pipelines.
- [ ] Add support for encapsulated API interactions.
- [ ] Add support for encapsulated file interactions.

These particular features have a long way to go, but we're excited to discuss them and get your feedback in our discussions area.

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

## 🔥 What `Glitter.Extensions` has to offer

> [!WARNING]
> This section contains broken links. Please be patient as we work to bring this repo up-to standards and determine our roadmap.

- Select extension methods for generic types.
  - [`In`](https://github.com/tacosontitan/Glitter.Extensions/wiki/Glitter.Extensions.Generics#in)
- Extension methods for `IEnumerable<T>`.
  - [`After`](https://github.com/tacosontitan/Glitter.Extensions/wiki/Glitter.Extensions.Collections#after)
  - [`ForEach`](https://github.com/tacosontitan/Glitter.Extensions/wiki/Glitter.Extensions.Collections#foreach)
  - [`IndexOf`](https://github.com/tacosontitan/Glitter.Extensions/wiki/Glitter.Extensions.Collections#indexof)
  - [`SelectDistinct`](https://github.com/tacosontitan/Glitter.Extensions/wiki/Glitter.Extensions.Collections#selectdistinct)
- Extension methods for `IComparable`.
  - [`Constrain`](https://github.com/tacosontitan/Glitter.Extensions/wiki/Glitter.Extensions#constrain)
  - [`WithinRange`](https://github.com/tacosontitan/Glitter.Extensions/wiki/Glitter.Extensions#withinrange)
- Extension methods for `Queue<T>`.
  - [`Enqueue`](https://github.com/tacosontitan/Glitter.Extensions/wiki/Glitter.Extensions.Collections#enqueue)
  - [`Dequeue`](https://github.com/tacosontitan/Glitter.Extensions/wiki/Glitter.Extensions.Collections#dequeue)

## 📝 Release Notes (Glitter.Extensions)

- 2023.5.21
  - Fixed a bug with dequeue extensions not validating until enumerated.
  - Added overloads for the `In` extension.
  - Added explicit support of `.NET Standard 2.1`.
  - Added explicit support of `.NET Framework 4.8`.
  - Added explicit support of `.NET 6`.
  - Added explicit support of `.NET 7`.
- 2023.1.0.0
  - Initial release.
