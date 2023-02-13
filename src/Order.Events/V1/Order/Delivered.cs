using Order.Events.Abstract;

namespace Order.Events.V1.Order;

public class Delivered : IOrderEvent
{
    public string Id { get; set; }
    public int Version { get; set; }
    public string OrderNumber { get; set; }
    public string DeliveredBy { get; set; }
}