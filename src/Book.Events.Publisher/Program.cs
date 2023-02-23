using Book.Events.Publisher.Logging;
using Book.Events.Publisher.Services;
using Book.Events.Publisher.Settings;
using Book.Events.Publisher.Settings.BusSettings;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Book.Events.V1.Book;
using ExchangeType = RabbitMQ.Client.ExchangeType;

namespace Book.Events.Publisher;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(configHost => { configHost.AddEnvironmentVariables(prefix: "DOTNET_"); })
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

                        ConfigureBookExchanges(factoryConfigurator);
                    });
                }));

                services.AddHostedService<Worker>();
            });


        await builder.Build().RunAsync();
    }


    private static void ConfigureBookExchanges(IRabbitMqBusFactoryConfigurator cfg)
    {
        #region Events.V1.Book:Created

        cfg.Send<Created>(x => { x.UseRoutingKeyFormatter(c => RoutingKeyFormat()); });

        cfg.Publish<Created>(x => x.ExchangeType = ExchangeType.Topic);

        #endregion
        
        #region Events.V1.Book:Placed

        cfg.Send<Placed>(x => { x.UseRoutingKeyFormatter(c => RoutingKeyFormat()); });

        cfg.Publish<Placed>(x => x.ExchangeType = ExchangeType.Topic);

        #endregion
        
        #region Events.V1.Book:Printed

        cfg.Send<Printed>(x => { x.UseRoutingKeyFormatter(c => RoutingKeyFormat()); });

        cfg.Publish<Printed>(x => x.ExchangeType = ExchangeType.Topic);

        #endregion
        
        #region Events.V1.Book:Published

        cfg.Send<Published>(x => { x.UseRoutingKeyFormatter(c => RoutingKeyFormat()); });

        cfg.Publish<Published>(x => x.ExchangeType = ExchangeType.Topic);

        #endregion
        
        #region Events.V1.Book:Deleted

        cfg.Send<Deleted>(x => { x.UseRoutingKeyFormatter(c => RoutingKeyFormat()); });

        cfg.Publish<Deleted>(x => x.ExchangeType = ExchangeType.Topic);

        #endregion
    }

    private static string RoutingKeyFormat()
    {
        return $"Book.*";
    }
}