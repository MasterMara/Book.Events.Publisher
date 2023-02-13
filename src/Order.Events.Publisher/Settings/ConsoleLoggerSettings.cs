using Microsoft.Extensions.Logging;

namespace Order.Events.Publisher.Settings;

public class ConsoleLoggerSettings
{
    public LogLevel MinimumLogLevel { get; set; }
}