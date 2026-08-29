[![](https://img.shields.io/nuget/v/Soenneker.Tests.Logging.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Tests.Logging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.tests.logging/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.tests.logging/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Tests.Logging.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Tests.Logging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.tests.logging/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.tests.logging/actions/workflows/codeql.yml)

# Soenneker.Tests.Logging

A base testing class providing logging capabilities.

## Install

```bash
dotnet add package Soenneker.Tests.Logging
```

## Quick start

```csharp
using Soenneker.Tests.Logging.Abstract;

ILoggingTest loggingTest = /* resolve from DI */;
await loggingTest.Delay(1, default);
```

Wraps Task.Delay with a log statement. Should be used for delays in tests.

## What you get

- `ILoggingTest` — A base testing class providing logging capabilities.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `ILoggingTest.Logger` | Will build and return a Microsoft logger from the static serilog instance (once per UnitTest lifetime). Syntactic sugar for lazy MS Logger. | Will build and return a Microsoft logger from the static serilog instance (once per UnitTest lifetime). Syntactic sugar for lazy MS Logger. |
| `ILoggingTest.Delay(millisecondsDelay, reason, log, cancellationToken)` | Wraps Task.Delay with a log statement. Should be used for delays in tests. | A task that completes when the delay operation is complete. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
