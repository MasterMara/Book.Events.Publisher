using Order.Events.Common;

namespace Order.Events.V1.Order.Props;

public class Payment
{
    public string Id { get; set; }
    public string BankName { get; set; }
    public string BankId { get; set; }
    public Money Amount { get; set; }
}