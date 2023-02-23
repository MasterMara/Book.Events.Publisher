using MassTransit;

namespace Book.Events.Publisher.Services;

public interface IMessageBrokerService
{
    Task Publish<TEvent>(TEvent @event, Guid correlationId);
}