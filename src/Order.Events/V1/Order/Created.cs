using Order.Events.Abstract;
using Order.Events.Common;
using Order.Events.V1.Order.Props;

namespace Order.Events.V1.Order;

public class Created : IOrderEvent
{
    public string Id { get; set; }
    public int Version { get; set; }
    public string Status { get; set; }
    public string OrderNumber { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public Money TotalAmount { get; set; }
    public Visibility Visibility { get; set; }
    public User User { get; set; }
    public Address Address { get; set; }
    public Payment Payment { get; set; }

    public IEnumerable<Props.OrderLine> OrderLines { get; set; }
}