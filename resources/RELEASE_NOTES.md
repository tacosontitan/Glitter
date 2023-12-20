# 🗻 Glitter

Named after the second largest mountain in Norway, Glitter is a simple framework for encapsulating functionality to keep
implementations clean, concise, and optimized.

![License](https://img.shields.io/github/license/tacosontitan/Glitter?logo=github&style=for-the-badge)

> [!IMPORTANT]
> This repository is undergoing a consolidation effort. As a result some things may feel out of place, or incomplete.
> Please be patient as we work to bring everything together.*

## 2024.3.1.0

- Removed support for .NET 5.0.

## 2024.2.1.0

The pattern abstractions have been moved to the following namespaces for clarity:
- `Glitter.Patterns.Behavioral`
- `Glitter.Patterns.Structural`

Additionally, since `IRequest` and `IRequestHandler` aren't specifically related to pattern implementations they have been moved to the root namespace `Glitter`.

## 2024.1.1.0

> [!WARNING]
> The `Glitter.Data.Sql` and `Glitter.Validation` namespaces and the objects defined within them are not ready for public consumption.
> As a result, they are subject to change without notice. Use at your own risk.

- Added support for .NET 8.0.
- Added extensions for `string` instances.

## 2023.5.21

- Fixed a bug with dequeue extensions not validating until enumerated.
- Added overloads for the `In` extension.
- Added explicit support of `.NET Standard 2.1`.
- Added explicit support of `.NET Framework 4.8`.
- Added explicit support of `.NET 6`.
- Added explicit support of `.NET 7`.

## 2023.1.0.0

- Initial release.
