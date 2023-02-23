using Microsoft.Extensions.Logging;

namespace Book.Events.Publisher.Settings;

public class ConsoleLoggerSettings
{
    public LogLevel MinimumLogLevel { get; set; }
}