using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Soenneker.Tests.Logging.Abstract;

/// <summary>
///  base testing class providing logging capabilities
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
    Task Delay(int millisecondsDelay, string? reason = null, bool log = true);
}