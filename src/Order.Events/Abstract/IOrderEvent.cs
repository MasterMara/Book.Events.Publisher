using Order.Events.Abstract.Base;

namespace Order.Events.Abstract;

public interface IOrderEvent : IEvent
{
    public string OrderNumber { get; set; }
}