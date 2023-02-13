namespace Order.Events.Abstract.Base;

public interface IEvent
{
    public string Id { get; set; }
    public int Version { get; set; }
}