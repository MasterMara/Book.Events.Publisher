using Book.Events.Abstract;
using Book.Events.Common;
using Book.Events.V1.Book.Props;

namespace Book.Events.V1.Book;


public class Created : IBookEvent
{
    public string Id { get; set; }
    public string BookNumber { get; set; }
    public int Version { get; set; }
    public string BookName { get; set; }
    public Writer Writer { get; set; }
    public Money TotalAmount { get; set; }
    
}