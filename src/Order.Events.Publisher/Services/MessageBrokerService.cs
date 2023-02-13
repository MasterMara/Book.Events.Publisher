using MassTransit;

namespace Order.Events.Publisher.Services;

public class MessageBrokerService : IMessageBrokerService
{
    private readonly IBusControl _busControl;

    public MessageBrokerService(IBusControl busControl)
    {
        _busControl = busControl;
    }

    public Task Publish<TEvent>(TEvent @event, ConsumeContext context)
    {
        throw new NotImplementedException();
    }
}