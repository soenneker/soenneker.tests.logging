using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Tests.Logging.Abstract;

namespace Soenneker.Tests.Logging;

///<inheritdoc cref="ILoggingTest"/>
public abstract class LoggingTest : ILoggingTest
{
    /// <summary>
    /// Meant to be set within derivations
    /// </summary>
    protected Lazy<ILogger<LoggingTest>> LazyLogger { get; set; } = default!;

    public ILogger<LoggingTest> Logger => LazyLogger.Value;

    public Task Delay(int millisecondsDelay, string? reason = null, bool log = true)
    {
        if (log)
        {
            if (reason == null)
                Logger.LogDebug("Test delay for {ms}ms...", millisecondsDelay);
            else
                Logger.LogDebug("Test delay for {ms}ms ({reason})...", millisecondsDelay, reason);
        }

        return Task.Delay(millisecondsDelay);
    }
}