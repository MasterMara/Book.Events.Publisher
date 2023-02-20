using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Order.Events.Publisher.Logging;
using Order.Events.Publisher.Services;
using Order.Events.Publisher.Settings;
using Order.Events.Publisher.Settings.BusSettings;
using Order.Events.V1.Order;
using ExchangeType = RabbitMQ.Client.ExchangeType;

namespace Order.Events.Publisher;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(configHost =>
            {
                configHost.AddEnvironmentVariables(prefix: "DOTNET_");
            })
            .ConfigureServices((hostContext, services) =>
            {
                //Configs
                services.Configure<BusSettings>(
                    hostContext.Configuration.GetSection(nameof(BusSettings)));
                
                services.Configure<ConsoleLoggerSettings>(
                    hostContext.Configuration.GetSection(nameof(ConsoleLoggerSettings)));

                //DI Injections
                services.AddSingleton<IConsoleLogger, ConsoleLogger>();
                services.AddSingleton<IMessageBrokerService, MessageBrokerService>();
                services.AddSingleton<IBusSettings>(provider =>
                    provider.GetRequiredService<IOptions<BusSettings>>().Value);
                
                services.AddMassTransit(configurator => configurator.AddBus(provider =>
                {
                    var busSettings = provider.GetRequiredService<IBusSettings>();

                    return Bus.Factory.CreateUsingRabbitMq(factoryConfigurator =>
                    {
                        factoryConfigurator.Host(new Uri(busSettings.HostAddress), hostConfigurator =>
                        {
                            hostConfigurator.Username(busSettings.Username);
                            hostConfigurator.Password(busSettings.Password);
                            hostConfigurator.Heartbeat(busSettings.Heartbeat);
                            hostConfigurator.UseCluster(clusterConfigurator =>
                            {
                                foreach (var clusterMember in busSettings.ClusterMembers)
                                    clusterConfigurator.Node(clusterMember);
                            });
                        });

                        ConfigureOrderLineExchanges(factoryConfigurator);
                    });
                }));
                
                services.AddHostedService<Worker>();
            });


        await builder.Build().RunAsync();
    }


    private static void ConfigureOrderLineExchanges(IRabbitMqBusFactoryConfigurator cfg)
    {
        #region Order.Events.V1.Order.Created

        cfg.Send<Created>(x => { x.UseRoutingKeyFormatter(c => RoutingKeyFormat()); });

        cfg.Publish<Created>(x => x.ExchangeType = ExchangeType.Topic);

        #endregion

        #region Order.Events.V1.Order.InProgressed

        cfg.Send<InProgressed>(x => { x.UseRoutingKeyFormatter(c => RoutingKeyFormat()); });

        cfg.Publish<InProgressed>(x => x.ExchangeType = ExchangeType.Topic);

        #endregion

        #region Order.Events.V1.Order.InTransitted

        cfg.Send<InTransitted>(x => { x.UseRoutingKeyFormatter(c => RoutingKeyFormat()); });

        cfg.Publish<InTransitted>(x => x.ExchangeType = ExchangeType.Topic);

        #endregion

        #region Order.Events.V1.Order.Delivered

        cfg.Send<Delivered>(x => { x.UseRoutingKeyFormatter(c => RoutingKeyFormat()); });

        cfg.Publish<Delivered>(x => x.ExchangeType = ExchangeType.Topic);

        #endregion
    }

    private static string RoutingKeyFormat()
    {
        return $"Order.Master.*";
    }
}