using MassTransit;

namespace Order.Events.Publisher.Services;

public class MessageBrokerService : IMessageBrokerService
{
    private readonly IBusControl _busControl;

    public MessageBrokerService(IBusControl busControl)
    {
        _busControl = busControl;
    }

    public async Task Publish<TEvent>(TEvent @event, Guid correlationId)
    {
        void SetPublishContextParameters(PublishContext context)
        {
            context.ConversationId = correlationId;
            
            //Todo: Will set all the headers
            context.Headers.Set("username", "MasterMara");
        }

        await _busControl.Publish(@event!, SetPublishContextParameters);
    }
}