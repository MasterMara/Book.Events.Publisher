using System.Diagnostics;
using System.Net;
using Book.Events.Publisher.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Book.Events.Publisher.Logging;

public class ConsoleLogger : IConsoleLogger
{
    private readonly IOptions<ConsoleLoggerSettings> _consoleLoggerSettingsOptions;

    public ConsoleLogger(IOptions<ConsoleLoggerSettings> consoleLoggerSettingOptions)
    {
        _consoleLoggerSettingsOptions = consoleLoggerSettingOptions;
    }

    public void Log(LogLevel logLevel, string message, Exception exception, string responseBody, string requestBody,
        HttpMethod httpMethod, HttpStatusCode httpStatusCode, long? duration, string hostName, string url)
    {
        if (_consoleLoggerSettingsOptions.Value.MinimumLogLevel > logLevel)
        {
            return;
        }

        Console.WriteLine(JsonConvert.SerializeObject(new
        {
            CorrelationId = Trace.CorrelationManager.ActivityId,
            DateTime = DateTime.Now,
            LogLevel = logLevel.ToString(),
            Message = message,
            Exception = exception.ToString(),
            ResponseBody = responseBody,
            RequestBody = requestBody,
            HttpMethod = httpMethod.Method,
            HttpStatusCode = (int)httpStatusCode,
            Duration = duration,
            HostName = hostName,
            Url = url
        }));
    }

    public void LogTrace(string message, Exception? exception = null, string? responseBody = null,
        string? requestBody = null,
        HttpMethod? httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null, string? url = null,
        string? hostName = null)
    {
        Log(LogLevel.Trace, message, exception!, responseBody!, requestBody!, httpMethod!,
            httpStatusCode.GetValueOrDefault(), duration, hostName!, url!);
    }

    public void LogDebug(string message, Exception? exception = null, string? responseBody = null,
        string? requestBody = null,
        HttpMethod? httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null, string? url = null,
        string? hostName = null)
    {
        Log(LogLevel.Debug, message, exception!, responseBody!, requestBody!, httpMethod!,
            httpStatusCode.GetValueOrDefault(), duration, hostName!, url!);
    }

    public void LogInformation(string message, Exception? exception = null, string? responseBody = null,
        string? requestBody = null, HttpMethod? httpMethod = null, HttpStatusCode? httpStatusCode = null,
        long? duration = null, string? url = null, string? hostName = null)
    {
        Log(LogLevel.Information, message, exception!, responseBody!, requestBody!, httpMethod!,
            httpStatusCode.GetValueOrDefault(), duration, hostName!, url!);
    }

    public void LogWarning(string message, Exception? exception = null, string? responseBody = null,
        string? requestBody = null,
        HttpMethod? httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null, string? url = null,
        string? hostName = null)
    {
        Log(LogLevel.Warning,message, exception!, responseBody!, requestBody!, httpMethod!,
            httpStatusCode.GetValueOrDefault(), duration, hostName!, url!);
    }

    public void LogError(string message, Exception? exception = null, string? responseBody = null,
        string? requestBody = null,
        HttpMethod? httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null, string? url = null,
        string? hostName = null)
    {
        Log(LogLevel.Error, message, exception!, responseBody!, requestBody!, httpMethod!,
            httpStatusCode.GetValueOrDefault(), duration, hostName!, url!);
    }

    public void LogCritical(string message, Exception? exception = null, string? responseBody = null,
        string? requestBody = null,
        HttpMethod? httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null, string? url = null,
        string? hostName = null)
    {
        Log(LogLevel.Critical,message, exception!, responseBody!, requestBody!, httpMethod!,
            httpStatusCode.GetValueOrDefault(), duration, hostName!, url!);
    }
}