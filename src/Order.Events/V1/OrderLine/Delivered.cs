using Order.Events.Abstract;

namespace Order.Events.V1.OrderLine;

public class Delivered : IOrderlineEvent
{
    public string Id { get; set; }
    public int Version { get; set; }
    public string LineId { get; set; }
    public string Status { get; set; }
    public string DeliveredBy { get; set; }
}