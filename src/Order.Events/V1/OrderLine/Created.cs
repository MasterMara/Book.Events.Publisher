using Order.Events.Abstract;
using Order.Events.Common;
using Order.Events.V1.OrderLine.Props;

namespace Order.Events.V1.OrderLine;

public class Created : IOrderlineEvent
{
    public string Id { get; set; }
    public int Version { get; set; }
    public string LineId { get; set; }
    public string Status { get; set; }
    public Money TotalMoney { get; set; }
    public Merchant Merchant { get; set; }
}