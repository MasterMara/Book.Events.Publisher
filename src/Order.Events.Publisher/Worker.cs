using Microsoft.Extensions.Hosting;
using Order.Events.Publisher.Logging;
using Order.Events.Publisher.Services;
using Order.Events.V1.Order;

namespace Order.Events.Publisher;

public class Worker : BackgroundService
{
    private readonly IConsoleLogger _consoleLogger;
    private readonly IMessageBrokerService _messageBrokerService;
    private readonly Action<object> _action = Action;


    public Worker(IConsoleLogger consoleLogger, IMessageBrokerService messageBrokerService)
    {
        _consoleLogger = consoleLogger;
        _messageBrokerService = messageBrokerService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        for (var i = 0; i < 1; i++)
            _action(new Context(_consoleLogger, _messageBrokerService, stoppingToken));

        await Task.CompletedTask;
    }


    private static async void Action(object c)
    {
        if (!(c is IContext context)) return;

        var i = 0;

        while (i < 20)
        {
            try
            {
                var orderDelivered = new Delivered
                {
                    Id = "123456",
                    Version = 2,
                    OrderNumber = "132456",
                    DeliveredBy = "Mustafa Karacabey"
                };
                
                await context.MessageBrokerService.Publish(orderDelivered, Guid.NewGuid());
                context.Logger.LogInformation($"Event Published, OrderNumber:{orderDelivered.OrderNumber} ");

                i++;
            }
            catch (Exception e)
            {
                //context.Logger.LogError(e.Message, e);
            }
        }
        
        
           
    }
}