
namespace Order.Events.V1.Order;

public class Delivered
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public string OrderNumber { get; set; }
    public string Status { get; set; }
}