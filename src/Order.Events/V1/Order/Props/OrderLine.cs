using Order.Events.Common;

namespace Order.Events.V1.Order.Props;

public class OrderLine
{
    public string Id { get; set; }
    public string Sku { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public Money UnitPrice { get; set; }
}