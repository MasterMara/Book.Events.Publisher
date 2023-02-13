namespace Order.Events.Publisher.Settings.BusSettings;

public class BusSettings : IBusSettings
{
    public string ClusterName { get; set; }
    public string[] ClusterMembers { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Heartbeat { get; set; }
    public int PrefetchCount { get; set; }
    public int ConcurrencyLimit { get; set; }
    public bool AutoDelete { get; set; }
    public bool Durable { get; set; }
}