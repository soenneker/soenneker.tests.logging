using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Tests.Logging.Abstract;

/// <summary>
///  A base testing class providing logging capabilities
/// </summary>
public interface ILoggingTest
{
    /// <summary>
    /// Gets the logger configured by the concrete test base.
    /// </summary>
    ILogger<LoggingTest> Logger { get; }

    /// <summary>
    /// Logs an optional reason and then asynchronously waits for the requested duration.
    /// </summary>
    /// <param name="millisecondsDelay">Milliseconds Delay for the delay operation.</param>
    /// <param name="reason">Reason for the delay operation.</param>
    /// <param name="log">Whether log.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the delay operation is complete.</returns>
    Task Delay(int millisecondsDelay, string? reason = null, bool log = true, CancellationToken cancellationToken = default);
}
