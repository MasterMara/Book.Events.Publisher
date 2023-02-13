using Order.Events.Abstract.Base;

namespace Order.Events.Abstract;

public interface IOrderlineEvent : IEvent
{
    public string LineId { get; set; }
}