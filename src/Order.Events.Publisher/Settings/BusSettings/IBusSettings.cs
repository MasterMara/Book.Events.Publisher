namespace Order.Events.Publisher.Settings.BusSettings;

public interface IBusSettings
{
    string ClusterName { get; set; }
    string[] ClusterMembers { get; set; }
    string Username { get; set; }
    string Password { get; set; }
    int Heartbeat { get; set; }
    int PrefetchCount  { get; set; }
    int ConcurrencyLimit  { get; set; }
    bool AutoDelete { get; set; }
    bool Durable { get; set; }
}