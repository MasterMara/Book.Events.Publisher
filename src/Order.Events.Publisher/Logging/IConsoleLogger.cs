using System.Net;
using Microsoft.Extensions.Logging;

namespace Order.Events.Publisher.Logging;

public interface IConsoleLogger
{
    void Log(LogLevel logLevel, string message, Exception exception, string responseBody, string requestBody,
        HttpMethod httpMethod, HttpStatusCode httpStatusCode, long? duration, string url, string hostName);

    void LogTrace(string message, Exception? exception = null, string? responseBody = null,
        string? requestBody = null,
        HttpMethod? httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
        string? url = null, string? hostName = null);

    void LogDebug(string message, Exception? exception = null, string? responseBody = null, string? requestBody = null,
        HttpMethod? httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
        string? url = null, string? hostName = null);

    void LogInformation(string message, Exception? exception = null, string? responseBody = null,
        string? requestBody = null,
        HttpMethod? httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
        string? url = null, string? hostName = null);

    void LogWarning(string message, Exception? exception = null, string? responseBody = null,
        string? requestBody = null,
        HttpMethod? httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
        string? url = null, string? hostName = null);

    void LogError(string message, Exception? exception = null, string? responseBody = null, string? requestBody = null,
        HttpMethod? httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
        string? url = null, string? hostName = null);

    void LogCritical(string message, Exception? exception = null, string? responseBody = null,
        string? requestBody = null,
        HttpMethod? httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
        string? url = null, string? hostName = null);
}