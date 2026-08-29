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
    /// Will build and return a Microsoft logger from the static serilog instance (once per UnitTest lifetime). <para/>
    /// Syntactic sugar for lazy MS Logger
    /// </summary>
    ILogger<LoggingTest> Logger { get; }

    /// <summary>
    /// Wraps Task.Delay with a log statement. Should be used for delays in tests. <para/>
    /// </summary>
    /// <param name="millisecondsDelay">Milliseconds Delay for the delay operation.</param>
    /// <param name="reason">Reason for the delay operation.</param>
    /// <param name="log">Whether log.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the delay operation is complete.</returns>
    Task Delay(int millisecondsDelay, string? reason = null, bool log = true, CancellationToken cancellationToken = default);
}
