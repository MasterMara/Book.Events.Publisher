using MassTransit;

namespace Order.Events.Publisher.Services;

public interface IMessageBrokerService
{
    Task Publish<TEvent>(TEvent @event, ConsumeContext context);
}