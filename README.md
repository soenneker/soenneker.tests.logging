[![](https://img.shields.io/nuget/v/Soenneker.Tests.Logging.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Tests.Logging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.tests.logging/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.tests.logging/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Tests.Logging.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Tests.Logging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.tests.logging/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.tests.logging/actions/workflows/codeql.yml)

# Soenneker.Tests.Logging

An infrastructure base class for test frameworks that want a lazily supplied `ILogger` and logged asynchronous delays.

## Installation

```bash
dotnet add package Soenneker.Tests.Logging
```

Most applications should consume this indirectly through `Soenneker.Tests.Unit`, `Soenneker.Tests.HostedUnit`, or `Soenneker.Tests.Integration`, which configure the logger for their respective lifecycles.

## Custom derivation

When deriving directly, initialize `LazyLogger` before `Logger` or a logged `Delay` is used:

```csharp
using Microsoft.Extensions.Logging;
using Soenneker.Tests.Logging;

public abstract class LoggedTestBase : LoggingTest
{
    protected LoggedTestBase(ILoggerFactory loggerFactory)
    {
        LazyLogger = new Lazy<ILogger<LoggingTest>>(
            () => loggerFactory.CreateLogger<LoggingTest>());
    }
}
```

The package does not create or own the logger factory. The derived test infrastructure controls logger lifetime and where output is written.

## Logged delays

```csharp
await Delay(
    millisecondsDelay: 250,
    reason: "waiting for the worker to observe the message",
    cancellationToken: cancellationToken);
```

`Delay` logs at debug level immediately before calling `Task.Delay`. Set `log: false` to suppress that message. Cancellation and invalid delay values follow normal `Task.Delay` behavior.

Prefer waiting on an observable condition when one is available. A logged delay makes an unavoidable timing wait easier to diagnose, but it does not make time-dependent tests deterministic.
