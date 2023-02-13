using Order.Events.Publisher.Logging;
using Order.Events.Publisher.Services;

namespace Order.Events.Publisher;

public interface IContext
{
    IConsoleLogger Logger { get; }
    IMessageBrokerService MessageBrokerService { get; }
    CancellationToken StoppingToken { get; }
}

public class Context : IContext
{
    public Context(
        IConsoleLogger logger,
        IMessageBrokerService messageBrokerService,
        CancellationToken stoppingToken
    )
    {
        Logger = logger;
        MessageBrokerService = messageBrokerService;
        StoppingToken = stoppingToken;
    }

    public IConsoleLogger Logger { get; }
    public IMessageBrokerService MessageBrokerService { get; }
    public CancellationToken StoppingToken { get; }
}