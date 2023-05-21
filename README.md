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

![.NET Workflow](https://img.shields.io/github/actions/workflow/status/tacosontitan/Glitter.Extensions/build.yml?label=Build%20and%20Test&logo=dotnet&style=for-the-badge)

### 💎 A few more gems

We believe in keeping the community informed, so here's a few more tidbits of information to satisfy some additional curiosities:

![Contributors](https://img.shields.io/github/contributors/tacosontitan/Glitter.Extensions?logo=github&style=for-the-badge)
![Issues](https://img.shields.io/github/issues/tacosontitan/Glitter.Extensions?logo=github&style=for-the-badge)
![Stars](https://img.shields.io/github/stars/tacosontitan/Glitter.Extensions?logo=github&style=for-the-badge)
![Size](https://img.shields.io/github/languages/code-size/tacosontitan/Glitter.Extensions?logo=github&style=for-the-badge)
![Line Count](https://img.shields.io/tokei/lines/github/tacosontitan/Glitter.Extensions?logo=github&style=for-the-badge)

## 🔥 What `Glitter.Extensions` has to offer

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

## 📝 Release Notes

- 2023.5.21
  - Fixed a bug with dequeue extensions not validating until enumerated.
  - Added overloads for the `In` extension.
  - Added explicit support of `.NET Standard 2.1`.
  - Added explicit support of `.NET Framework 4.8`.
  - Added explicit support of `.NET 6`.
  - Added explicit support of `.NET 7`.
- 2023.1.0.0
  - Initial release.
